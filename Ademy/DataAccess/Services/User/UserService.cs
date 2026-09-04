using DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccess.Services.User
{
    public interface IUserService
    {
        Task<List<Models.User>> Get();
        public bool Login(string email, string password);
        public GenericResponse<Models.User> Create(Models.User data);
    }

    public class UserService : IUserService
    {
        private readonly Context _context;
        private readonly IEncrypt _encrypt;
        public UserService(Context Context, IEncrypt encrypt) { 
            this._context = Context;
            this._encrypt = encrypt;
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

                var encryptPassword = this._encrypt.Encriptar(data.Password, "abcdefghijklmnopqrstuvwxyzabcdef");
                data.Password = encryptPassword;
                this._context.Users.Add(data);
                this._context.SaveChanges();
                return GenericResponse<Models.User>.Success(data);
            }
            catch (Exception ex) {  return GenericResponse<Models.User>.Fail(ex.Message); }
        }

        public bool Login(string email, string password)
        {
            try
            {
                var encryptPassword = this._encrypt.Encriptar(password, "abcdefghijklmnopqrstuvwxyzabcdef");
                var userExists = this._context.Users.FirstOrDefault(x => x.Email == email && x.Password == encryptPassword);
                //TODO: Validation Active Directory
                return userExists != null;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

    }
}
