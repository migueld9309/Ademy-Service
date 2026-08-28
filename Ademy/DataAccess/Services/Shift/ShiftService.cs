using DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Services.Shift
{
    public interface IShiftService
    {
        public Task<List<Models.Shift>> Get();
        public Task<List<Models.Shift>> GetActive();
        public bool Create(Models.Shift data);
    }
    public class ShiftService : IShiftService
    {
        private readonly Context _context;
        public ShiftService(Context Context)
        {
            this._context = Context;
        }

        public Task<List<Models.Shift>> Get()
        {
            try
            {
                return this._context.Shifts.ToListAsync();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public Task<List<Models.Shift>> GetActive()
        {
            try
            {
                return this._context.Shifts.Where(x => x.Available).ToListAsync();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public bool Create(Models.Shift data)
        {
            try
            {
                this._context.Shifts.Add(data);
                var response = this._context.SaveChanges();
                return true;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
