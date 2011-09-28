using System;
using System.Collections.Generic;
using System.Linq;

namespace SpotTheDuplication
{
    public class TemperatureConverterTry9
    {
            public enum TemperatureUnit
            {
                Celsius,
                Kelvin,
                Fahrenheit
            }

        public class Temperature
        {
            private readonly TemperatureConversions temperatureConversions;
            
            public double Value { get; private set; }
            public TemperatureUnit Unit { get; private set; }

            public Temperature(double value, TemperatureUnit unit)
            {
                this.Value = value;
                this.Unit = unit;
                temperatureConversions = new TemperatureConversions();
            }

            public Temperature ConvertTo(TemperatureUnit anotherUnit)
            {
                if (this.Unit == anotherUnit)
                {
                    return this;
                }

                LinearConversion conversion = temperatureConversions.GetConverter(this.Unit, anotherUnit);

                if (conversion == null)
                {
                    throw new TemperatureConversionNotSupportedException(
                        String.Format("Cannot convert from {0} to {1}", this.Unit, anotherUnit));
                }

                return new Temperature(conversion.Convert(this.Value), anotherUnit);
            }
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
                return value * Factor + Origin;
            }

            public double ConvertBack(double value)
            {
                return (value - Origin) / Factor;
            }
        }

        public class TemperatureConversions
        {
            private readonly LinearConversion celsiusToFahrenheitConversion = new LinearConversion(32, 1.8);
            private readonly LinearConversion celsiusToKelvinConversion = new LinearConversion(-273.15, 1);

            private readonly KeyValuePair<TemperatureUnit, TemperatureUnit> celsiusToKelvinPair =
               new KeyValuePair<TemperatureUnit, TemperatureUnit>(TemperatureUnit.Celsius, TemperatureUnit.Kelvin);
            private readonly KeyValuePair<TemperatureUnit, TemperatureUnit> celsiusToFahrenheitPair =
                new KeyValuePair<TemperatureUnit, TemperatureUnit>(TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit);

            private readonly Dictionary<KeyValuePair<TemperatureUnit, TemperatureUnit>, LinearConversion> conversions;

            public TemperatureConversions()
            {
                conversions = new Dictionary
                    <KeyValuePair<TemperatureUnit, TemperatureUnit>, LinearConversion>
                                  {
                                      {celsiusToKelvinPair, celsiusToKelvinConversion},
                                      {celsiusToFahrenheitPair, celsiusToFahrenheitConversion}
                                  };
            }

            public LinearConversion GetConverter(TemperatureUnit from, TemperatureUnit to)
            {
                return conversions.SingleOrDefault(p => p.Key.Key == from && p.Key.Value == to).Value;
            }
        }

        public class TemperatureConversionNotSupportedException : Exception
        {
            public TemperatureConversionNotSupportedException(string message) :
                base(message)
            {
            }
        }
    }
}