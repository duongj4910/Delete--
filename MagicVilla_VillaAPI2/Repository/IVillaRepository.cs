using MagicVilla_VillaAPI2.Models;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI2.Repository
{
    public interface IVillaRepository
    {
        Task<List<Villa>> GetAll(Expression<Func<Villa>> filter = null);

        Task<List<Villa>> Get(Expression<Func<Villa>> filter = null, bool tracked = true);

        Task Create(Villa entity);
        Task Remove(Villa entity);

        Task Save();

    }
}
