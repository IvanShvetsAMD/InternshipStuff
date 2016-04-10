using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class AicraftInfoAndIfRegisteredBoolDto
    {
        public bool IsOperational { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int MaxTakeoffWeight { get; set; }
        public int Vne { get; set; }
        public string SerialNumber { get; set; }
        public bool IsRegistered { get; set; }

        public AicraftInfoAndIfRegisteredBoolDto()
        {
            
        }
    }
}