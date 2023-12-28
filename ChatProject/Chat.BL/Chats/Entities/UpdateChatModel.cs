using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chats.BL.Chats.Entities;

internal class UpdateChatModel
{
    public required string? Title { get; set; }
    public required string? Description { get; set; }
}
