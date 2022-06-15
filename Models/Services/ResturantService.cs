using Core6.Models.Contexts;
using Core6.Models.Dtos;
using Core6.Models.Entites;
using Core6.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core6.Models.Services {
    public class ResturantService : IResturant {
        private readonly DBContext _context;
        private readonly ILogger<ResturantService> _logger;
        public ResturantService (DBContext context,ILogger<ResturantService> logger) {
            _context = context;
        }
        public async Task<ResturantListDtos> Delete (Resturants resturant) {
            _context.Resturants.Remove (resturant);
            await _context.SaveChangesAsync ();
               return new ResturantListDtos () {
                ID = resturant.ID,
                    TITLE = resturant.TITLE,
                    ADDRESS = resturant.ADDRESS,
                    DESCRIPTIONS = resturant.DESCRIPTIONS,
                    MOBILE = resturant.MOBILE,
                    PHONE = resturant.PHONE
            };
        }

        public async Task<ResturantListDtos> DeleteById (long resturantId) {
            return await Delete (GetByIDPrivate (resturantId));
        }

        private Resturants GetByIDPrivate (long resturantId) {
            return _context.Resturants.SingleOrDefault (item => item.ID == resturantId);
        }

        public ResturantListDtos GetByID (long resturantId) {
            var data = _context.Resturants.SingleOrDefault(item => item.ID == resturantId);
            return new ResturantListDtos () {
                ID = data.ID,
                    TITLE = data.TITLE,
                    ADDRESS = data.ADDRESS,
                    DESCRIPTIONS = data.DESCRIPTIONS,
                    MOBILE = data.MOBILE,
                    PHONE = data.PHONE
            };
        }

        public async Task<List<ResturantListDtos>> GetList () {
            return await _context.Resturants.Select (data => new ResturantListDtos () {
                ID = data.ID,
                    TITLE = data.TITLE,
                    ADDRESS = data.ADDRESS,
                    DESCRIPTIONS = data.DESCRIPTIONS,
                    MOBILE = data.MOBILE,
                    PHONE = data.PHONE
            }).ToListAsync ();
        }

        public async Task<ResturantListDtos> Insert (Resturants resturant) {
            var data = _context.Resturants.Add (resturant);
            await _context.SaveChangesAsync ();
              return new ResturantListDtos () {
                ID = data.Entity.ID,
                    TITLE = data.Entity.TITLE,
                    ADDRESS = data.Entity.ADDRESS,
                    DESCRIPTIONS = data.Entity.DESCRIPTIONS,
                    MOBILE = data.Entity.MOBILE,
                    PHONE = data.Entity.PHONE
            };
        }

        public async Task<ResturantListDtos> Update (Resturants resturant) {
            var data = _context.Resturants.Update (resturant);
            await _context.SaveChangesAsync ();
               return new ResturantListDtos () {
                ID = data.Entity.ID,
                    TITLE = data.Entity.TITLE,
                    ADDRESS = data.Entity.ADDRESS,
                    DESCRIPTIONS = data.Entity.DESCRIPTIONS,
                    MOBILE = data.Entity.MOBILE,
                    PHONE = data.Entity.PHONE
            };
        }
    }
}