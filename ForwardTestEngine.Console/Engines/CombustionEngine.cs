using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForwardTestEngine.Interfaces;

namespace ForwardTestEngine.Engines
{
    public class CombustionEngine : IEngine
    {
        public double MomentOfInertia => 10;
        public double[] TorqueCurve => new double[] { 20, 75, 100, 105, 75, 0 };
        public double[] SpeedCurve => new double[] { 0, 75, 150, 200, 250, 300 };
        public double OverheatTemperature => 110;
        public double HeatingCoefficientM => 0.01;
        public double HeatingCoefficientV => 0.0001;
        public double CoolingCoefficient => 0.1;
        public string Name => "Combustion Engine";

        public CombustionEngine(){ }
    }
}
