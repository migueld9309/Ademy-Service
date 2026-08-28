using DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Services.User
{
    public interface IUserService
    {
        Task<List<Models.User>> Get();
        public bool Login(string user, string pasword);
    }

    public class UserService : IUserService
    {
        private readonly Context _context;
        public UserService(Context Context) { 
            this._context = Context;
        }

        public Task<List<Models.User>> Get()
        {
            try
            {
                return this._context.Users.ToListAsync();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public Task<List<Models.User>> GetActive()
        {
            try
            {
                return this._context.Users.Where(x => x.Available).ToListAsync();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public GenericResponse<Models.User> Create(Models.User data)
        {
            try
            {
                this._context.Users.Add(data);
                this._context.SaveChanges();
                return GenericResponse<Models.User>.Success(data);
            }
            catch (Exception ex) {  return GenericResponse<Models.User>.Fail(ex.Message); }
        }

        public bool Login(string user, string pasword)
        {
            try
            {
                //TODO: Validation Active Directory
                return true;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

    }
}
