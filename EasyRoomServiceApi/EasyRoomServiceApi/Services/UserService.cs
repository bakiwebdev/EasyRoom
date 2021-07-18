using EasyRoomServiceApi.Data;
using EasyRoomServiceApi.Models;
using EasyRoomServiceApi.Request;
using EasyRoomServiceApi.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace EasyRoomServiceApi.Services
{
    public class UserService
    {
        private readonly EasyRoomContext _dbContext;
        private readonly JWTSettings _jwtsettings;

        public UserService(EasyRoomContext dbContext, IOptions<JWTSettings> jwtsettings)
        {
            _dbContext = dbContext;
            _jwtsettings = jwtsettings.Value;
        }
        /// <summary>
        /// return all exited user.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetAllUsers()
        {

            List<UserResponse> userResponses = new();

            var user = await _dbContext.Users.ToListAsync();

            foreach (var u in user)
            {
                UserResponse temp = new()
                {
                    ID = u.ID,
                    Firstname = u.FirstName,
                    Lastname = u.LastName,
                    Username = u.Username,
                    Email = u.Email,
                    BirthDate = u.BirthDate.Date.ToString("dd-MM-yyyy"),
                    Gender = u.Gender.ToString()
                };

                userResponses.Add(temp);
            }

            return userResponses;
        }
        /// <summary>
        /// return user based on the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult<UserResponse>> GetUserByID(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            try
            {

                var result = await _dbContext.Users.FindAsync(id);

                if (result == null)
                {
                    return null;
                }

                UserResponse user = new()
                {
                    ID = result.ID,
                    Firstname = result.FirstName,
                    Lastname = result.LastName,
                    Username = result.Username,
                    Email = result.Email,
                    BirthDate = result.BirthDate.Date.ToString("dd-MM-yyyy"),
                    Gender = result.Gender.ToString()
                };

                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// //requires user id to change the detail(firstname, lastname, email)
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> ChangeUserDetail(UserRequest user)
        {
            try
            {
                var result = await _dbContext.Users.FindAsync(user.ID);

                if (result != null)
                {
                    result.FirstName = user.Firstname;
                    result.LastName = user.Lastname;
                    result.Email = user.Email;

                    await _dbContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
        /// <summary>
        /// Cratee new user, all data must be specifed except ID
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<UserResponse> CreateUser(UserRequest user)
        {
            if (user == null)
            {
                return null;
            }

            if (user.Gender != null)
            {
                Gender gender;

                if (user.Gender == "male" || user.Gender == "Male")
                {
                    gender = Gender.Male;

                }
                else
                {
                    gender = Gender.Female;
                }

                User newUser = new()
                {
                    FirstName = user.Firstname,
                    LastName = user.Lastname,
                    Username = user.Username,
                    Password = user.Password,
                    Email = user.Email,
                    BirthDate = user.BirthDate,
                    Gender = gender
                };
                _dbContext.Users.Add(newUser);
            }

            await _dbContext.SaveChangesAsync();


            var request = new LoginRequest()
            {
                Username = user.Username,
                Password = user.Password
            };
            return await IsUserHasAnAccount(request);
        }

        /// <summary>
        /// This willl check if the user has an account or not, and then return the detail back.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UserResponse> IsUserHasAnAccount(LoginRequest request)
        {
            if (request == null)
            {
                return null;
            }

            var result = await _dbContext.Users
                .Where(filter => filter.Username == request.Username && filter.Password == request.Password)
                .FirstOrDefaultAsync();

            if (result == null)
            {
                return null;
            }

            UserResponse user = new()
            {
                ID = result.ID,
                Token = null,
                Firstname = result.FirstName,
                Lastname = result.LastName,
                Username = result.Username,
                Email = result.Email,
                BirthDate = result.BirthDate.Date.ToString("dd-MM-yyyy"),
                Gender = result.Gender.ToString()
            };

            //sign your token here ...
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtsettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddMonths(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;

        }

    }
}
