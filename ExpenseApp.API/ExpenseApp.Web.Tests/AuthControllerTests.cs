using ExpenseApp.Business;
using ExpenseApp.Business.Contracts;
using ExpenseApp.Entites;
using ExpenseApp.Repository;
using ExpenseApp.Repository.Contracts;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Xunit;

namespace ExpenseApp.Web.Tests
{
    public class AuthControllerTests
    {
        AuthController _authController;
        IUserManager _userManager;
        IUserRepository _userRepository;
        public AuthControllerTests()
        {
            _userRepository = new UserRepository();
            _userManager = new UserManager(_userRepository);
            _authController = new AuthController(_userManager);
        }
        [Fact]
        public async Task LoginWithGoodCredintials()
        {
            //arrange

            //act 
            var result = await _authController.Login(new Dtos.UserDto() { EmailId = "nunna@gmail.com", Password = "Password@1" });
            //assert
            OkNegotiatedContentResult<User> negResult = Assert.IsType<OkNegotiatedContentResult<User>>(result);
            Assert.NotNull(negResult.Content.Token);
        }
        [Fact]
        public async Task LoginWithBadCredintials()
        {
            //arrange

            //act 
            var result = await _authController.Login(new Dtos.UserDto() { EmailId = "nunna123@gmail.com", Password = "Password@1" });
            //assert
            BadRequestErrorMessageResult badReqResult = Assert.IsType<BadRequestErrorMessageResult>(result);
            Assert.Equal(badReqResult.Message, "Username or password are incorrect");
        }
    }
}
