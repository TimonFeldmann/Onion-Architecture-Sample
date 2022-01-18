//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Shopping.Domain.Generic;

//namespace Shopping.Infrastructure.EntityConfigurations
//{
//    public class EventEntityConfiguration : IEntityTypeConfiguration<EventEntity>
//    {
//        public void Configure(EntityTypeBuilder<EventEntity> builder)
//        {
//            //builder.HasKey(x => x.Id);
//            //builder.Property(x => x.Id).ValueGeneratedNever();

//            builder.Ignore(x => x.DomainEvents);
//            builder.Ignore(x => x.IntegrationEvents);
//        }
//    }
//}
