using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Contracts.Services;
using Infrastructure.Service;
using ApplicationCore.Entities;
using ApplicationCore.Models;
/*
        Task<int> UpdateCandidateAsync(CandidateRequestModel model);
        Task<int> DeleteCandidateAsync(int id);
        //Task <CandidateInfoResponseModel> GetCandidateInfo(int id);
        Task<IEnumerable<CandidateResponseModel>> GetAllCandidates();
        Task<CandidateResponseModel> GetCandidateByIdAsync(int id);
 */


namespace HRAPI.Controllers
{
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        // GET: api/values
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            var candidate = _candidateService.GetCandidateByIdAsync(id);
            return Ok(candidate);

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        [Route("GetAllCandidate")]
        public IActionResult GetAllCandidate()
        {
            var result = _candidateService.GetAllCandidates;
            return Ok(result);
        }

        [HttpPost]
        [Route("CreateUser")]
        public IActionResult CreateCandidate(string firstname, string lastname, string email)
        {
            var candidate = new CandidateRequestModel { FirstName = firstname, LastName = lastname, Email = email };
            _candidateService.AddCandidateAsync(candidate);
            return Ok(candidate);
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, string firstname, string lastname, string email)
        {
            var model = new CandidateRequestModel { FirstName = firstname, LastName = lastname, Email = email };
            try
            {
                var result = _candidateService.UpdateCandidateAsync(model);
                return Ok(result);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(id);
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var res = _candidateService.DeleteCandidateAsync(id);
                return Ok(res);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("oops");
            }
        }
    }
}

