using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationContentApp.Models;
public class ContentItem
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }
    public DateTime CreatedDate { get; set; }
}
