using DataAccess.Models;
using DataAccess.Services.Shift;
using DataAccess.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Ademy.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ShiftController : ControllerBase
    {
        public IShiftService _service;

        public ShiftController(IShiftService service)
        {
            this._service = service;
        }
        //Catalogs
        [HttpGet]
        public List<Shift> Get()
        {
            return this._service.Get().Result;
        }
        //Drop down or choose values
        [HttpGet]
        public List<Shift> GetActive()
        {
            return this._service.GetActive().Result;
        }
        [HttpPost]
        public bool Create(Shift data)
        {
            return this._service.Create(data);
        }
    }
}
