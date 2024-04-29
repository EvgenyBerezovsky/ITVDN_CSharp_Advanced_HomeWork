using System;
using System.Collections;

namespace Task02
{
    public class Year : IEnumerable, IEnumerator, IDisposable
    {
        bool _isLeapYear;
        string[] _monthNames;
        int[] _amountOfDays;
        int _position = -1;

        public Year(bool isLeapYear)
        {
            _isLeapYear = isLeapYear;
            _monthNames = new string[]
            {
                "January", "Fabruary", "March", "April", "May", "June", "July",
                "August", "September", "October", "November", "December"
            };

            if (isLeapYear)
                _amountOfDays = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            else _amountOfDays = new int[] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        }

        object IEnumerator.Current
        {
            get
            {
                return $"{_monthNames[_position]}({_amountOfDays[_position]})";
            }
        }

        public string GetDaysByMonth(int month)
        {
            string result = string.Empty;
            int index;
            for (int i = 0; i < _monthNames.Length; i++)
            {
                index = i + 1;
                if (index == month)
                {
                    return $"{_monthNames[i]}({_amountOfDays[i]})";
                }
            }
            return result;
        }

        internal string GetMonthByDays(int days)
        {
            string result = string.Empty;
            for (int i = 0; i < _amountOfDays.Length; i++)
            {
                if (_amountOfDays[i] == days)
                {
                    result += $"{_monthNames[i]}({_amountOfDays[i]})" + "\n";
                }
            }
            return result;
        }

        void IDisposable.Dispose()
        {
            ((IEnumerator)this).Reset();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        bool IEnumerator.MoveNext()
        {
            if (_position < _monthNames.Length - 1)
            {
                _position++;
                return true;
            }
            ((IEnumerator)this).Reset();
            return false;
        }

        void IEnumerator.Reset()
        {
            _position = -1;
        }
    }
}
