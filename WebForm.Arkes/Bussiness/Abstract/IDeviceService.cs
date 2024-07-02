using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebForm.Arkes.Dtos;

namespace WebForm.Arkes.Bussiness.Abstract
{
    public interface IDeviceService
    {
        List<DeviceDto> GetDevices();
        DeviceDto GetDeviceById(int id);
        Result UpdateDevice(UpdatedDeviceDto updatedDevice);
        Result CreateDevice(CreateDeviceDto createDeviceDto);
    }
}
