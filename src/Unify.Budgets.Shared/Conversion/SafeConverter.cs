namespace Unify.Budgets.Shared.Conversion
{
    using System;
    using System.Globalization;

    namespace Infra.Conversao
    {
        public static class SafeConverter
        {
            private static readonly CultureInfo _culture = CultureInfo.InvariantCulture;

            public static int ToInt(object value)
            {
                if (value == null || value == DBNull.Value)
                    return 0;

                try
                {
                    if (value is int i) return i;

                    if (int.TryParse(value.ToString(), NumberStyles.Any, _culture, out int result))
                        return result;

                    return Convert.ToInt32(value, _culture);
                }
                catch
                {
                    return 0;
                }
            }

            public static long ToLong(object value)
            {
                if (value == null || value == DBNull.Value)
                    return 0L;

                try
                {
                    if (value is long l) return l;

                    if (long.TryParse(value.ToString(), NumberStyles.Any, _culture, out long result))
                        return result;

                    return Convert.ToInt64(value, _culture);
                }
                catch
                {
                    return 0L;
                }
            }

            public static decimal ToDecimal(object value)
            {
                if (value == null || value == DBNull.Value)
                    return 0m;

                try
                {
                    if (value is decimal d) return d;

                    if (decimal.TryParse(value.ToString(), NumberStyles.Any, _culture, out decimal result))
                        return result;

                    return Convert.ToDecimal(value, _culture);
                }
                catch
                {
                    return 0m;
                }
            }

            public static double ToDouble(object value)
            {
                if (value == null || value == DBNull.Value)
                    return 0d;

                try
                {
                    if (value is double d) return d;

                    if (double.TryParse(value.ToString(), NumberStyles.Any, _culture, out double result))
                        return result;

                    return Convert.ToDouble(value, _culture);
                }
                catch
                {
                    return 0d;
                }
            }

            public static float ToFloat(object value)
            {
                if (value == null || value == DBNull.Value)
                    return 0f;

                try
                {
                    if (value is float f) return f;

                    if (float.TryParse(value.ToString(), NumberStyles.Any, _culture, out float result))
                        return result;

                    return Convert.ToSingle(value, _culture);
                }
                catch
                {
                    return 0f;
                }
            }

            public static bool ToBool(object value)
            {
                if (value == null || value == DBNull.Value)
                    return false;

                try
                {
                    if (value is bool b) return b;

                    var s = value.ToString().Trim();

                    if (bool.TryParse(s, out bool result))
                        return result;

                    // Tratamento comum para bases de dados
                    if (s == "1" || s.Equals("S", StringComparison.OrdinalIgnoreCase) ||
                        s.Equals("Y", StringComparison.OrdinalIgnoreCase))
                        return true;

                    if (s == "0" || s.Equals("N", StringComparison.OrdinalIgnoreCase))
                        return false;

                    return Convert.ToBoolean(value, _culture);
                }
                catch
                {
                    return false;
                }
            }

            public static DateTime ToDateTime(object value)
            {
                if (value == null || value == DBNull.Value)
                    return DateTime.MinValue;

                try
                {
                    if (value is DateTime dt) return dt;

                    if (DateTime.TryParse(value.ToString(), _culture, DateTimeStyles.None, out DateTime result))
                        return result;

                    return Convert.ToDateTime(value, _culture);
                }
                catch
                {
                    return DateTime.MinValue;
                }
            }

            public static string ToString(object value)
            {
                if (value == null || value == DBNull.Value)
                    return string.Empty;

                try
                {
                    return value.ToString();
                }
                catch
                {
                    return string.Empty;
                }
            }

            public static Guid ToGuid(object value)
            {
                if (value == null || value == DBNull.Value)
                    return Guid.Empty;

                try
                {
                    if (value is Guid g) return g;

                    if (Guid.TryParse(value.ToString(), out Guid result))
                        return result;

                    return Guid.Empty;
                }
                catch
                {
                    return Guid.Empty;
                }
            }

            public static T ToEnum<T>(object value) where T : struct
            {
                if (value == null || value == DBNull.Value)
                    return default;

                try
                {
                    if (value is T t) return t;

                    if (Enum.TryParse<T>(value.ToString(), true, out T result))
                        return result;

                    return default;
                }
                catch
                {
                    return default;
                }
            }
        }
    }

}
