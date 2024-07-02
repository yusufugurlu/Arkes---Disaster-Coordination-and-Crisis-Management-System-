using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebForm.Arkes.Bussiness.Abstract;
using WebForm.Arkes.DataAccess;
using WebForm.Arkes.Helpers;

namespace WebForm.Arkes.Bussiness.Concrete
{
    public class UserManager : IUserService
    {
        private readonly StoredProcedureCommand _storedProcedureCommand;
        private readonly StoredProcedureQuery _storedProcedureQuery;
        public UserManager()
        {
            _storedProcedureCommand = new StoredProcedureCommand();
            _storedProcedureQuery = new StoredProcedureQuery();
        }
        public List<Dtos.UserDto> GetUsers()
        {
            var result = _storedProcedureQuery.RunStoredProsedureForListQuery("spGetUsers");
            if (result.IsSuccess)
            {
                var dataTable = (DataTable)result.Data;
                return dataTable.ConvertDataTable<Dtos.UserDto>();
            }

            return null;
        }

        public Dtos.UserDto GetUserById(int id)
        {
            var parameter = new List<Dtos.StoredProcedureParameterDto>(){
                new  Dtos.StoredProcedureParameterDto(){
                    Value=id,
                    ParameterName="@userId"
                }
            };
            var result = _storedProcedureQuery.RunStoredProsedureForListQueryWithParameter("spGetUserById", parameter);
            if (result.IsSuccess)
            {
                var dataTable = (DataTable)result.Data;
                var list = dataTable.ConvertDataTable<Dtos.UserDto>();
                if (list.Count > 0)
                {
                    return list.FirstOrDefault();
                }

            }
            return null;
        }

        public Dtos.Result UpdateUser(Dtos.UpdateUserDto updatedDevice)
        {
            var parameter = new List<Dtos.StoredProcedureParameterDto>(){
                new  Dtos.StoredProcedureParameterDto(){
                    Value=updatedDevice.FullName,
                    ParameterName="@fullName"
                },
                 new  Dtos.StoredProcedureParameterDto(){
                    Value=updatedDevice.DeviceId,
                    ParameterName="@deviceId"
                },
                  new  Dtos.StoredProcedureParameterDto(){
                    Value=updatedDevice.Id,
                    ParameterName="@id"
                }
            };

            return _storedProcedureCommand.RunStoredProsedureWithParameter("spUpdateUser", parameter);
        }

        public Dtos.Result CreateUser(Dtos.CreateUserDto createDeviceDto)
        {
            var parameter = new List<Dtos.StoredProcedureParameterDto>(){
                new  Dtos.StoredProcedureParameterDto(){
                    Value=createDeviceDto.FullName,
                    ParameterName="@fullName"
                },
                 new  Dtos.StoredProcedureParameterDto(){
                    Value=createDeviceDto.DeviceID,
                    ParameterName="@deviceId"
                },
                  new  Dtos.StoredProcedureParameterDto(){
                    Value= (int)WebForm.Arkes.Helpers.Enums.UserType.User,
                    ParameterName="@TypeID"
                }
            };

            return _storedProcedureCommand.RunStoredProsedureWithParameter("spCreateUser", parameter);
        }
    }
}