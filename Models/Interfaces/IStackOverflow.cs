using ResurantApiCore6.Models.Dtos;

namespace Core6.Models.Interfaces
{
     public interface IStackOverflow
    {
        Task<List<PostUserDtos>> GetListPostByUserId(int userId);
    }
}