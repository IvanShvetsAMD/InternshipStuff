using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Code
{
    class PoweredAircraftFactory
    {
        static readonly Lazy<PoweredAircraftFactory> LazyInstance = new Lazy<PoweredAircraftFactory>(() => new PoweredAircraftFactory(), LazyThreadSafetyMode.ExecutionAndPublication);
        
        
    }
}
