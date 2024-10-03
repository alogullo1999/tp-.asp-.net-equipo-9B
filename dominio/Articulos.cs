using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace dominio
{
    public class Articulos
    {
        public int IdArticulo { get; set; }
        [DisplayName("Código")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public decimal precio { get; set; }

        public Marcas marcas { get; set; }

        public Categoria categoria { get; set; }

        public Imagen imagen { get; set; }

       

    }
}
