using DataAnnotationsExtensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "EL NOMBRE ES OBLIGATORIO")]
        [StringLength(80)]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "EL APELLIDO ES OBLIGATORIO")]
        [StringLength(80)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "LA FECHA DE NACIMIENTO ES OBLIGATORIA")]
        public DateTime Fecha_Nacimiento { get; set; }

        [Required(ErrorMessage = "EL CUIT ES OBLIGATORIO")]
        [RegularExpression(@"^(20|2[3-7]|30|3[3-4])(\d{8})(\d)$", ErrorMessage = "EL FORMATO DEL CUIT ES INCORRECTO")]
        public string CUIT { get; set; }

        [Required(ErrorMessage = "EL DOMICILIO ES OBLIGATORIO")]
        public string Domicilio { get; set; }

        [Required(ErrorMessage = "EL TELEFONO CELULAR ES OBLIGATORIO")]
        [DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage = "EL FORMATO DEL TELEFONO ES INVALIDO")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "EL EMAIL ES OBLIGATORIO")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", 
            ErrorMessage = "EL FORMATO DEL EMAIL ES INVALIDO")]
        public string Email { get; set; }
    }
}
