using MagicVilla_VillaAPI2.Models;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI2.Repository
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {

        Task <VillaNumber> UpdateAsync(VillaNumber entity);



    }
}
