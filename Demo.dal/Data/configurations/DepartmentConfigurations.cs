using Demo.dal.module;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.dal.Data.configurations
{
   public class DepartmentConfigurations : IEntityTypeConfiguration<DepartmentDTO>
    {
        public void Configure(EntityTypeBuilder<DepartmentDTO> builder)
        {
           builder.Property(D=> D.Id).UseIdentityColumn(10,10);
            builder.Property(D=>D.Name).HasColumnType("varchar(20)");
            builder.Property(D => D.Code).HasColumnType("varchar(20)");
            builder.Property(D => D.CreatedOn).HasDefaultValueSql("GetDate()");
            builder.Property(D => D.LastModifiedOn).HasComputedColumnSql("GetDate()");



        }
    }
}
