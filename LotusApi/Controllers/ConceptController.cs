using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Utilities;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LotusApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConceptController : ControllerBase
    {
        private readonly IConceptService _conceptService;

        public ConceptController(IConceptService conceptService)
        {
            _conceptService = conceptService;
        }

        [HttpPost]
        public Result Add(Concept concept)
        {
            var result = _conceptService.Add(concept);
            if (result.Success == false)
            {
                return new ErrorResult(result.Message);
            }

            return new SuccesResult(result.Message);
        }

        [HttpGet]
        public DataResult<List<Concept>> GetAll()
        {
            var result = _conceptService.GetAll();
            if (result.Success==false)
            {
              return  new ErrorDataResult<List<Concept>>(result.Message);
            }

            return new SuccessDataResult<List<Concept>>(result.Data,result.Message);
        }
    }
}
