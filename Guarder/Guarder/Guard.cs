using System;
using System.Linq;

namespace Guarder
{
    public static class Guard
    {
        public struct GuardObject
        {
            public object Parameter;
            public string ParameterName;

            public GuardObject(object param, string paramName)
            {
                Parameter = param;
                ParameterName = paramName;
            }
        }

        public static void NotAnyNull(params GuardObject[] objects)
        {
            foreach (var obj in objects)
            {
                IsNotNull(obj.Parameter,obj.ParameterName);
            }
        }
        public static void IsNotNull(object param, string paramName)
        {
            if (param == null)
                throw new ArgumentException($"{paramName} must not be null");
        }

        public static void IsNumeric(string param, string paramName)
        {
            IsNotNullOrEmpty(param, "param");
            foreach (var c in param.Where(c => !char.IsDigit(c) && c != '.' && c != ','))
            {
                throw new ArgumentException($"{paramName} is not a number Check failed for character {c}");
            }
        }

        public static void IsInt(string param, string paramName)
        {
            int convertedVal;
            if (!int.TryParse(param, out convertedVal))
                throw new ArgumentException($"{paramName} is not an integer");
        }
        public static void IsDouble(string param, string paramName)
        {
            double convertedVal;
            if (!double.TryParse(param, out convertedVal))
                throw new ArgumentException($"{paramName} is not an integer");
        }

        public static void IsNotNullOrEmpty(string param, string paramName)
        {
            if (string.IsNullOrEmpty(param))
                throw new ArgumentException($"{paramName} must not be null or empty");
        }

        public static void LessThan<T>(T value, T maxValue, string paramName) where T : IComparable
        {
            if (value.CompareTo(maxValue) > -1)
                throw new ArgumentException($"{value} is not less than {maxValue}({paramName})");
        }

        public static void LessThanOrEqual<T>(T value, T maxValue, string paramName) where T : IComparable
        {
            if (value.CompareTo(maxValue) > 1)
                throw new ArgumentException($"Value:{value} is less than or equal {maxValue}({paramName})");
        }

        public static void GreaterThanOrEqual<T>(T value, T maxValue, string paramName) where T : IComparable
        {
            if (value.CompareTo(maxValue) < 0)
                throw new ArgumentException($"Value:{value} is greater than or equal {maxValue}({paramName})");
        }

        public static void GreaterThan<T>(T value, T maxValue, string paramName) where T : IComparable
        {
            if (value.CompareTo(maxValue) < 1)
                throw new ArgumentException($"Value:{value} is less than {maxValue}({paramName})");
        }


        public static void ValueIsBetween<T>(T value, T minValue, T maxValue, string paramName) where T : IComparable
        {
            if (value.CompareTo(maxValue) > 0 || value.CompareTo(minValue) < 0)
                throw new ArgumentException($"Value:{value} is not between values {minValue} and {maxValue}({paramName})");
        }
    }
}
