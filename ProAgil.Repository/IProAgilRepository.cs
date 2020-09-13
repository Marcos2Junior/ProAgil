using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public interface IProAgilRepository
    {
         void Add<T>(T entity) where T : class;
         void Update<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         Task<bool> SaveChangesAsync();

         //EVENTOS

         Task<Evento[]> GetAllEventoByTemaAsync(string tema, bool includePalestrante);
         Task<Evento[]> GetAllEventoAsync(bool includePalestrante);
         Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrante);

         //PALESTRANTE

        Task<Palestrante[]> GetAllPalestrantesByNameAsync(string name, bool includeEventos);
        Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includeEventos);

    }
}