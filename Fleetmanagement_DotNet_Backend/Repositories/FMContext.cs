using Microsoft.EntityFrameworkCore;
using FM.Modles;


namespace FM.Repositories;

public partial class FMContext : DbContext
{
   

    public FMContext(DbContextOptions<FMContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AddOn> AddOns { get; set; }

    public virtual DbSet<Airport> Airports { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<BookingDetail> BookingDetails { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarType> CarTypes { get; set; }

    public virtual DbSet<City> CityMasters { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Hub> Hubs { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    public virtual DbSet<State> StateMasters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<City>()
            .HasOne(c => c.State)
            .WithMany() // Assuming a State has many Cities
            .HasForeignKey(c => c.State_ID)
            .HasPrincipalKey(s => s.StateId);
    

    // Configure relationships if needed
    modelBuilder.Entity<Hub>()
            .HasOne(h => h.City)
            .WithMany()
            .HasForeignKey(h => h.CityId)
            .OnDelete(DeleteBehavior.NoAction); // Adjust as needed

        modelBuilder.Entity<Hub>()
            .HasOne(h => h.State)
            .WithMany()
            .HasForeignKey(h => h.StateId)
            .OnDelete(DeleteBehavior.NoAction); // Adjust as needed
        modelBuilder.Entity<Airport>()
        .HasOne(a => a.City)
        .WithMany() // Or specify the inverse navigation property
        .HasForeignKey(a => a.CityId)
        .OnDelete(DeleteBehavior.Restrict); // or NoAction

        modelBuilder.Entity<Airport>()
            .HasOne(a => a.State)
            .WithMany() // Or specify the inverse navigation property
            .HasForeignKey(a => a.StateId)
            .OnDelete(DeleteBehavior.Restrict); // or NoAction

        modelBuilder.Entity<Airport>()
            .HasOne(a => a.Hub)
            .WithMany() // Or specify the inverse navigation property
            .HasForeignKey(a => a.HubId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Customer>()
            .Property(c => c.CustomerId)
            .ValueGeneratedOnAdd(); // This should be the default behavior
    

}

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=Fleetmanagement;Integrated Security=True;");
}