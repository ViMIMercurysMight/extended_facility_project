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


    public class FaclityConfiguration
        : IEntityTypeConfiguration<Domain.Entities.Facility>
    {
        public void Configure(EntityTypeBuilder<Facility> builder)
        {

            builder.ToTable("Facility");

            builder.HasKey(f => f.Id);
            builder
                .Property(e => e.Id)
                .UseIdentityColumn();



            builder
                .Property(p => p.Address)
                .IsRequired();

            builder
                .Property(p => p.Email)
                .IsRequired();



            builder.HasAlternateKey(p => p.Name);
            builder
                .Property(p => p.Name)
                .IsRequired();



            builder
                .Property(p => p.FacilityStatusId)
                .HasColumnName("StatusId")
                .IsRequired();

            builder
               .Property(f => f.FacilityStatusId)
               .IsRequired()
               .HasDefaultValue(Domain.Enums.FacilityStatus.INACTIVE);





        }
    }
}
