using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PropertiesInformation.Domain.Dtos;
using PropertiesInformation.Domain.Entities;
using PropertiesInformation.Domain.Interfaces.Properties;
using PropertiesInformation.Domain.Interfaces.Storage;
using PropertiesInformation.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesInformation.Repositories.Repository
{
    public class PropertyTraceRepository : IPropertyTraceRepository
    {
        private readonly PropertyDbContext _context;
        private readonly IMapper _mapper;
        public PropertyTraceRepository(PropertyDbContext context, IMapper mapper)
        {
           this._mapper = mapper;
           this._context = context;
        }

        public async Task<int> AddPropertyTrace(PropertyTraceDto propertyTrace)
        {
            try
            {
                var property = await _context.Properties.FirstOrDefaultAsync(x => x.IdProperty == propertyTrace.IdProperty);

                if (property is null) throw new ArgumentNullException($"The Property {propertyTrace.IdProperty} not exist.");

                var trace = _mapper.Map<PropertyTrace>(propertyTrace);
                trace.IdProperty = property.IdProperty;
                _context.PropertyTraces.Add(trace);
                await _context.SaveChangesAsync();
                return trace.IdPropertyTrace!;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }

        public async Task<int> DeletePropertyTrace(int id)
        {
            try
            {
                var trace = await _context.PropertyTraces.FirstOrDefaultAsync(x => x.IdPropertyTrace == id);

                if (trace == null) throw new ArgumentNullException($"The Property Trace {id} not exist.");

                _context.PropertyTraces.Remove(trace);
                await _context.SaveChangesAsync();
                return trace.IdPropertyTrace!;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}
