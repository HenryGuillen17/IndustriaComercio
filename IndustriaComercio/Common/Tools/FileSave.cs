using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace IndustriaComercio.Common.Tools
{
    public static class FileSave
    {

        public static void DeleteFile(string ruta)
        {
            if (string.IsNullOrEmpty(ruta)) return;

            if (!File.Exists(ruta)) return;

            File.Delete(ruta);
        }
        

        public static string GuardarArchivo(
            HttpPostedFileBase file, string originalDirectory, 
            string nombre
            )
        { 
            if (!Directory.Exists($"{originalDirectory}"))
                Directory.CreateDirectory($"{originalDirectory}");

            nombre = nombre + "_" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfffffff") + Path.GetExtension(file.FileName);
            var path = $"{originalDirectory}\\{nombre}";
            file.SaveAs(path);

            return nombre;
        }
    }
}