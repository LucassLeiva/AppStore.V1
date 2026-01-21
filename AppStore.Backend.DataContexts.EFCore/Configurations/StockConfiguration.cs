namespace AppStore.Backend.DataContexts.EFCore.Configurations
{
    internal class StockConfiguration : IEntityTypeConfiguration<StockEntity>
    {
        public void Configure(EntityTypeBuilder<StockEntity> builder)
        {
            builder.HasKey(s => s.IdStock);

            builder.Property(s => s.Amount)
                .IsRequired();

            builder.Property(s => s.State)
                .IsRequired();
        }
    }
}
