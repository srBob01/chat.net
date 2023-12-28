using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.DataAccess.Entities;

[Table("admins")]
public class AdminEntity : BaseEntity
{
    public string PasswordHash { get; set; }
    public string Login { get; set; }
}
