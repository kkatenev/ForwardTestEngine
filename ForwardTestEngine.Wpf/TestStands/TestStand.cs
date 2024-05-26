using ForwardTestEngine.TestSimulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForwardTestEngine.TestStands
{
    public class TestStand
    {
        public string Name => "TestStand";

        private readonly EngineSimulation _engineSimulation;

        public TestStand(EngineSimulation engineSimulation)
        {
            _engineSimulation = engineSimulation;
        }

        public double TestMaxPower(out double maxPowerSpeed)
        {
            return _engineSimulation.CalculateMaxPower(out maxPowerSpeed);
        }

        async public Task<double> TestOverheat(double ambientTemperature)
        {
            return await _engineSimulation.SimulateEngineTemperature(ambientTemperature, 500);
        }

    }
}
