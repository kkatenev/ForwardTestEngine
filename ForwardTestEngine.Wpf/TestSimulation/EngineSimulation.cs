using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ForwardTestEngine.Interfaces;

namespace ForwardTestEngine.TestSimulation
{
    public class EngineSimulation
    {
        private readonly IEngine _engine;

        public EngineSimulation(IEngine engine)
        {
            _engine = engine;
        }

        async public Task<double> SimulateEngineTemperature(double ambientTemperature, int delay = 0)
        {
            double engineTemperature = ambientTemperature;
            double velocity = 0;

            for (int i = 0; i < _engine.TorqueCurve.Length; i++)
            {
                double acceleration = _engine.TorqueCurve[i] / _engine.MomentOfInertia;
                velocity += acceleration;
                double heatingRate = _engine.HeatingCoefficientM * _engine.TorqueCurve[i] + Math.Pow(velocity, 2) * _engine.HeatingCoefficientV;
                double coolingRate = _engine.CoolingCoefficient * (ambientTemperature - engineTemperature);

                engineTemperature += (heatingRate - coolingRate);
                
                Console.WriteLine($"Time: {i}, Engine Temperature: {engineTemperature}");

                if (engineTemperature >= _engine.OverheatTemperature)
                {
                    Console.WriteLine($"Engine overheated at time {i}");
                    break;
                }
                await Task.Delay(delay);
            }

            return engineTemperature;
        }

        public double CalculateMaxPower(out double maxPowerSpeed)
        {
            double maxPower = 0;
            maxPowerSpeed = 0;

            for (int i = 0; i < _engine.TorqueCurve.Length; i++)
            {
                double power = _engine.TorqueCurve[i] * _engine.SpeedCurve[i] / 1000;
                if (power > maxPower)
                {
                    maxPower = power;
                    maxPowerSpeed = _engine.SpeedCurve[i];
                }
            }

            return maxPower;
        }
    }
}
