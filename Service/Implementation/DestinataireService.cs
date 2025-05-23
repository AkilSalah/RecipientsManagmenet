using AutoMapper;
using Gestion_Destinataire.Data;
using Gestion_Destinataire.DTOs;
using Gestion_Destinataire.Models;
using Gestion_Destinataire.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Destinataire.Service.Implementation
{
    public class DestinataireService : IDestinataireService
    {
        private readonly DBContext _context; 
        private readonly IMapper _mapper;

        public DestinataireService (DBContext context ,IMapper mapper )
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<DestinataireResponse> CreateDestinataire(DestinataireRequest destinataireRequest)
        {
            var destinataire = _mapper.Map<Destinataire>(destinataireRequest);
            _context.Destinataires.Add(destinataire);
            await _context.SaveChangesAsync();
            return _mapper.Map<DestinataireResponse>(destinataire);
        }

        public async Task<bool> DeleteDestinataire(int id)
        {
            var existingDestinataire = await _context.Destinataires.FindAsync(id);
            if (existingDestinataire == null) return false; 

            _context.Destinataires.Remove(existingDestinataire);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<DestinataireResponse>> GetAllDestinataire()
        {
            var destinataire = await _context.Destinataires.ToListAsync();
            return _mapper.Map<IEnumerable<DestinataireResponse>>(destinataire);
        }

        public async Task<DestinataireResponse?> GetById(int id)
        {
            var destinataire = await _context.Destinataires.FindAsync(id);
            return destinataire == null ? null : _mapper.Map<DestinataireResponse>(destinataire);
        }

        public async Task<DestinataireResponse?> UpdateDestinataire(DestinataireRequest destinataireRequest, int id)
        {
            var existingDestinataire = await _context.Destinataires.FindAsync(id);
            if (existingDestinataire == null) return null;

            _mapper.Map(destinataireRequest, existingDestinataire);
            _context.Destinataires.Update(existingDestinataire);
            await _context.SaveChangesAsync();
            return _mapper.Map<DestinataireResponse>(existingDestinataire);
        }
    }
}
