using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForm.Arkes.Dtos;

namespace WebForm.Arkes.Bussiness.Abstract
{
    public interface IGpsLogService
    {
        List<GpsLogDto> GetLogs();
        List<GpsLogDto> GetLogsByDeviceTypeId(int deviceTypeId);
        string GetLiteralString(List<Dtos.GpsLogDto> dtos, int deviceTypeId);
        Result CreateGpsLog(CreateGpsLogDto dto);
    }
}
