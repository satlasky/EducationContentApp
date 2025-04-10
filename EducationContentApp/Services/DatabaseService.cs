using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationContentApp.Models;

namespace EducationContentApp.Services;
public class DatabaseService
{
    private readonly AppDbContext _context;

    public DatabaseService()
    {
        _context = new AppDbContext();
        _context.Database.EnsureCreated();
        SeedData();
    }

    public List<ContentItem> GetContentItems() => _context.ContentItems.ToList();
    public void AddContentItem(ContentItem item)
    {
        _context.ContentItems.Add(item);
        _context.SaveChanges();
    }

    private void SeedData()
    {
        if (!_context.ContentItems.Any())
        {
            _context.ContentItems.AddRange(
                new ContentItem { Title = "Тема 1: Основы", Text = "Текст первой темы...", CreatedDate = DateTime.Now },
                new ContentItem { Title = "Тема 2: Практика", Text = "Текст второй темы...", CreatedDate = DateTime.Now }
            );
            _context.SaveChanges();
        }
    }
}
