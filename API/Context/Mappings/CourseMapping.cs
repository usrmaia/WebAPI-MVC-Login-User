using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Context.Mappings
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(keyExpression => keyExpression.Id);
            builder.Property(propertyExpression => propertyExpression.Id).ValueGeneratedOnAdd();
            builder.Property(propertyExpression => propertyExpression.Name);
            builder.Property(propertyExpression => propertyExpression.Description);
            builder.HasOne(navigationName => navigationName.User).WithMany().HasForeignKey(foreignKey => foreignKey.UserId);
        }
    }
}