using Gestion_Destinataire.DTOs;

namespace Gestion_Destinataire.Service.Interface
{
    public interface IDestinataireService
    {
        Task <IEnumerable <DestinataireResponse>> GetAllDestinataire();
        Task <DestinataireResponse?> GetById (int id);
        Task<DestinataireResponse> CreateDestinataire(DestinataireRequest destinataireRequest);
        Task<DestinataireResponse?> UpdateDestinataire(DestinataireRequest destinataireRequest , int id);
        Task<bool> DeleteDestinataire(int id);


    }
}
