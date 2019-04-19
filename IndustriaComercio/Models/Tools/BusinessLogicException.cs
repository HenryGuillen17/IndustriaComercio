using System;

namespace IndustriaComercio.Models.Tools
{
    /*Informacion de error : que ha ocurrido, como le afecta el error producido en cuanto al proceso o transacción que estaba llevando a cabo, 
     * que debe hacer a partir de ese momento, y algún tipo de información sobre servicio de soporte de la aplicación*/
    public class BusinessLogicException : Exception
    {
        public BusinessLogicException() { }
        public BusinessLogicException(string message) : base(message) { }
        public BusinessLogicException(string message, Exception inner) : base(message, inner) { }
    }
}
