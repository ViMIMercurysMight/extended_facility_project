using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations
{
    public class FacilityStatusConfiguration
        : IEntityTypeConfiguration<Domain.Entities.FacilityStatus>
    {
        public void Configure(EntityTypeBuilder<FacilityStatus> builder)
        {

            builder.HasKey(x => x.Id);



            builder.HasData(
                new Domain.Entities.FacilityStatus[]
                {
                    new Domain.Entities.FacilityStatus() { Id = (int)Domain.Enums.FacilityStatus.INACTIVE, Name = "InActive"},
                    new Domain.Entities.FacilityStatus() { Id = (int)Domain.Enums.FacilityStatus.ACTIVE,   Name = "Active"},
                    new Domain.Entities.FacilityStatus() { Id = (int)Domain.Enums.FacilityStatus.ON_HOLD,  Name = "OnHold"},
                }
                );

        }
    }
}
