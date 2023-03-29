using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using UserMicroservice.Data_Access;
using ProductMicroservice.Models;
using ProductMicroservice.Data_Access;
using UserMicroservice.Models.dto;

namespace UserMicroservice.Repository
{
    public class UserloginRepo:Iuserlogin
    {
        private readonly CapstoneDbContext _context;
        private readonly IConfiguration _configuration;
        public UserloginRepo(CapstoneDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public Users authenticate(Users userLoginInfo)
        {
            var currentUser = _context.Users.Where(o => o.Username == userLoginInfo.Username && o.Password == userLoginInfo.Password).FirstOrDefault();
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;

        }

        public string generateToken(Users user)
        {
            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
            //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //var claims = new Claim[]
            //{
            //    new Claim(ClaimTypes.NameIdentifier, user.FirstName),
            //    new Claim(ClaimTypes.Email, user.Email),
            //    new  Claim(ClaimTypes.Role,user.Role),
            //};

            //var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
            //    _configuration["Jwt:Audience"],
            //    claims,

            //    expires: DateTime.Now.AddMinutes(15),
            //    signingCredentials: credentials);

            //return new JwtSecurityTokenHandler().WriteToken(token);

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:key"]);
            var identity = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.NameIdentifier, user.FirstName),
               new Claim(ClaimTypes.Email, user.Email),
               new  Claim(ClaimTypes.Role,user.Role),
               new Claim("Username", user.Username), // Add a custom claim for the username
            }

                );
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDes = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials

            };

            var token = jwtTokenHandler.CreateToken(tokenDes);
            return jwtTokenHandler.WriteToken(token);

        }

        public loginresultdto Login(Users userLoginInfo)
        {
            var currentUser = authenticate(userLoginInfo);
            if (currentUser != null)
            {
                var token =  generateToken(currentUser);
                return new loginresultdto()
                {
                    Token = token,
                    Username = currentUser.Username,
                    UserId = currentUser.Id
                };
            }
            return null;
        }


        public void registerUsers(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
