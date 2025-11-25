using System;
using LighthouseSocial.Domain.Common;

namespace LighthouseSocial.Domain.Entities;

public class User : EntityBase
{
    protected User() { }
    public User(string fullName, string email)
    {
        FullName = fullName;
        Email = email;
    }

    public string FullName { get; set; }
    public string Email { get; set; }

    public List<Photo> Photos { get; set; }
    public List<Comment> Comments { get; set; }
}
