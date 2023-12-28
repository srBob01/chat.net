using AutoMapper;

using Chats.BL.Users.Entities;
using Chats.DataAccess.Entities;
using Chats.DataAccess.Repository;

namespace Chats.BL.Users;

public class userProvider(IRepository<DebtEntity> usersRepository, IMapper mapper) : IProvider<UserModel, StudentsModelFilter>
{
    private readonly IRepository<DebtEntity> _repository = usersRepository;
    private readonly IMapper _mapper = mapper;

    public IEnumerable<UserModel> Get(StudentsModelFilter? modelFilter)
    {
        string? name = modelFilter?.Name;
        string? email = modelFilter?.email;
        
        var students = _repository.GetAll(student => (
        (name == null || student.Name.Contains(name, StringComparison.OrdinalIgnoreCase)) &&
        (email == null || student.Email.Contains(email, StringComparison.OrdinalIgnoreCase))
        ));

        return _mapper.Map<IEnumerable<UserModel>>(students);
    }

    public UserModel GetInfo(Guid id)
    {
        return _mapper.Map<UserModel>(Find(id));
    }

    private DebtEntity Find(Guid id)
    {
        return _repository.GetById(id) ?? throw new InvalidOperationException($"Student with ID {id} not found.");
    }
}