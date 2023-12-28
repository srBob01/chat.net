using AutoMapper;
using Chat.DataAccess.Entities;
using Chats.BL.Chats.Entities;
using Chats.DataAccess;
using Chats.DataAccess.Entities;
using Chats.DataAccess.Repository;

namespace Chats.BL.Chats;

public class ChatProvider(IRepository<ChatEntity> charsRepository, IMapper mapper) : IProvider<ChatModel, ChatModelFilter>
{
    private readonly IRepository<ChatEntity> _repository = charsRepository;
    private readonly IMapper _mapper = mapper;

    public IEnumerable<ChatModel> Get(ChatModelFilter? modelFilter)
    {
        String? title = modelFilter?.Title;
        

        var chats = _repository.GetAll(chat => (
        (Title == null )));

        return _mapper.Map<IEnumerable<ChatModel>>(chats);
    }

    public ChatModel GetInfo(Guid id)
    {
        return _mapper.Map<ChatModel>(Find(id));
    }

    private ChatEntity Find(Guid id)
    {
        return _repository.GetById(id) ?? throw new InvalidOperationException($"Chat with ID {id} not found.");
    }
}