using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ProjectWork.Web.Models;
using ProjectWork.Services;
using ProjectWork.Entities;
using AutoMapper;
using System.Collections.ObjectModel;
using ProjectWork.Web.Infrastructure.Core;
using ProjectWork.Data;

namespace ProjectWork.Web.Controllers
{
    [Authorize]
    [RoutePrefix("api/State")]

    public class StateController : ApiControllerBase
    {
        private readonly IStateService _stateService;

        public StateController(IStateService stateService, IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork)
            : base(_errorsRepository, _unitOfWork)
        {
            _stateService = stateService;
        }



        [Route("updateState")]
        [HttpPut]
        //[ResponseType(typeof(Schedule))]
        public async Task<IHttpActionResult> UpdateState(StateViewModel state)
        {
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            State stateObj = new State();

            stateObj = Mapper.Map<StateViewModel, State>(state);
            var result = await _stateService.UpdateStatus(stateObj);
            return Ok(result);
            
            
        }

        [Route("GetState/{ContactInfoDetails_ID:int}")]
        [HttpGet]
        //[ResponseType(typeof(Schedule))]
        public async Task<IHttpActionResult> GetState(int ContactInfoDetails_ID)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            var result = await _stateService.GetStatus(ContactInfoDetails_ID);
            return Ok(result);
        }
    }



}
