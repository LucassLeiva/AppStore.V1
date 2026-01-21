namespace AppStore.Backend.DataContexts.EFCore.DataContexts
{
    
        internal class AppStoreContext : DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\MSSQLLocalDB;Database=AppMercadoDB;Trusted_Connection=True;TrustServerCertificate=True;");
            }

            public DbSet<ProductEntity> Products { get; set; }
            public DbSet<StockEntity> Stocks { get; set; }
            public DbSet<CategoryEntity> Categories { get; set; }
            public DbSet<SupplierEntity> Suppliers { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            }
        }
    
}
