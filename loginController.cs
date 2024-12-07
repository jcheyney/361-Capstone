using Microsoft.AspNetCore.Mvc;

namespace DatabaseApp.Controllers
{
    [Route("api/login")]  // The base route for this controller
    [ApiController]
    public class LoginController : ControllerBase
    {
        // POST api/login
        [HttpPost]  // This attribute specifies that this method will handle POST requests
        public IActionResult Login([FromBody] LoginRequest request)
        {
            string other_Username = request.Username;
            string other_Password = request.Password;
            Hash_Map hashmap_Instance = new();
            dynamic customer_Info = hashmap_Instance.GetCustomerInfo(other_Username);

            // Validate the username and password (usually against a database)
            if (customer_Info.Username == other_Username && customer_Info.Password == other_Password ) 
            {
                return Ok(new { success = true });  // Return success if credentials are correct
            }
            else
            {
                return Unauthorized(new { success = false });  // Return failure if credentials are incorrect
            }
        }
    }

    // Model to represent the login request
    public class LoginRequest
    {
        public  string Username { get; set; }  // Username property
        public string Password { get; set; }  // Password property
    }
}
