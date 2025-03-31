using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ports.In.Dtos
{
    public sealed record class AddUserDto(string email, string password) { 
    }
    public sealed record class LoginUserDto(string email, string password)
    {
    }

}
