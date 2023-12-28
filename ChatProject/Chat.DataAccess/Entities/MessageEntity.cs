using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.DataAccess.Entities;

[Table("messages")]
public class MessageEntity : BaseEntity
{
    public string Text { get; set; }
    public int UserId { get; set; }
    public virtual UserEntity User { get; set; }
    public int ChatId { get; set; }
    public virtual ChatEntity Chat { get; set; }
}