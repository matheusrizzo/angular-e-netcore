using Domain.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
        public static ModelBuilder SeedData(this ModelBuilder builder)
        {

            builder.Entity<User>()
                .HasData(
                new User { Id = Guid.Parse("c9ec1d76-d512-425d-b8e2-16281cea419a"), Name = "User Default", Email = "userdefault@template.com", Password = "1q2w3e4r" }
            );

            return builder;
        }
        public static ModelBuilder ApplyModelConfiguration(this ModelBuilder builder)
        {
            foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes() ) { 

                foreach(IMutableProperty property in entityType.GetProperties())
                {
                    switch(property.Name)
                    {
                        case nameof(BaseEntity.Id):
                            property.IsKey();
                            break;

                        case nameof(BaseEntity.DateUpdated):
                            property.IsNullable = true;
                            break;
                        case nameof(BaseEntity.DateCreated):
                            property.IsNullable = false;
                            property.SetDefaultValue(DateTime.Now);
                            break;
                        case nameof(BaseEntity.IsDeleted):
                            property.IsNullable = false;
                            property.SetDefaultValue(false);
                            break;

                    }
                }
            }
            return builder;
        }
    }
}
