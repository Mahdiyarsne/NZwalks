using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZwalks.API.Models.DTO.LoginDto;
using NZwalks.API.Models.Dtos.LoginDto;
using NZwalks.API.Models.Dtos.RegisterDto;
using NZwalks.API.Repositories.TokenRepository;

namespace NZwalks.API.Controllers
{

    public class AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository) : BaseApiController
    {

        //register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var IdentityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };


            var identityResult = await userManager.CreateAsync(IdentityUser, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
                //Add roles to User
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(IdentityUser, registerRequestDto.Roles);

                    if (identityResult.Succeeded)
                    {
                        return Ok("User was registered! Please login.");
                    }
                }
            }

            return BadRequest("Something went wrong");
        }

        //login
        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Username);


            if (user != null)
            {
                var checkPassword = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPassword)
                {
                    //Get roles for this user
                    var roles=  await userManager.GetRolesAsync(user);

                    if (roles != null) 
                    {
                        //Create Token
                        var token= tokenRepository.CreateToken(user, roles.ToList());

                        var response = new LoginResponseDto
                        {
                            JwtToken = token,
                        };

                        return Ok(response);
                    }   
                }

            }
            return BadRequest("username or password incorrect");

        }
    }
}