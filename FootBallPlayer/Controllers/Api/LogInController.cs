using FootBallPlayer.Models;
using FootBallPlayer.Models.Dto;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace FootBallPlayer.Controllers.Api
{
    [Route("api/LogIn")]
    public class LogInController : ApiController
    {
        private readonly ApplicationDbContext db;
        //private ApplicationSignInManager _signInManager;
        //private ApplicationUserManager _userManager;
        //public ApplicationSignInManager SignInManager
        //{
        //    get
        //    {
        //        return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
        //    }
        //    private set
        //    {
        //        _signInManager = value;
        //    }
        //}

        //public ApplicationUserManager UserManager
        //{
        //    get
        //    {
        //        return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //    }
        //    private set
        //    {
        //        _userManager = value;
        //    }
        //}

        public LogInController()
        {
            db = new ApplicationDbContext();

        }

    
        //public LogInController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, ApplicationDbContext db)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //    db = new ApplicationDbContext();
        //}

        [HttpPost]
        [AllowAnonymous]
        //[System.Web.Mvc.ValidateAntiForgeryToken]

        public IHttpActionResult SignIn([FromBody]SignInDto dto)
        {

            var user = db.Users.FirstOrDefault(x => x.PhoneNumber == dto.Phonenumber&&x.UserName==dto.UName);
            if (user == null)
            {
                return Ok("USER NULLL");
            }
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var userdto = new UserDto { Email = user.Email, Fullname = user.YourName, UserId = user.Id };
                //var result =
                //     _signInManager.PasswordSignIn(dto.UName, dto.Password, false, false);

                //switch (result)
                //{
                //    case SignInStatus.Success:
                //        return Ok(userdto);
                //    case SignInStatus.Failure:
                //        return Ok("Problem:Failure");
                //    default:
                //        return Ok("Problem");
                //}
                /*
                if (result)
                {
                    var user = db.Users.FirstOrDefault(x => x.UserName == dto.UName);
                    var userr = new UserDto { FullName = user.FirstName + " " + user.LastName, IsOnline = dto.IsOnline, UserId = user.Id };
                    return Ok(userr);
                }
                */
                return Ok(userdto);
            }
            //ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            //s = "Invalid Login attempt. Or Something went bad!";
            //return Ok(s);
            return Ok("some problem");
        }


    }
}
