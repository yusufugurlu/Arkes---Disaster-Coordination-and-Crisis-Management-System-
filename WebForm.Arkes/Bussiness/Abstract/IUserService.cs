using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForm.Arkes.Dtos;

namespace WebForm.Arkes.Bussiness.Abstract
{
    public interface IUserService
    {
        List<UserDto> GetUsers();
        UserDto GetUserById(int id);
        Result UpdateUser(UpdateUserDto updatedDevice);
        Result CreateUser(CreateUserDto createDeviceDto);
    }
}
