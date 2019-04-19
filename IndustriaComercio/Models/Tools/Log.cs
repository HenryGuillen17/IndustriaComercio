using System;
using System.Globalization;
using System.IO;

namespace IndustriaComercio.Models.Tools
{
    public static class Log
    {
        public static void Add(string logText)
        {
            using (var w = File.AppendText("C:\\APL\\logAbogados.txt"))
            {
                w.WriteLine(DateTime.Now.ToString(CultureInfo.InvariantCulture) + " - " + logText);
            }
        }

        public static void Add(Exception ex)
        {
            try
            {
                using (var w = File.AppendText("C:\\APL\\logAbogados.txt"))
                {
                    w.WriteLine("--------------------------------------------------------------------------------");
                    w.WriteLine(DateTime.Now.ToString(CultureInfo.InvariantCulture) + " - EXCEPCION");
                    if (ex.TargetSite.DeclaringType != null) w.WriteLine("Clase-Base: " + ex.TargetSite.DeclaringType.Name);
                    w.WriteLine("Metodo-Base: " + ex.TargetSite);
                    w.WriteLine("Mensaje: " + ex.Message);
                    w.WriteLine("Fuente: " + ex.Source);
                    w.WriteLine("TargetSite: " + ex.TargetSite);
                    w.WriteLine("StackTrace: " + ex.StackTrace);
                    w.WriteLine("InnerException: " + ex.InnerException);
                    w.WriteLine("--------------------------------------------------------------------------------");
                }
            }
            catch
            {
                // ignored
            }
        }       
    }
}
