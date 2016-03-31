using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class TurbineBladeCountDifferentiateOnCoolingChannelsDto
    {
        public int Count { get; set; }
        public bool HasCoolingChannels { get; set; }

        public TurbineBladeCountDifferentiateOnCoolingChannelsDto()
        {
            
        }
    }
}