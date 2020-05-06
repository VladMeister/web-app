using AutoMapper;
using ProductTracking.BL.DTO;
using ProductTracking.BL.Services.Interfaces;
using ProductTracking.DAL.Entities;
using ProductTracking.DAL.UnitOfWork;
using System.Collections.Generic;

namespace ProductTracking.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void RegisterUser(UserDto userDTO)
        {
            var user = new User()
            {
                //Id = userDTO.Id,
                Login = userDTO.Login,
                Password = PasswordHasher.HeshedPassword(userDTO.Password),
                Role = _unitOfWork.RoleRepository.GetByName(userDTO.RoleName)
            };

            _unitOfWork.UserRepository.Add(user);
            _unitOfWork.Save();
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>()
                .ForMember(u => u.RoleName, opt => opt.MapFrom(src => src.Role.Name));
            }).CreateMapper();

            return mapper.Map<IEnumerable<User>, List<UserDto>>(_unitOfWork.UserRepository.GetAll());
        }

        public void UpdateUser(UserDto userDTO)
        {
            var user = _mapper.Map<UserDto, User>(userDTO);

            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Save();
        }

        public void DeleteUser(UserDto userDTO)
        {
            var user = _mapper.Map<UserDto, User>(userDTO);

            _unitOfWork.UserRepository.Delete(user);
            _unitOfWork.Save();
        }

        public bool ExistingUser(string login, string password)
        {
            return _unitOfWork.UserRepository.Existing(login, PasswordHasher.HeshedPassword(password));
        }

        public string[] GetUserRolesNames()
        {
            return _unitOfWork.RoleRepository.GetNames();
        }

        public string GetUserRole(string userLogin)
        {
            return _unitOfWork.UserRepository.GetRole(userLogin);
        }

        public UserDto GetUserById(int? id)
        {
            var userDTO = _mapper.Map<User, UserDto>(_unitOfWork.UserRepository.GetById(id));

            return userDTO;
        }

        public UserDto GetUserByLogin(string userLogin)
        {
            var userDTO = _mapper.Map<User, UserDto>(_unitOfWork.UserRepository.GetByLogin(userLogin));

            return userDTO;
        }
    }
}
