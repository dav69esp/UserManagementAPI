using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static readonly List<User> Users = new()
        {
            new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith",
                Email = "john.smith@techhive.com",
                Department = "IT"
            },
            new User
            {
                Id = 2,
                FirstName = "Sarah",
                LastName = "Williams",
                Email = "sarah.williams@techhive.com",
                Department = "HR"
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(Users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            try
            {
                var user = Users.FirstOrDefault(u => u.Id == id);

                if (user == null)
                {
                    return NotFound($"User with ID {id} not found.");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            try
            {
                if (Users.Any(u =>
                    u.Email.Equals(user.Email,
                    StringComparison.OrdinalIgnoreCase)))
                {
                    return BadRequest("A user with this email already exists.");
                }

                user.Id = Users.Any()
                    ? Users.Max(u => u.Id) + 1
                    : 1;

                Users.Add(user);

                return CreatedAtAction(
                    nameof(GetUser),
                    new { id = user.Id },
                    user);
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    $"An error occurred: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User updatedUser)
        {
            try
            {
                var user = Users.FirstOrDefault(u => u.Id == id);

                if (user == null)
                {
                    return NotFound($"User with ID {id} not found.");
                }

                user.FirstName = updatedUser.FirstName;
                user.LastName = updatedUser.LastName;
                user.Email = updatedUser.Email;
                user.Department = updatedUser.Department;

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var user = Users.FirstOrDefault(u => u.Id == id);

                if (user == null)
                {
                    return NotFound($"User with ID {id} not found.");
                }

                Users.Remove(user);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    $"An error occurred: {ex.Message}");
            }
        }
    }
}