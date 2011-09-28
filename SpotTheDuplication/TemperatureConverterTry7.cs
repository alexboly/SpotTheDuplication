using System;

namespace SpotTheDuplication
{
    public class TemperatureConverterTry7
    {
        public class Temperature
        {
            public enum TemperatureUnit
            {
                Celsius,
                Kelvin,
                Fahrenheit
            }

            public double Value { get; private set; }
            public TemperatureUnit Unit { get; private set; }

            public Temperature(double value, TemperatureUnit unit)
            {
                this.Value = value;
                this.Unit = unit;
            }

            public Temperature ConvertTo(TemperatureUnit anotherUnit)
            {
                if(this.Unit == anotherUnit)
                {
                    return this;
                }

                if(this.Unit == TemperatureUnit.Celsius && anotherUnit == TemperatureUnit.Kelvin)
                {
                    return new Temperature(TemperatureConversions.CelsiusToKelvin.Convert(this.Value), anotherUnit);
                }

                if(this.Unit == TemperatureUnit.Celsius && anotherUnit == TemperatureUnit.Fahrenheit)
                {
                    return new Temperature(TemperatureConversions.CelsiusToFahrenheit.Convert(this.Value), anotherUnit);
                }

                if(this.Unit == TemperatureUnit.Kelvin && anotherUnit == TemperatureUnit.Celsius)
                {
                    return new Temperature(TemperatureConversions.CelsiusToKelvin.ConvertBack(this.Value), anotherUnit);
                }

                if (this.Unit == TemperatureUnit.Fahrenheit && anotherUnit == TemperatureUnit.Celsius)
                {
                    return new Temperature(TemperatureConversions.CelsiusToFahrenheit.ConvertBack(this.Value), anotherUnit);
                }

                throw new TemperatureConversionNotSupportedException(
                    String.Format("Cannot convert from {0} to {1}", this.Unit, anotherUnit));
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