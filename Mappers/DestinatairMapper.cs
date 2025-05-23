using AutoMapper;
using Gestion_Destinataire.DTOs;
using Gestion_Destinataire.Models;

namespace Gestion_Destinataire.Mappers
{
    public class DestinatairMapper : Profile
    {
        public DestinatairMapper() { 
            CreateMap<Destinataire , DestinataireResponse>();
            CreateMap<DestinataireRequest, Destinataire>();
        }  
    }
}
