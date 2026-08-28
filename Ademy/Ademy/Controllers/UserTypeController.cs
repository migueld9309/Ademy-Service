using DataAccess.DataAccess;
using DataAccess.Models;
using DataAccess.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Ademy.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserTypeController : ControllerBase
    {
        public IUserTypeService _service;
        public string Texto;

        public UserTypeController(IUserTypeService service)
        {
            this._service = service;
        }
        //Catalogs
        [HttpGet]
        public List<UserType> Get()
        {
            return this._service.Get().Result;
        }
        //Drop down or choose values
        [HttpGet]
        public List<UserType> GetActive()
        {
            return this._service.GetActives().Result;
        }

        [HttpPost]
        public bool Create(UserType data)
        {
            return this._service.Create(data);
        }

        [HttpPut]
        public bool Update()
        {
            return true;
        }
    }
}
