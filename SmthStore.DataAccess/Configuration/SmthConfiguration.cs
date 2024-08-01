using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmthStore.Core.Models;
using SmthStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmthStore.DataAccess.Configuration
{
    public class SmthConfiguration : IEntityTypeConfiguration<SmthEntity>
    {
        public void Configure(EntityTypeBuilder<SmthEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Name)
                .HasMaxLength(Smth.MAX_NAME_LENGTH)
                .IsRequired(); ;

            builder.Property(b => b.Description)  
                .IsRequired();
        }
    }
}
