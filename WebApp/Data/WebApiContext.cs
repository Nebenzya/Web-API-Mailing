using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data;

public class WebApiContext : DbContext
{
    public DbSet<Email> Emails { get; set; }
    public DbSet<Recipient> Recipients { get; set; }

    public WebApiContext(DbContextOptions<WebApiContext> options) : base(options)
    {
        //Используется только если не планируется использовать миграцию
        //Database.EnsureCreated();
    }
}
