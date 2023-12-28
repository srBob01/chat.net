using System.ComponentModel.DataAnnotations.Schema;


namespace Chat.DataAccess.Entities;

[Table("chats")]
public class ChatEntity : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public ICollection<MessageEntity> Messages { get; set; }
    public ICollection<JoiningEntity> Joinings { get; set; }
}
