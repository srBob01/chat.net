using System.ComponentModel.DataAnnotations.Schema;


namespace Chat.DataAccess.Entities;

[Table("joinings")]

public class JoiningEntity : BaseEntity
{
    public int UserId { get; set; }
    public virtual UserEntity User { get; set; }
    public int ChatId { get; set; }
    public virtual ChatEntity Chat { get; set; }
}
