using System;
using System.Collections.Generic;

namespace LibraryTask.Models;

public partial class Author
{
    public int Id { get; set; }

    public string AutName { get; set; } = null!;

    public string AutSurname { get; set; } = null!;

}
