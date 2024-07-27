using System;
using System.Collections.Generic;

namespace LibraryTask.Models;

public partial class Author
{
    public int AutId { get; set; }

    public string AutName { get; set; } = null!;

    public string AutSurname { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
