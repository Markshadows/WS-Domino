using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS_DOMINO.Models
{
    public class Platillo
    {
        public int Id { get; set; }
        public int Valor { get; set; }
        public int PromedioPreparacion { get; set; }
        public string Descripcion { get; set; }
        public string Src { get; set; }
        public string Nombre { get; set; }
    }
}