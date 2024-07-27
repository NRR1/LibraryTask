using System;
using System.Collections.Generic;

namespace LibraryTask.Models;

public partial class Book
{
    public int Id { get; set; }

    public string BookName { get; set; } = null!;

    public int BookPage { get; set; }

    public int GenreId { get; set; }

    public int AuthorId { get; set; }

    public Author? Author { get; set; } 

    public Genre? Genre { get; set; } 
}
