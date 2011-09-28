namespace SpotTheDuplication
{
    public class TemperatureConverterTry6
    {
        private readonly LinearConversion fahrenheitConversion;
        private readonly LinearConversion kelvinConversion;

        public TemperatureConverterTry6()
        {
            this.fahrenheitConversion = TemperatureConversions.CelsiusToFahrenheit;
            this.kelvinConversion = TemperatureConversions.CelsiusToKelvin;
        }

        public double ConvertFromCelsiusToFahrenheit(double temperature)
        {
            return fahrenheitConversion.Convert(temperature);
        }

        public double ConvertFromFahrenheitToCelsius(double temperature)
        {
            return fahrenheitConversion.ConvertBack(temperature);
        }

        public double ConvertFromCelsiusToKelvin(double temperature)
        {
            return kelvinConversion.Convert(temperature);
        }

        public double ConvertFromKelvinToCelsius(double temperature)
        {
            return kelvinConversion.ConvertBack(temperature);
        }

        public class LinearConversion
        {
            public double Origin { get; private set; }
            public double Factor { get; private set; }

            public LinearConversion(double origin, double factor)
            {
                this.Origin = origin;
                this.Factor = factor;
            }

            public double Convert(double value)
            {
                return value*Factor + Origin;
            }

            public double ConvertBack(double value)
            {
                return (value - Origin)/Factor;
            }
        }

        public class TemperatureConversions
        {
            public static LinearConversion CelsiusToFahrenheit
            {
                get
                {
                    return new LinearConversion(32, 1.8);
                }
            }

            public static LinearConversion CelsiusToKelvin
            {
                get
                {
                    return new LinearConversion(-273.15, 1);
                }
            }
        }
   }
}