using BlogMicroservice.AuthService.DTOs;
using BlogMicroservice.AuthService.Models;
using BlogMicroservice.AuthService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace BlogMicroservice.AuthService.Controllers
{
    
    [ApiController]
    public class AuthController : ControllerBase
    {
        /*
         * 1️. [HttpPost("route")] is a shortcut → It combines HTTP method + route in one line.
           2️. [HttpPost] [Route("route")] is more flexible → You can use [Route] with multiple HTTP verbs:
         */

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

        public AuthController(UserManager<ApplicationUser> userManager,ITokenService tokenService )
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost(ApiEndpoints.Auth.Login)]
        public async Task<ActionResult<ResponseDto>> Login([FromBody] DTOs.LoginRequest request)
        {
           var user = await _userManager.FindByEmailAsync(request.Email);

            if(user == null)
            {
                return new ResponseDto
                {
                    Email = null,
                    Errors = "User Not Found",
                    Message = "Login Failed",
                    Token = null
                };
              }
            var result = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!result)
            {
                return new ResponseDto
                {
                    Email = null,
                    Errors = "Invalid Password",
                    Message = "Login Failed",
                    Token = null
                };
            }
            return new ResponseDto
            {
                Email = user.Email,
                Errors = null,
                Message = "Login Successfully",
                Token = await _tokenService.GenerateAccessToken(user)
            };
            
        }


        [HttpPost]
        [Route(ApiEndpoints.Auth.Register)]
        public async Task<ActionResult<ResponseDto>> Register([FromBody] DTOs.RegisterRequest request)
        {
            var user = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.Email,

            };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                return new ResponseDto
                {
                    Email = null,
                    Errors = result.Errors.FirstOrDefault()?.Description,
                    Message = "User Registration Failed",
                    Token = null
                };
            }


            return new ResponseDto
            {
                Email = user.Email,
                Errors = null,
                Message = "User Registration Successfully",
                Token = await _tokenService.GenerateAccessToken(user)
                
            };
            
        }


    }
}
