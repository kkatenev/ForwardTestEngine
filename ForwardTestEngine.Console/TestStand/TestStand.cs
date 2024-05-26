using ForwardTestEngine.TestSimulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForwardTestEngine.TestStand
{
    public class TestStand
    {
        private readonly EngineSimulation _engineSimulation;

        public TestStand(EngineSimulation engineSimulation)
        {
            _engineSimulation = engineSimulation;
        }

        public double TestMaxPower(out double maxPowerSpeed)
        {
            return _engineSimulation.CalculateMaxPower(out maxPowerSpeed);
        }

        public double TestOverheat(double ambientTemperature)
        {
            return _engineSimulation.SimulateEngineTemperature(ambientTemperature, 500);
        }
    }
}
