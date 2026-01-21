namespace AppStore.Backend.DataContexts.EFCore.DataContexts

{
        internal class AppStoreProductionContext(IOptions<DBOptions> dbOptions) : DbContext
        {
            public DbSet<ProductEntity> Product { get; set; } = default!;
            public DbSet<StockEntity> Stock { get; set; } = default!;
            public DbSet<CategoryEntity> Category { get; set; } = default!;
            public DbSet<SupplierEntity> Supplier { get; set; } = default!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(dbOptions.Value.ConnectionString);
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            }
        }

}
