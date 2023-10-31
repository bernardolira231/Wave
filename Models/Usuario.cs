using System;
using System.Collections.Generic;

namespace Wave.Models;

public partial class Usuario
{
    public int UserId { get; set; }

    public string UserMail { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public byte[]? ProfilePicture { get; set; }

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
