using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    class GasCompartmentsNotFoundException : Exception
    {
        public uint OriginCompartment { get; set; }
        public uint DestinationCompartment { get; set; }

        public GasCompartmentsNotFoundException(){}

        public GasCompartmentsNotFoundException(string message): base(message){}

        public GasCompartmentsNotFoundException(string message, Exception inner): base(message, inner){}

        public GasCompartmentsNotFoundException(string message, uint originCompartment,
            uint destinationCompartment) : base(message)
        {
            OriginCompartment = originCompartment;
            DestinationCompartment = destinationCompartment;
        }

        public GasCompartmentsNotFoundException(string message, Exception inner, uint originCompartment,
            uint destinationCompartment) : base(message, inner)
        {
            OriginCompartment = originCompartment;
            DestinationCompartment = destinationCompartment;
        }
    }
}