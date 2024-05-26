using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForwardTestEngine.Interfaces
{
    public interface IEngine
    {
        double MomentOfInertia { get; }
        double[] TorqueCurve { get; }
        double[] SpeedCurve { get; }
        double OverheatTemperature { get; }
        double HeatingCoefficientM { get; }
        double HeatingCoefficientV { get; }
        double CoolingCoefficient { get; }
    }
}
