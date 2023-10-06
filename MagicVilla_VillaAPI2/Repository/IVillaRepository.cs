using MagicVilla_VillaAPI2.Models;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI2.Repository
{
    public interface IVillaRepository : IRepository<Villa>
    {

        Task <Villa> UpdateAsync(Villa entity);



    }
}
