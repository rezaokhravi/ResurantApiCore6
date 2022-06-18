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
        public async Task<Foods> Delete(Foods food)
        {
            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();
            return food;
        }

        public async Task<Foods> DeleteById(long foodId)
        {
            return await Delete(GetByIDPrivate(foodId));
        }

        private Foods GetByIDPrivate(long foodId)
        {
            return _context.Foods.SingleOrDefault(item => item.ID == foodId);
        }

        public Foods GetByID(long foodId)
        {
            var data = _context.Foods.Include(f=>f.Resturant).SingleOrDefault(item => item.ID == foodId);
            return data;
        }

        public async Task<List<Foods>> GetList()
        {
            return await _context.Foods
            .Include(f=>f.Resturant)
            .ToListAsync();
        }



        public async Task<Foods> Insert(Foods food)
        {
            var data = _context.Foods.Add(food);
            await _context.SaveChangesAsync();
            return GetByID(data.Entity.ID);
        }

        public async Task<Foods> Update(Foods food)
        {
            var data = _context.Foods.Update(food);
            await _context.SaveChangesAsync();
            return GetByID(data.Entity.ID);
        }
    }
}