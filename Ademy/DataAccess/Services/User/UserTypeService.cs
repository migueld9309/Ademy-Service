using DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Services.User
{
    public interface IUserTypeService
    {
        public Task<List<Models.UserType>> Get();

        public Task<List<Models.UserType>> GetActives();

        public bool Create(Models.UserType data);
    }
    public class UserTypeService : IUserTypeService
    {
        private readonly Context _context;
        public UserTypeService(Context Context)
        {
            this._context = Context;
        }

        public Task<List<Models.UserType>> Get()
        {
            try
            {
                return this._context.UserTypes.ToListAsync();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public Task<List<Models.UserType>> GetActives()
        {
            try
            {
                return this._context.UserTypes.Where(x => x.Available).ToListAsync();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public bool Create(Models.UserType data)
        {
            try
            {
                this._context.UserTypes.Add(data);
                var response = this._context.SaveChanges();
                return true;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public bool Test()
        {
            return true;
        }
    }
}
