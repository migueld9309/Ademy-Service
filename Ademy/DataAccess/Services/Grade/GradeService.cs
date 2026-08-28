using DataAccess.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Services.Grade
{
    public interface IGradeService
    {
        public Task<List<Models.Grade>> Get();
        public Task<List<Models.Grade>> GetActive();
        public bool Create(Models.Grade data);
    }
    public class GradeService : IGradeService
    {
        private readonly Context _context;
        public GradeService(Context Context)
        {
            this._context = Context;
        }

        public Task<List<Models.Grade>> Get()
        {
            try
            {
                return this._context.Grades.ToListAsync();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public Task<List<Models.Grade>> GetActive()
        {
            try
            {
                return this._context.Grades.Where(x => x.Available).ToListAsync();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public bool Create(Models.Grade data)
        {
            try
            {
                this._context.Grades.Add(data);
                var response = this._context.SaveChanges();
                return true;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
