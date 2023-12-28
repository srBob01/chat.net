using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chats.BL.Users.Entities;

public class UpdateUserModel
{
    
    public string? FirstName { get; set; }
    public int? LastName { get; set; }

    public string? Login { get; set; }
    public string? PasswordHash { get; set; }
    
}
