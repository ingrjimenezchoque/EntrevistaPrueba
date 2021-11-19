#region Imports
using AutoMapper;
using Prueba_HPTP.Models;
#endregion

namespace Prueba_HPTP.DTO
{
    public class AutoMapperConfiguration
    {

        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employe, EmployeDTO>()
                   .ReverseMap();
            });
        }
    }
}