using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


namespace IndustriaComercio.Models.Tools
{
    public static class Tools
    {
        public static string Encripta(this string cadena)
        {
            try
            {
                if (cadena == string.Empty) return string.Empty;

                var clave = Encoding.ASCII.GetBytes("APLKeyUser//");
                var iv = Encoding.ASCII.GetBytes("Devjoker7.37hAES");

                var inputBytes = Encoding.ASCII.GetBytes(cadena);
                var cripto = new RijndaelManaged();

                byte[] encripted;

                using (var ms = new MemoryStream(inputBytes.Length))
                {
                    using (var objCryptoStream = new CryptoStream(ms, cripto.CreateEncryptor(clave, iv), CryptoStreamMode.Write))
                    {
                        objCryptoStream.Write(inputBytes, 0, inputBytes.Length);
                        objCryptoStream.FlushFinalBlock();
                        objCryptoStream.Close();
                    }
                    encripted = ms.ToArray();
                }
                return Convert.ToBase64String(encripted);
            }
            catch (Exception err)
            {
                throw new Exception("Ocurrio un error encriptando los datos, error : " + err.Message, err);
            }
        }

        public static string Desencripta(this string cadena)
        {
            try
            {
                if (cadena == string.Empty) return string.Empty;

                var clave = Encoding.ASCII.GetBytes("APLKeyUser//");
                var iv = Encoding.ASCII.GetBytes("Devjoker7.37hAES");

                var inputBytes = Convert.FromBase64String(cadena);
                var cripto = new RijndaelManaged();

                string textoLimpio;

                using (var ms = new MemoryStream(inputBytes))
                {
                    using (var objCryptoStream = new CryptoStream(ms, cripto.CreateDecryptor(clave, iv), CryptoStreamMode.Read))
                    {
                        using (var sr = new StreamReader(objCryptoStream, true))
                        {
                            textoLimpio = sr.ReadToEnd();
                        }
                    }
                }
                return textoLimpio;
            }
            catch (Exception err)
            {
                throw new Exception("Ocurrio un error desencriptando los datos, error : " + err.Message, err);
            }
        }
    }

}