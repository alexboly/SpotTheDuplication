namespace SpotTheDuplication
{
    public class TemperatureConverterTry4
    {
        private readonly FahrenheitConversion fahrenheitConversion;

        public TemperatureConverterTry4(FahrenheitConversion conversion)
        {
            this.fahrenheitConversion = conversion;
        }

        public double ConvertFromCelsiusToFahrenheit(double temperature)
        {
            return temperature * fahrenheitConversion.Factor + fahrenheitConversion.Origin;
        }

        public double ConvertFromFahrenheitToCelsius(double temperature)
        {
            return (temperature - fahrenheitConversion.Origin) / fahrenheitConversion.Factor;
        }

        public class FahrenheitConversion
        {
            public int Origin = 32;
            public double Factor = 1.8;
        }
    }
}