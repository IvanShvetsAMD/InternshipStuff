using System;

namespace Domain
{
    class GasCompartmentsNotFoundException : Exception
    {
        public int OriginCompartment { get; set; }
        public int DestinationCompartment { get; set; }

        public GasCompartmentsNotFoundException(){}

        public GasCompartmentsNotFoundException(string message): base(message){}

        public GasCompartmentsNotFoundException(string message, Exception inner): base(message, inner){}

        public GasCompartmentsNotFoundException(string message, int originCompartment,
            int destinationCompartment) : base(message)
        {
            OriginCompartment = originCompartment;
            DestinationCompartment = destinationCompartment;
        }

        public GasCompartmentsNotFoundException(string message, Exception inner, int originCompartment,
            int destinationCompartment) : base(message, inner)
        {
            OriginCompartment = originCompartment;
            DestinationCompartment = destinationCompartment;
        }
    }
}