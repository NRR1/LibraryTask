using System;
using System.Collections.Generic;

namespace LibraryTask.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string BookName { get; set; } = null!;

    public int BookPage { get; set; }

    public int BookGenre { get; set; }

    public int BookAuthor { get; set; }

    public virtual Author BookAuthorNavigation { get; set; } = null!;

    public virtual Genre BookGenreNavigation { get; set; } = null!;
}
