using ForwardTestEngine.Interfaces;
using ForwardTestEngine.TestSimulation;
using ForwardTestEngine.TestStands;
using ForwardTestEngine.Wpf.Other;
using ForwardTestEngine.Wpf.Panels;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace ForwardTestEngine.Wpf
{
    public class ForwardTestEngineModel
    {
        async public Task StartTest(TestStand testStand)
        {
            var ambientTemperature = GetInputFromUser("Enter ambient temperature:");

            if (ambientTemperature == null)
            {
                return;
            }

            Log.Add("\nStarting engine simulation...\n");
            var finalTemperature = await testStand.TestOverheat(ambientTemperature.Value);
            Log.Add($"\nFinal engine temperature: {Math.Round(finalTemperature, 3)}°C");

            Log.Add("\nTesting maximum power...\n");
            var maxPower = testStand.TestMaxPower(out double maxPowerSpeed);
            Log.Add($"Maximum power: {maxPower} kW at {maxPowerSpeed} rad/s");
        }

        private double? GetInputFromUser(string message)
        {
            var dialog = new InputDialogWindow(message);
            var result = dialog.ShowDialog();

            if (result == true)
                return dialog.InputValue;
            else
                return null;
        }
    }
}