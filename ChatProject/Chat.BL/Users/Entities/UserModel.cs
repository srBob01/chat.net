using Chat.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chats.BL.Users.Entities;


public class UserModel
{
    
    public required int StudentId { get; set; }
    public required int Name { get; set; }
    public required int Course { get; set; }

    public  required int Login { get; set; }
    public required int PasswordHash { get; set; }
    public virtual ICollection<JoiningEntity> Joinings { get; set; }
}
