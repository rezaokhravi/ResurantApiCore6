using Core6.Models.Contexts;
using Core6.Models.Dtos;
using Core6.Models.Entites;
using Core6.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core6.Models.Services
{
    public class FoodService : IFood
    {
        private readonly DBContext _context;
        private readonly IResturant _resturant;
        public FoodService(DBContext context, IResturant resturant)
        {
            _context = context;
            _resturant = resturant;
        }
        public async Task<FoodListDtos> Delete(Foods food)
        {
            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();
            return new FoodListDtos()
            {
                ID = food.ID,
                TITLE = food.TITLE,
                PRICE = food.PRICE,
                DESCRIPTIONS = food.DESCRIPTIONS,
                RES_ID = food.ID,
                RES_TITLE = food.Resturant.TITLE
            };
        }

        public async Task<FoodListDtos> DeleteById(long foodId)
        {
            return await Delete(GetByIDPrivate(foodId));
        }

        private Foods GetByIDPrivate(long foodId)
        {
            return _context.Foods.SingleOrDefault(item => item.ID == foodId);
        }

        public FoodListDtos GetByID(long foodId)
        {
            var data = _context.Foods.SingleOrDefault(item => item.ID == foodId);
            var resturant = _resturant.GetByID(data.RES_ID);
            return new FoodListDtos()
            {
                ID = data.ID,
                TITLE = data.TITLE,
                PRICE = data.PRICE,
                DESCRIPTIONS = data.DESCRIPTIONS,
                RES_ID = resturant.ID,
                RES_TITLE = resturant.TITLE
            };
        }

        public async Task<List<FoodListDtos>> GetList()
        {
            return await _context.Foods.Select(data => new FoodListDtos()
            {
                ID = data.ID,
                TITLE = data.TITLE,
                PRICE = data.PRICE,
                DESCRIPTIONS = data.DESCRIPTIONS,
                RES_ID = data.RES_ID,
                RES_TITLE = data.Resturant.TITLE
            }).ToListAsync();
        }



        public async Task<FoodListDtos> Insert(Foods food)
        {
            var data = _context.Foods.Add(food);
            await _context.SaveChangesAsync();
            var resturant = _resturant.GetByID(food.RES_ID);
            return new FoodListDtos()
            {
                ID = data.Entity.ID,
                TITLE = data.Entity.TITLE,
                PRICE = data.Entity.PRICE,
                DESCRIPTIONS = data.Entity.DESCRIPTIONS,
                RES_ID = resturant.ID,
                RES_TITLE = resturant.TITLE
            };
        }

        public async Task<FoodListDtos> Update(Foods food)
        {
            var data = _context.Foods.Update(food);
            await _context.SaveChangesAsync();
            var resturant = _resturant.GetByID(food.RES_ID);
            return new FoodListDtos()
            {
                ID = data.Entity.ID,
                TITLE = data.Entity.TITLE,
                PRICE = data.Entity.PRICE,
                DESCRIPTIONS = data.Entity.DESCRIPTIONS,
                RES_ID = resturant.ID,
                RES_TITLE = resturant.TITLE
            };
        }
    }
}