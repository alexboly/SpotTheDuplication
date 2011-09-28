namespace SpotTheDuplication
{
    public class TemperatureConverterTry5
    {
        private readonly FahrenheitConversion fahrenheitConversion;
        private readonly KelvinConversion kelvinConversion;

        public TemperatureConverterTry5(FahrenheitConversion conversion, KelvinConversion kelvinConversion)
        {
            this.fahrenheitConversion = conversion;
            this.kelvinConversion = kelvinConversion;
        }

        public double ConvertFromCelsiusToFahrenheit(double temperature)
        {
            return temperature * fahrenheitConversion.Factor + fahrenheitConversion.Origin;
        }

        public double ConvertFromFahrenheitToCelsius(double temperature)
        {
            return (temperature - fahrenheitConversion.Origin) / fahrenheitConversion.Factor;
        }

        public double ConvertFromCelsiusToKelvin(double temperature)
        {
            return temperature + kelvinConversion.Origin;
        }

        public double ConvertFromKelvinToCelsius(double  temperature)
        {
            return temperature - kelvinConversion.Origin;
        }

        public class FahrenheitConversion
        {
            public int Origin = 32;
            public double Factor = 1.8;
        }
        public class KelvinConversion
        {
            public double Origin = -273.15;
        }
    }
}
