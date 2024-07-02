using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebForm.Arkes.Bussiness.Abstract;
using WebForm.Arkes.DataAccess;
using WebForm.Arkes.Dtos;
using WebForm.Arkes.Helpers;
using Newtonsoft.Json;

namespace WebForm.Arkes.Bussiness.Concrete
{
    public class GpsLogManager : IGpsLogService
    {
        private readonly StoredProcedureCommand _storedProcedureCommand;
        private readonly StoredProcedureQuery _storedProcedureQuery;
        public GpsLogManager()
        {
            _storedProcedureCommand = new StoredProcedureCommand();
            _storedProcedureQuery = new StoredProcedureQuery();
        }
        public List<Dtos.GpsLogDto> GetLogs()
        {
            var result = _storedProcedureQuery.RunStoredProsedureForListQuery("spGetGpsLogs");
            if (result.IsSuccess)
            {
                var dataTable = (DataTable)result.Data;
                return dataTable.ConvertDataTable<Dtos.GpsLogDto>();
            }

            return null;
        }

        public string GetLiteralString(List<Dtos.GpsLogDto> dtos, int deviceTypeId)
        {
            string result = "";
            List<GpsMarkerDto> markers = new List<GpsMarkerDto>();

            if (dtos.Count > 0)
            {
                foreach (var item in dtos)
                {
                    var type = item.DeviceTypeId;
                    string link;
                    switch (type)
                    {
                        case 1:
                            link = "https://cengizsertkaya.com/group2.png";
                            break;
                        case 2:
                            link = "https://developers.google.com/maps/documentation/javascript/examples/full/images/library_maps.png";
                            break;
                        case 3:
                            link = "https://cengizsertkaya.com/profile.png";
                            break;
                        case 4:
                            link = "https://cengizsertkaya.com/apartments.png";
                            break;
                        default:
                            link = "https://cengizsertkaya.com/profile.png";
                            break;
                    }
                    markers.Add(new GpsMarkerDto()
                    {
                        title = item.FullName + " - " + item.DeviceName,
                        lat = item.Latitude,
                        lng = item.Longitude,
                        description = !string.IsNullOrEmpty(item.Description) ? item.Description : "",
                        link = link
                    });
                }
            }

            string descrption = "infoWindow.setContent(\"<div style = 'width:200px;min-height:40px'>\" + data.description + \"</div>\");";

            var json = JsonConvert.SerializeObject(markers);
            result = @"    <script type='text/javascript'> 

                var markers = " + json + ";";

            result += @"
            var popup = null;

        window.onload = function () {
            LoadMap();
        }
        function LoadMap() {
            var mapOptions = {
                center: new google.maps.LatLng(markers[0].lat, markers[0].lng),
                zoom: 15,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var map = new google.maps.Map(document.getElementById('dvMap'), mapOptions);
     
            var infoWindow = new google.maps.InfoWindow();

            for (var i = 0; i < markers.length; i++) {
                console.log( markers[i]);
                var data = markers[i];
                var myLatlng = new google.maps.LatLng(data.lat, data.lng);
                    var icon = {
                        url: data.link,
                        scaledSize: new google.maps.Size(50, 50)
                    };";

            if (deviceTypeId == 2)
            {
                result += @" new google.maps.Circle({
                    strokeColor: '#FF0000',
                    strokeOpacity: 0.8,
                    strokeWeight: 2,
                    fillColor: '#FF0000',
                    fillOpacity: 0.35,
                    map: map,
                    center: { lat: data.lat, lng: data.lng },
                    radius: 1000 //metre cinsinden yarıcapı
                });";
            }


            result += @"   var marker = new google.maps.Marker({
                    position: myLatlng,
                    map: map,
                    icon: icon,
                    title: data.title
                });
     
                (function (marker, data) {

                    google.maps.event.addListener(marker, 'mouseout', function () {
                        infoWindow.close();
                    });

                    google.maps.event.addListener(marker, 'mousemove', function (event) {
                        // Calculate the distance between the mouse and the marker
                        var distance = google.maps.geometry.spherical.computeDistanceBetween(marker.getPosition(), event.latLng);

                        // If the distance is greater than 50 meters, close the info window
                        if (distance > 50) {
                            infoWindow.close();
                        }
                    });

                    google.maps.event.addListener(marker, 'click', function (e) {
";

            result += descrption;
            result += @" 
                        infoWindow.open(map, marker);
                    });
                })(marker, data);
            }
        }
    </script>";
            return result;
        }


        public List<GpsLogDto> GetLogsByDeviceTypeId(int deviceTypeId)
        {
            var parameter = new List<Dtos.StoredProcedureParameterDto>(){
                new  Dtos.StoredProcedureParameterDto(){
                    Value=deviceTypeId,
                    ParameterName="@deviceTypeId"
                }
            };
            var result = _storedProcedureQuery.RunStoredProsedureForListQueryWithParameter("spGetDevicesGps", parameter);
            if (result.IsSuccess)
            {
                var dataTable = (DataTable)result.Data;
                return dataTable.ConvertDataTable<Dtos.GpsLogDto>();
            }

            return null;
        }


        public Result CreateGpsLog(CreateGpsLogDto dto)
        {
            var parameter = new List<Dtos.StoredProcedureParameterDto>(){
                new  Dtos.StoredProcedureParameterDto(){
                    Value=dto.Lat,
                    ParameterName="@fullName"
                },
                 new  Dtos.StoredProcedureParameterDto(){
                    Value=dto.Lang,
                    ParameterName="@deviceId"
                },
                  new  Dtos.StoredProcedureParameterDto(){
                    Value= dto.DeviceId,
                    ParameterName="@TypeID"
                }
            };

            return _storedProcedureCommand.RunStoredProsedureWithParameter("spCreateUser", parameter);
        }
    }
}