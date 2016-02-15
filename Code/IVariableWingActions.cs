using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    interface IVariableWingActions
    {
        void DecreaseAngle(float Angle);
        void IncreaseAngle(float Angle);
        void SweepMaxBack();
        void SweepMaxForward();
    }
}
