using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace IndustriaComercio.Models.Enum
{
    public enum Estado : byte
    {
        [Description("Activo")]
        Activo = 1,
        [Description("Inactivo")]
        Inactivo = 2
    }
}