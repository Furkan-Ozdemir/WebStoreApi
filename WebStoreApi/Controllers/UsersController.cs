using Microsoft.AspNetCore.Mvc;
using WebStoreApi.Filters;
using WebStoreApi.Models;
using WebStoreApi.Services;

namespace WebStoreApi.Controllers
{
    [Route("api/[controller]")] //api/users
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static List<UserDTO> _users = new List<UserDTO>()
        {
            new UserDTO()
            {
                FirstName = "Furkan",
                LastName = "Gates",
                Email = "a@b.com",
                Phone = "+290519515",
                Address = "New york"
            },
            new UserDTO()
            {
                FirstName = "Ahet",
                LastName = "asd",
                Email = "casa@b.com",
                Phone = "+2905121519515",
                Address = "New york"
            }
        };

        [HttpGet("info")]
        [DebugFilter]
        public IActionResult GetInfo(int? id, string? name, int? page)
        {
            if (id != null || name != null || page != null)
            {
                var response = new
                {
                    Id = id,
                    Name = name,
                    Page = page,
                    ErroMessage = "The search is not implemented yet"
                };
                return Ok(response);
            }

            List<string> listInfo = new List<string>() { "info 1", "info 2", "info 3" };
            return Ok(listInfo);
        }

        [HttpGet]
        public IActionResult GetUsers([FromServices] TimeService timeService)
        {
            Console.Write(timeService.GetTime());
            if (_users.Any())
            {
                return Ok(_users);
            }
            return NoContent();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUser(int id)
        {
            if (id >= 0 && id < _users.Count)
            {
                return Ok(_users[id]);
            }
            return NotFound();
        }

        [HttpGet("{name}")]
        public IActionResult GetUser(string name)
        {
            var user = _users.FirstOrDefault(user =>
                user.FirstName.Contains(name) || user.LastName.Contains(name)
            );
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser(UserDTO user)
        {
            if (user.Email.Equals("user@example.com"))
            {
                ModelState.AddModelError("Email", "This email address is not authorized");
                return BadRequest(ModelState);
            }

            _users.Add(user);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UserDTO user)
        {
            if (id >= 0 && id < _users.Count)
            {
                _users[id] = user;
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (id >= 0 && id < _users.Count)
            {
                _users.RemoveAt(id);
            }
            return NoContent();
        }
    }
}
