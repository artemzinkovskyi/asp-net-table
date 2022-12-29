using Coreapp.Models;
using Microsoft.EntityFrameworkCore;

namespace Coreapp.Data;

public class NewBaseType
{
}

public class ApplicationDbContext :DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }


    public DbSet<Category> Categories{get;set;}
}