using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebForm.Arkes.Bussiness.Abstract;
using WebForm.Arkes.DataAccess;
using WebForm.Arkes.Dtos;
using WebForm.Arkes.Helpers;
namespace WebForm.Arkes.Bussiness.Concrete
{
    public class DeviceManager : IDeviceService
    {
        private readonly StoredProcedureCommand _storedProcedureCommand;
        private readonly StoredProcedureQuery _storedProcedureQuery;
        public DeviceManager()
        {
            _storedProcedureCommand = new StoredProcedureCommand();
            _storedProcedureQuery = new StoredProcedureQuery();
        }
        public List<Dtos.DeviceDto> GetDevices()
        {
            var result = _storedProcedureQuery.RunStoredProsedureForListQuery("spGetDevices");
            if (result.IsSuccess)
            {
                var dataTable = (DataTable)result.Data;
                return dataTable.ConvertDataTable<Dtos.DeviceDto>();
            }

            return null;
        }

        public Dtos.DeviceDto GetDeviceById(int id)
        {
            var parameter = new List<Dtos.StoredProcedureParameterDto>(){
                new  Dtos.StoredProcedureParameterDto(){
                    Value=id,
                    ParameterName="@deviceId"
                }
            };
            var result = _storedProcedureQuery.RunStoredProsedureForListQueryWithParameter("spGetDeviceById", parameter);
            if (result.IsSuccess)
            {
                var dataTable = (DataTable)result.Data;
                var list = dataTable.ConvertDataTable<Dtos.DeviceDto>();
                if (list.Count > 0)
                {
                    return list.FirstOrDefault();
                }

            }
            return null;
        }

        public Dtos.Result UpdateDevice(Dtos.UpdatedDeviceDto updatedDevice)
        {
            var parameter = new List<Dtos.StoredProcedureParameterDto>(){
                new  Dtos.StoredProcedureParameterDto(){
                    Value=updatedDevice.Name,
                    ParameterName="@name"
                },
                 new  Dtos.StoredProcedureParameterDto(){
                    Value=updatedDevice.TypeId,
                    ParameterName="@typeId"
                },
                  new  Dtos.StoredProcedureParameterDto(){
                    Value=updatedDevice.ID,
                    ParameterName="@id"
                },
                   new  Dtos.StoredProcedureParameterDto(){
                    Value=updatedDevice.Address,
                    ParameterName="@address"
                },
                    new  Dtos.StoredProcedureParameterDto(){
                    Value=updatedDevice.City,
                    ParameterName="@city"
                },
                   new  Dtos.StoredProcedureParameterDto(){
                    Value=updatedDevice.Code,
                    ParameterName="@code"
                }
            };

            return _storedProcedureCommand.RunStoredProsedureWithParameter("spUpdateDevice", parameter);
        }

        public Dtos.Result CreateDevice(Dtos.CreateDeviceDto createDeviceDto)
        {
            var parameter = new List<Dtos.StoredProcedureParameterDto>(){
                new  Dtos.StoredProcedureParameterDto(){
                    Value=createDeviceDto.Name,
                    ParameterName="@name"
                },
                 new  Dtos.StoredProcedureParameterDto(){
                    Value=createDeviceDto.TypeId,
                    ParameterName="@typeId"
                },
                   new  Dtos.StoredProcedureParameterDto(){
                    Value=createDeviceDto.Address,
                    ParameterName="@address"
                },
                  new  Dtos.StoredProcedureParameterDto(){
                    Value=createDeviceDto.City,
                    ParameterName="@city"
                },
                   new  Dtos.StoredProcedureParameterDto(){
                    Value=createDeviceDto.Id,
                    ParameterName="@id"
                }
            };

            return _storedProcedureCommand.RunStoredProsedureWithParameter("spCreateDevice", parameter);
        }
    }
}