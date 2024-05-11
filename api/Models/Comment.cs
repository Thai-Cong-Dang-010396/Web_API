﻿using System.ComponentModel.DataAnnotations.Schema;

namespace api;

[Table("Comments")]
public class Comment
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;
    
    public string Content { get; set; } = string.Empty;

    public DateTime CreateOn { get; set; } = DateTime.Now;

    public int? StockID { get; set; }

    public Stock? Stock { get; set; }

    public string AppUserId { get; set; }

    public AppUser AppUser { get; set; }
}
