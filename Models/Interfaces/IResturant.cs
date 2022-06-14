using Core6.Models.Dtos;
using Core6.Models.Entites;

namespace Core6.Models.Interfaces
{
    public interface IResturant
    {
         Task<List<ResturantListDtos>> GetList();
         Task<ResturantListDtos> Insert(Resturants resturant);
         Task<ResturantListDtos> Update(Resturants resturant);
         Task<ResturantListDtos> Delete(Resturants resturant);
         ResturantListDtos GetByID(int resturantId);
         Task<ResturantListDtos> DeleteById(int resturantId);

    }
}