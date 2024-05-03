using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Configuration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SupplierMapProfile>();
                cfg.AddProfile<CategoryMapProfile>();
                cfg.AddProfile<ProductMapProfile>();
                cfg.AddProfile<UserMapProfile>();
                cfg.AddProfile<OrderMapProfile>();
            });
            return config;
        }
    }
}
