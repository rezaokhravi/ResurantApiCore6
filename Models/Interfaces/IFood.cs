using Core6.Models.Dtos;
using Core6.Models.Entites;

namespace Core6.Models.Interfaces
{
     public interface IFood
    {
         Task<List<Foods>> GetList();
         Task<Foods> Insert(Foods food);
         Task<Foods> Update(Foods food);
         Task<Foods> Delete(Foods food);
         Foods GetByID(long foodId);
         Task<Foods> DeleteById(long foodId);

    }
}