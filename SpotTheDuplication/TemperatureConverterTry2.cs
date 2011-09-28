namespace SpotTheDuplication
{
    public class TemperatureConverterTry2
    {
        private const int FAHRENHEIT_ORIGIN = 32;
        private const double FAHRENHEIT_FACTOR = 1.8;

        public static double ConvertFromCelsiusToFahrenheit(double temperature)
        {
            return temperature * FAHRENHEIT_FACTOR + FAHRENHEIT_ORIGIN;
        }

        public static double ConvertFromFahrenheitToCelsius(double temperature)
        {
            return (temperature - FAHRENHEIT_ORIGIN) / FAHRENHEIT_FACTOR;
        }
    }
}