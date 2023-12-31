﻿using AutoMapper;
using FluentValidation;
using Lista69B.Application.Background;
using Lista69B.Application.Lista.Map;
using Lista69B.Application.Usuario;
using Lista69B.Application.Utils;
using Lista69B.Domain.Interface;
using Lista69B.Domain.Repository;
using Lista69B.Infrastructure.DB;
using Lista69B.Infrastructure.DB.Repository;
using Lista69B.Infrastructure.ThirdParty;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Lista69B.Application.Lista.Query.GetByNameAndRFC;

namespace Lista69B.Application
{
    public static class IOC
    {
        public static IServiceCollection AddConfig(
          this IServiceCollection services, IConfiguration config)
        {
            //actulizar parametros para colocarlos en archivo de configuracion
            services.AddSingleton<IList69BSource>(cfg => new Lista69BUploadFile("http://omawww.sat.gob.mx/cifras_sat/Documents/Listado_Completo_69-B.csv", 1));

            services.AddTransient<IRepositoryList69B, RepositoryLista69B>();
            services.AddTransient<IRepositoryWatchlist, ListaSeguimientoRepositorio>();
            services.AddScoped<IUsuario, UsuarioHttp>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            services.AddDbContext<CTXLista69B>(option => option.UseSqlServer("Data Source=.;Initial Catalog=Lista69BTest;Integrated Security=True;TrustServerCertificate=True"), ServiceLifetime.Transient);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(typeof(Lista69BMapper));
            services.AddValidatorsFromAssemblyContaining(typeof(GetByNameAndRFCValidation));

            //background task
            services.AddQuartz(q =>
            {
                q.SchedulerName = "BackgroundScheduler";
                q.AddJob<UpdateList69BJob>(opts => opts.WithIdentity(UpdateList69BJob.Key));

                q.AddTrigger(opts => opts
                      .ForJob(UpdateList69BJob.Key)
                      .WithIdentity("SendEmailJob-trigger")
                      .StartNow()
                      .WithSimpleSchedule(x=>x.WithIntervalInHours(24).RepeatForever())
                      //This Cron interval can be described as "run every minute" (when second is zero)
                      //.WithCronSchedule("0 * * ? * *")
                  );

            });
            services.AddTransient<UpdateList69BJob>();
            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);


            return services;
        }
    }
}
