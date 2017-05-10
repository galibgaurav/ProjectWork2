using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ProjectWork.Data;
using ProjectWork.Entities;
using ProjectWork.Services;
using ProjectWork.Web;
using ProjectWork.Web.Infrastructure.Core;
using ProjectWork.Web.Models;
namespace ProjectWork.Web.Controllers
{
    
    [RoutePrefix("api/UserHome")]
    public class UserHomeController : ApiControllerBase
    {
        public UserHomeController(IMembershipService membershipService, IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            :base(_errorsRepository,_unitOfWork)
        {
           
        }
        [Authorize]
        [HttpGet]
        [Route("GetProjects")]
        public HttpResponseMessage Get (HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () => {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, new { success = false });
                }
                else
                {
                    //var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };
                    //Entities.User _user = _membershipService.CreateUser(user.Username, user.Email, user.Password, new int[] { 1 });
                    //IdentityResult result = UserManager.Create(user, model.Password);
                    var ProjectList = new ProjectDatabase();

                    if (ProjectList != null)
                    {
                        
                            response = request.CreateResponse(HttpStatusCode.OK, ProjectList, "application/json");
                    }
                    else
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                    }
                }

                return response;
            });


        }
    }
}
