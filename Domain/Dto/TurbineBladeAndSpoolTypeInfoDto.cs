using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto
{
    public class TurbineBladeAndSpoolTypeInfoDto
    {
        public long TubineBladeID { get; set; }
        public long ParentSpoolID { get; set; }
        public long Length { get; set; }
        public string MaterialType { get; set; }
        public long MaxTemp { get; set; }
        public bool HasCoolingChannels { get; set; }
        public long Chord { get; set; }
        public string SpoolType { get; set; }

        public TurbineBladeAndSpoolTypeInfoDto()
        {
            
        }
    }
}