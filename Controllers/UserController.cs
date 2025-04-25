using Microsoft.AspNetCore.Mvc;
using userprofileapp.Models;
using userprofileapp.Services;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace userprofileapp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        // Injecting the UserService dependency via constructor
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Display all users (Index)
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersAsync();
            return View(users); // Pass users to the view
        }

        // Show the form to create a new user
        public IActionResult Create() => View();

        // Create a new user (POST method)
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                await _userService.CreateUserAsync(user);
                return RedirectToAction(nameof(Index)); // Redirect to Index after successful creation
            }
            return View(user); // Return to the view with validation errors
        }

        // Show the form to edit an existing user (GET method)
        public async Task<IActionResult> Edit(string id)
        {
            // Convert string id to ObjectId for MongoDB
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                return BadRequest("Invalid ID format.");
            }

            var user = await _userService.GetUserByIdAsync(objectId);
            if (user == null)
            {
                return NotFound(); // Return 404 if user is not found
            }

            return View(user); // Pass the user to the view for editing
        }

        // Edit an existing user (POST method)
        [HttpPost]
        public async Task<IActionResult> Edit(string id, User user)
        {
            if (ModelState.IsValid)
            {
                // Convert string id to ObjectId and set the user ID correctly
                if (!ObjectId.TryParse(id, out ObjectId objectId))
                {
                    return BadRequest("Invalid ID format.");
                }

                user.Id = objectId; // Ensure the user ID is set properly for update
                await _userService.UpdateUserAsync(user);
                return RedirectToAction(nameof(Index)); // Redirect to Index after successful update
            }

            return View(user); // Return to the view with validation errors
        }
    }
}
