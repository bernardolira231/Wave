using System;
using System.Collections.Generic;

namespace Wave.Models;

public partial class Post
{
    public int PostId { get; set; }

    public int UserId { get; set; }

    public int Likes { get; set; }

    public DateTime PublicationDate { get; set; }

    public bool? IsDeleted { get; set; }

    public string Content { get; set; } = null!;

    public string? Caption { get; set; }

    public virtual Usuario User { get; set; } = null!;
}
