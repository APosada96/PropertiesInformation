using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesInformation.Domain.Interfaces.Storage
{
    public interface IFileStorageRepository
    {
        Task<string> Store(string container, IFormFile file);
        Task Delete(string rute, string container);
    }
}
