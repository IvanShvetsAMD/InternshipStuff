using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class AicraftInfoAndNumberOfTimesRegisteredDto
    {
        public bool IsOperational { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int MaxTakeoffWeight { get; set; }
        public int Vne { get; set; }
        public string SerialNumber { get; set; }
        public int Count { get; set; }

        public AicraftInfoAndNumberOfTimesRegisteredDto()
        {
            
        }

        public AicraftInfoAndNumberOfTimesRegisteredDto(bool isOperational, string manufacturer, string model, int maxTakeoffWeight, int vne, string serialNumber, int count)
        {
            IsOperational = isOperational;
            Manufacturer = manufacturer;
            Model = model;
            MaxTakeoffWeight = maxTakeoffWeight;
            Vne = vne;
            SerialNumber = serialNumber;
            Count = count;
        }
    }
}