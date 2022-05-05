using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Models
{
    public class GestoresBD
    {
        [Key]
        public int idempleo { get; set; }
        public string descripcion { get; set; }
        public string compania { get; set; }
        public string tipo { get; set; }
        public string posicion { get; set; }
        public string ubicacion { get; set; }
        public string categoria { get; set; }
        public string email { get; set; }

    }
}
