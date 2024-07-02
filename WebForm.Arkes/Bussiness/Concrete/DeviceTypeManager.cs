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
    public class DeviceTypeManager : IDeviceTypeService
    {
        private readonly StoredProcedureCommand _storedProcedureCommand;
        private readonly StoredProcedureQuery _storedProcedureQuery;
        public DeviceTypeManager()
        {
            _storedProcedureCommand = new StoredProcedureCommand();
            _storedProcedureQuery = new StoredProcedureQuery();
        }
        public List<Dtos.DeviceTypeDto> GetList()
        {
            var result = _storedProcedureQuery.RunStoredProsedureForListQuery("spGetDeviceTypes");
            if (result.IsSuccess)
            {
                var dataTable = (DataTable)result.Data;
                return dataTable.ConvertDataTable<Dtos.DeviceTypeDto>();
            }

            return null;
        }
    }
}