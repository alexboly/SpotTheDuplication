namespace SpotTheDuplication
{
    public class TemperatureConverterTry1
    {
        public static double ConvertFromCelsiusToFahrenheit(double temperature)
        {
            return temperature*1.8 + 32;
        }

        public static  double ConvertFromFahrenheitToCelsius(double temperature)
        {
            return (temperature - 32)/1.8;
        }
    }
}