using AutoMapper;
using Chat.DataAccess.Entities;
using Chats.BL.Chats.Entities;
using Chats.DataAccess;
using Chats.DataAccess.Entities;
using Chats.DataAccess.Repository;

namespace Chats.BL.Chats;

public class ChatManager(IRepository<ChatEntity> chatsRepository, IMapper mapper) : IManager<ChatModel, CreateChatModel>
{
    private readonly IRepository<ChatEntity> _chatsRepository = chatsRepository;
    private readonly IMapper _mapper = mapper;

    public ChatModel Create(CreateChatModel model)
    {
        var entity = _mapper.Map<ChatEntity>(model);

        _chatsRepository.Save(entity);

        return _mapper.Map<ChatModel>(entity);
    }

    public ChatModel Update(Guid id, ChatModel model)
    {
        var chat = Find(id);

        chat.Title = model.Title;
        chat.Description = model.Description;

        _chatsRepository.Save(chat);

        return _mapper.Map<ChatModel>(chat);
    }

    public void Delete(Guid id)
    {
        _chatsRepository.Delete(Find(id));
    }

    private ChatEntity Find(Guid id)
    {
        return _chatsRepository.GetById(id) ?? throw new InvalidOperationException($"Chat with ID {id} not found.");
    }
}
