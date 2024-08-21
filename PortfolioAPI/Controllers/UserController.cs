using Microsoft.AspNetCore.Mvc;
using PortfolioAPI.Data.Models;
using PortfolioAPI.Data.Repository.IRepository;

namespace PortfolioAPI.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    

    public class UserController : Controller
    {
        protected IRepository<User> _repository;
        public UserController(IRepository<User> repository) 
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var userList =  await _repository.GetAllAsync();

            if (userList == null)
            {
                return NotFound("Not found");
            }
            else
            {
                return Ok(userList);
            }
        }
    }
}
