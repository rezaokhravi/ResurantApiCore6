using Core6.Models.Dtos;
using Core6.Models.Entites;

namespace Core6.Models.Interfaces
{
     public interface IFood
    {
         Task<List<FoodListDtos>> GetList();
         Task<FoodListDtos> Insert(Foods food);
         Task<FoodListDtos> Update(Foods food);
         Task<FoodListDtos> Delete(Foods food);
         FoodListDtos GetByID(int foodId);
         Task<FoodListDtos> DeleteById(int foodId);

    }
}