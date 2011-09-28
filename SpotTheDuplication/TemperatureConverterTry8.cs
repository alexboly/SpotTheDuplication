using System;
using System.Collections.Generic;
using System.Linq;

namespace SpotTheDuplication
{
    public class TemperatureConverterTry8
    {
        public class Temperature
        {
            public enum TemperatureUnit
            {
                Celsius,
                Kelvin,
                Fahrenheit
            }

            private static readonly KeyValuePair<TemperatureUnit, TemperatureUnit> CelsiusToKelvin =
                new KeyValuePair<TemperatureUnit, TemperatureUnit>(TemperatureUnit.Celsius, TemperatureUnit.Kelvin);
            private static readonly KeyValuePair<TemperatureUnit, TemperatureUnit> CelsiusToFahrenheit =
                new KeyValuePair<TemperatureUnit, TemperatureUnit>(TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit);

            private readonly Dictionary<KeyValuePair<TemperatureUnit, TemperatureUnit>, LinearConversion> conversions = new Dictionary
                <KeyValuePair<TemperatureUnit, TemperatureUnit>, LinearConversion>
               {
                   {CelsiusToKelvin, TemperatureConversions.CelsiusToKelvin},
                   {CelsiusToFahrenheit, TemperatureConversions.CelsiusToFahrenheit}
               };

            public double Value { get; private set; }
            public TemperatureUnit Unit { get; private set; }

            public Temperature(double value, TemperatureUnit unit)
            {
                this.Value = value;
                this.Unit = unit;
            }

            public Temperature ConvertTo(TemperatureUnit anotherUnit)
            {
                if (this.Unit == anotherUnit)
                {
                    return this;
                }

                LinearConversion conversion =
                    conversions.SingleOrDefault(p => p.Key.Key == this.Unit && p.Key.Value == anotherUnit).Value;

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

        public class TemperatureConversionNotSupportedException : Exception
        {
            public TemperatureConversionNotSupportedException(string message) :
                base(message)
            {
            }
        }
    }
}