﻿namespace Gestion_Destinataire.DTOs
{
    public class DestinataireResponse
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
