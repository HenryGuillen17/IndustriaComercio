using System;

namespace IndustriaComercio.Common.Tools
{
    public static class Tool
    {
        public static string CalcularDigito(string nit)
        {
            if (string.IsNullOrWhiteSpace(nit))
                return "";

            var vector = new int[15];
            vector[0] = 3; vector[1] = 7; vector[2] = 13; vector[3] = 17; vector[4] = 19;
            vector[5] = 23; vector[6] = 29; vector[7] = 37; vector[8] = 41; vector[9] = 43;
            vector[10] = 47; vector[11] = 53; vector[12] = 59; vector[13] = 67; vector[14] = 71;

            var acumulador = 0;

            for (var contador = 0; contador < nit.Length; contador++)
            {
                var temp = nit[(nit.Length - 1) - contador].ToString();
                acumulador = acumulador + (Convert.ToInt32(temp) * vector[contador]);
            }

            var residuo = acumulador % 11;

            if (residuo > 1)
            {
                return Convert.ToString(11 - residuo);
            }
            return Convert.ToString(residuo);
        }
    }
}