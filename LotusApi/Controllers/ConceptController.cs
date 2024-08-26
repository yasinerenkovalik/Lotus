
using Application;
using Application.Utilities;
using Domain;
using LotusApi.Models;
using Microsoft.AspNetCore.Authorization;
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

 
        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadModel model)
        {
            var fileNames = new List<string>();

            if (model.Images != null && model.Images.Count > 0)
            {
                foreach (var image in model.Images)
                {
                    // Gün ve ay bilgilerini al
                    var today = DateTime.Today;
                    // Fotoğraf adını gün ve ay bilgileri ile oluştur
                    var fileName = $"{today:yyyyMMdd}-{image.FileName}";
                    var filePath = Path.Combine("wwwroot/uploads", fileName);

                    // Dosyayı belirtilen dizine kaydet
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    fileNames.Add(fileName);
                }
            }
    
            var fileNamesString = string.Join(", ", fileNames);

            Concept concept = new Concept
            {
                Name = model.Name,
                Feature = model.Feature,
                Images = fileNamesString,
                Title = model.Title,
                Active = true,
                CreatedDate = DateTime.Now
            };

            _conceptService.Add(concept);

            return Ok(new { fileNames = fileNamesString });
        }



        [AllowAnonymous]
        [HttpGet("getall")]
        public IDataResult<List<Concept>> GetAll()
        {
            var result = _conceptService.GetAll();
            
            return  result;
        }
        
        [AllowAnonymous]
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
       
        
          
        }

        
    }

