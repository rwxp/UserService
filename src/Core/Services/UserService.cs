using Core.Models;
using Core.Ports.In;
using Core.Ports.In.Dtos;
using Core.Ports.Out.Persistence;

namespace Core.Services
{
    internal sealed class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService;

        public UserService(IUserRepository userRepository, JwtService jwtService)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService));
        }

        public async Task<string> AddUser(AddUserDto userDto)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDto.password);
            var user = new User(Guid.NewGuid(), userDto.email, hashedPassword);
            bool registered = await _userRepository.RegisterUser(user);
            
            if (!registered){
                throw new Exception("Error al registrar el usuario");
            }

            string token = _jwtService.GenerateToken(user.email);
            return token;
        }


        public async Task<string> LoginUser(LoginUserDto userDto)
        {
            var registeredUser = await _userRepository.FindUserByEmail(userDto.email);

            if (registeredUser == null)
            {
                throw new Exception("La informacion ingresada NO es correcta");
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(userDto.password, registeredUser.password);

            if (!isPasswordValid) {
                throw new Exception("La informacion ingresada NO es correcta");
            };

            return _jwtService.GenerateToken(registeredUser.email);
        }

    }
}
