using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureConverter
{
    //  Задание 2
    //  Создайте свою пользовательскую сборку по примеру сборки CarLibrary из урока, сборка будет
    //  использоваться для работы с конвертером температуры.
    internal class Temperature : IFormattable
    {
        private decimal _temperature;

        public Temperature(decimal temperature)
        {
            if (temperature < -273.15m)
            {
                // По шкале Цельсия абсолютному нулю соответствует температура −273,15 °C
                throw new ArgumentOutOfRangeException(
                    String.Format("{0} is less than absolute zero.", temperature));
            }
            _temperature = temperature;
        }

        public decimal Celsius
        {
            get { return _temperature; }
        }

        public decimal Fahrenheit
        {
            // Перевод Цельсия в Фаренгейт.
            get { return _temperature * 9 / 5 + 32; }
        }

        public decimal Kelvin
        {
            // Перевод Цельсия в Кельвин.
            get { return _temperature + 273.15m; }
        }
        public override string ToString()
        {
            return this.ToString("G", CultureInfo.CurrentCulture);
        }

        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
        }

        // Реализация IFormattable.
        public string ToString(string? format, IFormatProvider? provider)
        {
            if (String.IsNullOrEmpty(format))
                format = "G";

            if (provider == null)
                provider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "G":
                case "C":
                    // F2 - формат вывода вещественного числа (2 знака после запятой).
                    return _temperature.ToString("F2", provider) + " °C";
                case "F":
                    return Fahrenheit.ToString("F2", provider) + " °F";
                case "K":
                    return Kelvin.ToString("F2", provider) + " K";
                default:
                    throw new FormatException(
                        String.Format("The {0} format string is not supported.", format));
            }
        }
    }
}
