using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EducationContentApp.Models;

namespace EducationContentApp.Services;
public class AppDbContext : DbContext
{
    public DbSet<ContentItem> ContentItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "content.db");
        string directory = Path.GetDirectoryName(dbPath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }
}
