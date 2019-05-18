using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace IndustriaComercio.Models.Tools
{
    public class EnumTools
    {
        public static string GetDescription(System.Enum en)
        {
            var type = en.GetType();
            var memInfo = type.GetMember(en.ToString());

            if (memInfo.Length <= 0)
                return en.ToString();

            var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attrs.Length > 0)
                return ((DescriptionAttribute)attrs[0]).Description;

            return en.ToString();
        }

        public static IEnumerable<KeyValuePair<byte, string>> OfByte<T>()
        {
            return System.Enum.GetValues(typeof(T))
                .Cast<T>()
                .Where(p => Convert.ToByte(p) > 0)
                .Select(p => new KeyValuePair<byte, string>(Convert.ToByte(p), GetDescription(p as System.Enum)))
                .ToList();
        }

        private static IEnumerable<KeyValuePair<char, string>> Ofchar<T>()
        {
            return System.Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(p => new KeyValuePair<char, string>(Convert.ToChar(p), p.ToString()))
                .ToList();
        }

    }
}