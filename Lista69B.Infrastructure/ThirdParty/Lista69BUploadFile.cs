using CsvHelper;
using CsvHelper.Configuration;
using Lista69B.Domain;
using Lista69B.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista69B.Infrastructure.ThirdParty
{
    public class Lista69BUploadFile : IList69BSource
    {
        private readonly string _url= "http://omawww.sat.gob.mx/cifras_sat/Documents/Listado_Completo_69-B.csv";
        private readonly int _header;

        public Lista69BUploadFile(string url, int header)
        {
            _url = url;
            _header = header;
        }

        //implementamos la descarga del archivo
        public async Task<Lista69BEntity> UploadFile()
        {
            Lista69BEntity result;
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(_url))
                using (Stream streamToReadFrom = await response.Content.ReadAsStreamAsync())
                {
                    using (var reader = new StreamReader(streamToReadFrom, Encoding.GetEncoding("ISO-8859-1"), false))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture, false))
                    {
                       
                            //se agrga lectura por las 2 lineas iniciales del archivo
                            //var titulo = reader.ReadLine().Replace(",", string.Empty).Replace(" ", string.Empty)??"";
                            result = new Lista69BEntity(Guid.NewGuid(), reader.ReadLine().Replace(",", string.Empty).Replace(" ", string.Empty), true);
                            reader.ReadLine();

                            csv.Context.RegisterClassMap<ResulMapper>();
                            var records = csv.GetRecords<Lista69BRegistroEntity>();

                            result.AddList(records.ToList());
                        

                    }
                }
            }

            return result;
        }


        
    }
    public sealed class ResulMapper: ClassMap<Lista69BRegistroEntity>
    {
        public ResulMapper()
        {
            Map(x => x.No).Name("No");
            Map(x => x.RFC).Name("RFC");
            Map(x => x.NombredelContribuyente).Name("Nombre del Contribuyente");
            Map(x => x.SituacionContribuyente).Name("Situación del contribuyente");
            Map(x => x.NumeroYFechaDeOficioGlobalDePresuncionSAT).Name("Número y fecha de oficio global de presunción SAT");
            Map(x => x.PublicacionPaginaSATPresuntos).TypeConverter<CsvHelper.TypeConversion.DateTimeConverter>().TypeConverterOption.Format("dd/MM/yyyy").Name("Publicación página SAT presuntos");
            Map(x => x.NumeroYFechaDeOficioGlobalDePresuncionDOF).Name("Número y fecha de oficio global de presunción DOF");
            Map(x => x.PublicacionDOFPresuntos).Name("Publicación DOF presuntos");
            Map(x => x.NumeroYFechaDeOficioGlobalDeContribuyentesQueDesvirtuaronSAT).Name("Número y fecha de oficio global de contribuyentes que desvirtuaron SAT");
            Map(x => x.PublicacionPaginaSATDesvirtuados).Name("Publicación página SAT desvirtuados");
            Map(x => x.NumeroyFechaDeOficioGlobalDeContribuyentesQueDesvirtuaronDOF).Name("Número y fecha de oficio global de contribuyentes que desvirtuaron DOF");
            Map(x => x.PublicacionDOFDesvirtuados).Name("Publicación DOF desvirtuados");
            Map(x => x.NumeroYFechaDeOficioGlobalDeContribuyentesQueDesvirtuaronSAT).Name("Número y fecha de oficio global de definitivos SAT");
            Map(x => x.PublicacionPaginaSATDefinitivos).Name("Publicación página SAT definitivos");
            Map(x => x.NumeroYFechaDeOficioGlobalDeDefinitivosDOF).Name("Número y fecha de oficio global de definitivos DOF");
            Map(X => X.PublicacionDOFDefinitivos).Name("Publicación DOF definitivos");
            Map(x => x.NumeroYFechaDeOficioGlobalDeSentenciaFavorableSAT).Name("Número y fecha de oficio global de sentencia favorable SAT");
            Map(x => x.PublicacionPaginaSATSentenciaFavorable).Name("Publicación página SAT sentencia favorable");
            Map(x => x.NumeroYFechaDeOficioGlobalDeSentenciaFavorableDOF).Name("Número y fecha de oficio global de sentencia favorable DOF");
            Map(x => x.PublicacionDOFSentenciaFavorable).Name("Publicación DOF sentencia favorable");

        }
    }
}
