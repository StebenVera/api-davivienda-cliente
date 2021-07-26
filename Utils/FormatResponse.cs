using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_davivienda_cliente.Utils
{
    public class FormatResponse
    {
        public bool state { get; set; }

        public string message { get; set; }
        
        public object Data { get; set; }
    }
}
