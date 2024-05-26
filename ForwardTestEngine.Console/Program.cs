using ForwardTestEngine.Engines;
using ForwardTestEngine.TestSimulation;
using ForwardTestEngine.TestStand;

class Program
{
    static void Main(string[] args)
    {
        var engine = new CombustionEngine();

        var engineSimulation = new EngineSimulation(engine);
        var testStand = new TestStand(engineSimulation);

        Console.Write("Enter ambient temperature (in Celsius): ");
        var ambientTemperature = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\nStarting engine simulation...\n");
        var finalTemperature = testStand.TestOverheat(ambientTemperature);
        Console.WriteLine($"\nFinal engine temperature: {finalTemperature}°C");

        Console.WriteLine("\nTesting maximum power...\n");
        var maxPower = testStand.TestMaxPower(out double maxPowerSpeed);
        Console.WriteLine($"Maximum power: {maxPower} kW at {maxPowerSpeed} rad/s");
        while(true) { }
    }
}
