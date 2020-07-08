using ExpenseApp.Business.Contracts;
using ExpenseApp.Entites;
using ExpenseApp.Repository.Contracts;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseApp.Business
{
    public class UserManager : IUserManager
    {
        readonly IUserRepository _userRepository;
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AuthenticateUser(string emailId, string password)
        {
            var user = await _userRepository.GetUserByEmailIdAsync(emailId);


            // return null if user not found
            if (user == null)
                return null;

            user.Token = CreateToken(emailId);
            return user;
        }
        private string CreateToken(string email)
        {
            //Set issued at date
            DateTime issuedAt = DateTime.UtcNow;
            //set the time when it expires
            DateTime expires = DateTime.UtcNow.AddDays(7);

            //http://stackoverflow.com/questions/18223868/how-to-encrypt-jwt-security-token
            var tokenHandler = new JwtSecurityTokenHandler();

            //create a identity and add claims to the user which we want to log in
            var claimsIdentity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, email)
            });

            const string secrectKey = "your secret key goes here";
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secrectKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);


            //Create the jwt (JSON Web Token)
            //Replace the issuer and audience with your URL (ex. http:localhost:12345)
            var token =
                (JwtSecurityToken)
                tokenHandler.CreateJwtSecurityToken(
                    subject: claimsIdentity,
                    notBefore: issuedAt,
                    expires: expires,
                    signingCredentials: signingCredentials);

            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        public Task<User> GetUserById(int _userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Register(User user)
        {
            return await _userRepository.RegisterAsync(user);
        }
    }
}
