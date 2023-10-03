using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Utilities;
using Domain;
using LotusApi.Models;
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

        [HttpPost("add")]
        public Result Add([FromForm]AddConseptDto  addConseptDto)
        {
         
            var result = _conceptService.AddWithImage(addConseptDto);
            if (result.Success == false)
            {
                return new ErrorResult(result.Message);
            }

            return new SuccesResult(result.Message);
        }

        [HttpGet("getall")]
        public IDataResult<List<Concept>> GetAll()
        {
            var result = _conceptService.GetAll();
            
            return  result;
        }
        [HttpGet("get")]
        public IDataResult<Concept> Get(int id)
        {
            var result = _conceptService.Get(id);
            
            return  result;
        }

        [HttpPost("update")]
        public IActionResult Update(Concept concept)
        {
            var result = _conceptService.Update(concept);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _conceptService.Delete(id);
            return Ok(result);
        }
       
        
          /*  [HttpPost("upload")]
            public IActionResult UploadFile(IFormFile file)
            {
                try
                {
                    if (file == null || file.Length == 0)
                    {
                        return BadRequest("Dosya boş veya eksik.");
                    }

                    using (var memoryStream = new MemoryStream())
                    {
                        file.CopyTo(memoryStream);

                        byte[] bytes = memoryStream.ToArray();
                        string base64String = Convert.ToBase64String(bytes);

                        return Ok(new { Base64String = base64String });
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"İşlem sırasında bir hata oluştu: {ex.Message}");
                }
            }*/
        }

        
    }

