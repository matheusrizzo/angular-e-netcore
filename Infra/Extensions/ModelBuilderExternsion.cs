using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Extensions
{
    public static class ModelBuilderExternsion
    {
        public static ModelBuilder SeedData(this ModelBuilder builder) {

            builder.Entity<User>()
                .HasData(
                new User { Id = Guid.Parse("c9ec1d76-d512-425d-b8e2-16281cea419a"), Name = "User Default", Email = "userdefault@template.com" }
            );
            
            return builder; 
        }
    }
}
