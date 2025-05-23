using System.ComponentModel.DataAnnotations;

namespace Gestion_Destinataire.DTOs
{
    public class DestinataireRequest

    {
        [Required(ErrorMessage ="Le nom est obligatoire ")]
        [StringLength(50,ErrorMessage ="Le prénom ne peut pas dépasser 50 caractère")]
        public string Nom { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le nom est obligatoire ")]
        public string Prenom { get; set; } = string.Empty ;

        [Required(ErrorMessage = "Le nom est obligatoire ")]
        [EmailAddress(ErrorMessage ="Format d'email est invalide")]
        public string Email { get; set; } = string.Empty;

    }
}
