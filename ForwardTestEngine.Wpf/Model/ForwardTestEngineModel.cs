using ForwardTestEngine.Interfaces;
using ForwardTestEngine.TestSimulation;
using ForwardTestEngine.TestStands;
using ForwardTestEngine.Wpf.Panels;
using System;
using System.Windows;

namespace ForwardTestEngine.Wpf
{
    public class ForwardTestEngineModel
    {
        public void StartTest(TestStand testStand)
        {
            var ambientTemperature = GetInputFromUser("Enter ambient temperature:");

            if (ambientTemperature == null)
            {
                return;
            }

            Console.WriteLine("\nStarting engine simulation...\n");
            var finalTemperature = testStand.TestOverheat(ambientTemperature.Value);
            Console.WriteLine($"\nFinal engine temperature: {finalTemperature}°C");

            Console.WriteLine("\nTesting maximum power...\n");
            var maxPower = testStand.TestMaxPower(out double maxPowerSpeed);
            Console.WriteLine($"Maximum power: {maxPower} kW at {maxPowerSpeed} rad/s");
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