using Hosted.Outbox.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hosted.Outbox.EntitiesConfigurations {
    public class OutBoxMessageEntityConfiguration : IEntityTypeConfiguration<OutBoxMessage> {
        public void Configure(EntityTypeBuilder<OutBoxMessage> builder) {
            builder.ToTable("OutBoxMessages", "out");
            builder.HasKey(x => x.Id);
        }
    }
}
