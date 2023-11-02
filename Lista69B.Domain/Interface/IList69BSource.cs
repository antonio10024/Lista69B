using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista69B.Domain.Interface
{
    public interface IList69BSource
    {
        public Task<Lista69BEntity> UploadFile();
    }
}
