//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PROYECTO_VERIS_MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class pacientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pacientes()
        {
            this.consultas = new HashSet<consultas>();
        }
    
        public int IdPaciente { get; set; }
        public string IdUsuario { get; set; }
        public string Nombre { get; set; }
        public int Cedula { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public int Estatura { get; set; }
        public double Peso { get; set; }
        public string Foto { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<consultas> consultas { get; set; }
    }
}
