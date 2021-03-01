using AutoMapper;
using Business.Interface;
using MecPark.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models.Users;
using Org.BouncyCastle.Cmp;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MecPark.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase
    {
        private readonly IUserManager _context;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        public Users(IUserManager context, IOptions<AppSettings> appSettings, IMapper mapper)
        {
            _context = context;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("allocationmanagers")]
        public IActionResult GetAllocationManagers()
        {
            var allocationManagers = _context.GetAllocationManagers();
            return Ok(allocationManagers);
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var user = _context.Authenticate(model.Email, model.Password);

            if (user == null)
                return BadRequest(new { message = "Email or Password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info and authentication token
            return Ok(new
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                Created = user.Created,
                isVerfied = user.IsVerified,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            var user = _mapper.Map<User>(model);
            try
            {
                // create user
                _context.Create(user, model.Password, Request.Headers["origin"]);
                return Ok(new { message = "✓ Registration Success, Please Check Your Email for Verification!" });
            }
            catch (CmpException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.GetUsers();
            return Ok(users);
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var context = HttpContext.User.Identity;
            int userId = int.Parse(context.Name);
            if (id != userId && _context.getRole(userId) != "Admin")
                return Unauthorized(new { message = "Unauthorized" });
            var user = _context.GetUserById(id);
            
            return Ok(user);
        }
        [Authorize]
        [HttpGet("allocationmanagers/{id}")]
        public IActionResult GetAllocationManagerById(int id)
        {
            var context = HttpContext.User.Identity;
            int userId = int.Parse(context.Name);
            if (id != _context.GetAllocationManagerId(userId) && _context.getRole(userId) != "Admin")
                return Unauthorized(new { message = "Unauthorized" });
            var allocationManager = _context.GetAllocationManagerById(id);
            
            return Ok(allocationManager);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("parkingmanagers")]
        public IActionResult GetParkingManagers()
        {
            var parkingManagers = _context.GetParkingManagers();
            
            return Ok(parkingManagers);
        }
        [Authorize]
        [HttpGet("parkingmanagers/{id}")]
        public IActionResult GetParkingManagerById(int id)
        {
            var context = HttpContext.User.Identity;
            int userId = int.Parse(context.Name);
            if (id != _context.GetParkingManagerId(userId) && _context.getRole(userId) != "Admin")
                return Unauthorized(new { message = "Unauthorized" });
            var parkingManager = _context.GetParkingManagerById(id);
            
            return Ok(parkingManager);
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateModel model)
        {
            var context = HttpContext.User.Identity;
            int userId = int.Parse(context.Name);
            if (id != userId && _context.getRole(userId) != "Admin")
                return Unauthorized(new { message = "Unauthorized" });
            // map model to entity and set id
            var user = _mapper.Map<User>(model);
            user.Id = id;

            try
            {
                // update user 
                _context.Update(user, model.Password);
                return Ok();
            }
            catch (CmpException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
