using GameTracker.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.Net.Http.Headers;


namespace GameTracker.API.Data;

public class GameTrackerContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Game> Games { get; set; }

    public GameTrackerContext() {}

    public GameTrackerContext(DbContextOptions options) : base (options) {}


//May not need
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     base.OnModelCreating(modelBuilder);
    // }
}