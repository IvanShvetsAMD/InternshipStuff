using System;

namespace Domain.Dto
{
    public class AicraftInfoAndDateOfRegistrationDto
    {
        public bool IsOperational { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int MaxTakeoffWeight { get; set; }
        public int Vne { get; set; }
        public string SerialNumber { get; set; }
        public DateTime RegistryDate { get; set; }

        public AicraftInfoAndDateOfRegistrationDto()
        {

        }

        public AicraftInfoAndDateOfRegistrationDto(bool isOperational, string manufacturer, string model, int maxTakeoffWeight, int vne, string serialNumber, DateTime count)
        {
            IsOperational = isOperational;
            Manufacturer = manufacturer;
            Model = model;
            MaxTakeoffWeight = maxTakeoffWeight;
            Vne = vne;
            SerialNumber = serialNumber;
            RegistryDate = count;
        }
    }
}