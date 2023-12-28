using AutoMapper;
using Chat.DataAccess.Entities;
using Chats.BL.Users.Entities;
using Chats.DataAccess.Entities;
using Chats.DataAccess.Repository;

namespace Chats.BL.Users;

public class UserManager(IRepository<UserEntity> usersRepository, IMapper mapper) : IManager<UserModel, CreateUserModel>
{
    private readonly IRepository<UserEntity> _usersRepository = usersRepository;
    private readonly IMapper _mapper = mapper;

    public UserModel Create(CreateUserModel model)
    {
        var entity = _mapper.Map<UserEntity>(model);

        _usersRepository.Save(entity);

        return _mapper.Map<UserModel>(entity);
    }

    public UserModel Update(Guid id, UserModel model)
    {
        var student = Find(id);

        student.Name = model.Name;
        student.Course = model.Course;
        student.Login = model.Login;
        student.PasswordHash = model.PasswordHash;
        student.Debts = (ICollection<JoiningEntity>?)model.Joinings;

        _usersRepository.Save(student);

        return _mapper.Map<UserModel>(student);
    }

    public void Delete(Guid id)
    {
        _usersRepository.Delete(Find(id));
    }

    private UserEntity Find(Guid id)
    {
        return _usersRepository.GetById(id) ?? throw new InvalidOperationException($"User with ID {id} not found.");
    }
}
