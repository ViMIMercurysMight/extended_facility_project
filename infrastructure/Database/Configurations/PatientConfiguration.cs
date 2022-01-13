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

    public class PatientConfiguration
        : IEntityTypeConfiguration<Domain.Entities.Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {

          //  builder.ToTable("Patient");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                   .UseIdentityColumn();


            builder
                .Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(125)
                .HasColumnType("nvarchar");


            builder
                .Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(125)
                .HasColumnType("nvarchar");


            builder
                .Property(p => p.DateOfBirth)
                .IsRequired()
                .HasColumnType("date");

        }
    }
}
