using Core.Models;
using Core.Ports.In.Dtos;


namespace Core.Ports.In
{
    /// <summary>
    /// Define las operaciones relacionadas a los usuarios del sistema
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Registra un nuevo usuario en el sistema
        /// </summary>
        /// <param name="userDto">Contiene la informacion basica del usuario a registrar</param>
        /// <returns>Un token de autenticacion JWT</returns>
        Task<string> AddUser(AddUserDto userDto);


        /// <summary>
        /// Loguea un usuario antiguo en el sistema
        /// </summary>
        /// <param name="userLoginDto">Contiene informacion del usuario a logear</param>
        /// <returns>Un token de autenticacion JWT</returns>
        Task<string> LoginUser(LoginUserDto userLoginDto);

    }
}
