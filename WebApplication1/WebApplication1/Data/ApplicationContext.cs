using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class ApplicationContext : DbContext
{
    protected ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Clients> ClientsEnumerable { get; set; }
    public DbSet<Employees> EmployeesEnumerable { get; set; }
    public DbSet<Order_pastry> OrderPastries { get; set; }
    public DbSet<Orders> OrdersEnumerable { get; set; }
    public DbSet<Pastry> Pastries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Adding example Clients
        modelBuilder.Entity<Clients>().HasData(
            new Clients { ClientID = 1, FirstName = "John", LastName = "Doe" },
            new Clients { ClientID = 2, FirstName = "Jane", LastName = "Smith" }
        );

        // Adding example Employees
        modelBuilder.Entity<Employees>().HasData(
            new Employees { EmployeeID = 1, FirstName = "Alice", LastName = "Johnson" },
            new Employees { EmployeeID = 2, FirstName = "Bob", LastName = "Brown" }
        );

        // Adding example Pastries
        modelBuilder.Entity<Pastry>().HasData(
            new Pastry { PastryID = 1, Name = "Croissant", Price = 2.5, Type = "Bread" },
            new Pastry { PastryID = 2, Name = "Muffin", Price = 3.0, Type = "Cake" }
        );

        // Adding example Orders
        modelBuilder.Entity<Orders>().HasData(
            new Orders
            {
                OrderId = 1,
                AcceptedAt = DateTime.Now,
                FulfilledAt = DateTime.Now.AddHours(2),
                Comments = "First order",
                ClientId = 1,
                EmployeeId = 1
            },
            new Orders
            {
                OrderId = 2,
                AcceptedAt = DateTime.Now,
                FulfilledAt = DateTime.Now.AddHours(3),
                Comments = "Second order",
                ClientId = 2,
                EmployeeId = 2
            }
        );

        // Adding example Order_pastries
        modelBuilder.Entity<Order_pastry>().HasData(
            new Order_pastry { OrderId = 1, PastryId = 1, Amount = 3, Comment = "For breakfast" },
            new Order_pastry { OrderId = 2, PastryId = 2, Amount = 5, Comment = "For meeting" }
        );
    }
}