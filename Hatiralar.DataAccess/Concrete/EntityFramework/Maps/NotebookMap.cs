using Hatiralar.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatiralar.DataAccess.Concrete.EntityFramework.Maps
{
    public class NotebookMap : IEntityTypeConfiguration<Notebook>
    {
        public void Configure(EntityTypeBuilder<Notebook> builder)
        {
            builder.Property(x=>x.Title).HasMaxLength(25);
            builder.Property(x=>x.Title).IsRequired();
        }
    }
}
