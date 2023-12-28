using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chats.BL.Users.Entities;

public class CreateUserModel
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Login { get; set; }
    public required string PasswordHash { get; set; }
}
