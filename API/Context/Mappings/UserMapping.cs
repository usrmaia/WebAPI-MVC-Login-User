using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Context.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(keyExpression => keyExpression.Id);
            builder.Property(propertyExpression => propertyExpression.Id).ValueGeneratedOnAdd();
            builder.Property(propertyExpression => propertyExpression.Login);
            builder.Property(propertyExpression => propertyExpression.Password);
            builder.Property(propertyExpression => propertyExpression.Email);
        }
    }
}