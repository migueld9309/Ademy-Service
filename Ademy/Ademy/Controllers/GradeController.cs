using DataAccess.Models;
using DataAccess.Services.Grade;
using DataAccess.Services.Shift;
using Microsoft.AspNetCore.Mvc;

namespace Ademy.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GradeController : ControllerBase
    {
        public IGradeService _service;

        public GradeController(IGradeService service)
        {
            this._service = service;
        }
        //Catalogs
        [HttpGet]
        public List<Grade> Get()
        {
            return this._service.Get().Result;
        }
        //Drop down or choose values
        [HttpGet]
        public List<Grade> GetActive()
        {
            return this._service.GetActive().Result;
        }
        /// <summary>
        /// Create Grade
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Create(Grade data)
        {
            return this._service.Create(data);
        }
    }
}
