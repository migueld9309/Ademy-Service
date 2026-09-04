using DataAccess.Services.User;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Models;
using DataAccess.Models.DTO;

namespace Ademy.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class UserController : ControllerBase
    {
        public IUserService _service;

        public UserController(IUserService service) { 
            this._service = service;
        }
        //Catalogs
        [HttpGet]
        public List<User> Get()
        {
            return this._service.Get().Result;
        }
        //Drop down or choose values
        [HttpGet]
        public bool GetActive()
        {
            return true;
        }

        [HttpPost]
        public bool Login([FromBody] Login login)
        {
            return this._service.Login(login.Email, login.Password);
        }

        [HttpPost]
        public User Create(User data)
        {
            return this._service.Create(data).Data;
        }

        [HttpPut]
        public bool Update()
        {
            return true;
        }
    }
}
