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
         ResturantListDtos GetByID(long resturantId);
         Task<ResturantListDtos> DeleteById(long resturantId);

    }
}