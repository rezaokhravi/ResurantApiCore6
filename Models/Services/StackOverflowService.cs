using Core6.Models.Contexts;
using Core6.Models.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using ResurantApiCore6.Models.Dtos;

namespace ResurantApiCore6.Models.Services
{
    public class StackOverflowService : IStackOverflow
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<StackOverflowService> _logger;
        private string _connectionString;

        public StackOverflowService(ILogger<StackOverflowService> logge, IConfiguration configuration)
        {
            _logger = logge;
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("StackOverflowConnection");
        }

        public async Task<List<PostUserDtos>> GetListPostByUserId(int userId)
        {
            string query = @"
            SELECT TOP 10 U.ID AS USERS_ID, U.DISPLAYNAME as DISPLAY_NAME,PH.TEXT FROM POSTHISTORY PH
            INNER JOIN USERS U ON U.ID = PH.USERID
            WHERE  PH.USERID = @userId
            ";

            using (var con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    return (List<PostUserDtos>) await con.QueryAsync<PostUserDtos>(query, new { @userId = userId });
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

            }
        }
    }
}