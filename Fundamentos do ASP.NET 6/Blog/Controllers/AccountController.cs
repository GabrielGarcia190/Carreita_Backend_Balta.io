using Blog.Data;
using Blog.Extesions;
using Blog.Models;
using Blog.Services;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace Blog.Controllers
{
    // [Authorize]
    [ApiController]
    public class AccountController : Controller
    {
        [HttpPost("v1/acccounts")]
        public async Task<IActionResult> Post(
        [FromBody] RegisterViewModel model,
        [FromServices] BlogDataContext context
        )
        {

            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                Slug = model.Email.Replace("@", "-").Replace(".", "-")
            };

            var password = PasswordGenerator.Generate(25);
            user.PasswordHash = PasswordHasher.Hash(password);

            try
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
                return Ok(new ResultViewModel<dynamic>(
                    new
                    {
                        user = user.Email,
                        password
                    }));
            }
            catch (DbUpdateException)
            {
                return StatusCode(400, new ResultViewModel<string>("05X99 - Este e-mail já existe"));
            }
            catch
            {
                return StatusCode(400, new ResultViewModel<string>("05X04 - Falha interna no servidor"));
            }
        }

        // [AllowAnonymous]
        [HttpPost("v1/acccounts/login")]
        public async Task<IActionResult> Login(
           [FromBody] LoginViewModel model,
           [FromServices] BlogDataContext context,
           [FromServices] TokenService tokenService)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

            var user = await context
            .Users.AsNoTracking()
            .Include(x => x.Roles)
            .FirstOrDefaultAsync(x => x.Email == model.Email);

            if (user == null)
                return StatusCode(401, new ResultViewModel<string>("Usuário ou senha inválidos"));

            if (user.PasswordHash == null)
                return StatusCode(401, new ResultViewModel<string>("Usuário ou senha inválidos"));

            if (model.Password == null)
                return StatusCode(401, new ResultViewModel<string>("Usuário ou senha inválidos"));


            if (!PasswordHasher.Verify(user.PasswordHash, model.Password))
                return StatusCode(401, new ResultViewModel<string>("Usuário ou senha inválidos"));

            try
            {
                var token = tokenService.GenerateToken(user);

                return Ok(new ResultViewModel<string>(token, null));
            }
            catch (System.Exception)
            {
                return StatusCode(500, new ResultViewModel<string>("05X04 - Falha interna no servidor"));
            }

        }





        // [Authorize(Roles = "user")]
        // [HttpGet("v1/user")]
        // public IActionResult GetUser() => Ok(User.Identity.Name);


        // [Authorize(Roles = "author")]
        // [HttpGet("v1/author")]
        // public IActionResult GetAuthor() => Ok(User.Identity.Name);

        // [Authorize(Roles = "admin")]
        // [HttpGet("v1/admin")]
        // public IActionResult GetAdmin() => Ok(User.Identity.Name);

    }
}