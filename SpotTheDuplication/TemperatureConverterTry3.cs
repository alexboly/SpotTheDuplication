namespace SpotTheDuplication
{
    public class TemperatureConverterTry3
    {
        public static double ConvertFromCelsiusToFahrenheit(double temperature)
        {
            return temperature * FahrenheitConversion.Factor + FahrenheitConversion.Origin;
        }

        public static double ConvertFromFahrenheitToCelsius(double temperature)
        {
            return (temperature - FahrenheitConversion.Origin) / FahrenheitConversion.Factor;
        }

        public class FahrenheitConversion
        {
            public const int Origin = 32;
            public const double Factor = 1.8;
        }
    }
}