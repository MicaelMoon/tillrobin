using System;
using System.Collections.Generic;

namespace Databaser_Labb_2.Models;

public partial class MediaType
{
    public int MediaTypeId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
