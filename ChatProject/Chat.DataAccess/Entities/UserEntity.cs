using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.DataAccess.Entities;

[Table("users")]
public class UserEntity : BaseEntity
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Patronymic { get; set; }
    public string PasswordHash { get; set; }
    public string Login { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime Birthday { get; set; }
    public ICollection<MessageEntity> Messages { get; set; }
    public ICollection<JoiningEntity> Joinings { get; set; }

}