using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Golden.Models
{
    class Libro
    { 
        [PrimaryKey]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }

        public override string ToString()
        {
            return this.Nombre + "(" + this.Autor + " - " +  this.Editorial + ")";
        }

    }
}
