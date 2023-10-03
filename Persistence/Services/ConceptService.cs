using Application;
using Application.Repository;
using Application.Utilities;
using Domain;
using LotusApi.Models;
using Microsoft.AspNetCore.Http;

namespace Persistence.Services;

public class ConceptService:IConceptService
{
    private readonly IConceptRepository _conceptRepository;

    public ConceptService(IConceptRepository conceptRepository)
    {
        _conceptRepository = conceptRepository;
    }
    public IResult Add(Concept entity)
    {
        if (entity.Name==null)
        {
            return new ErrorResult("Konsept Adı Boş Geçilemez ");
        }
        _conceptRepository.Add(entity);
        return new SuccesResult("Konsept Eklendi");

    }

    public IResult Delete(int id)
    {
        if (id>0)
        {
            return new SuccesResult("Başarılı Bir Şekilde Silindi");
        }
        return new ErrorResult();
    }

    public IResult Update(Concept entity)
    {
        if (entity.Id > 0)
        {
            _conceptRepository.Update(entity);
            return new SuccesResult("ürün güncellendi");
        }

        return new ErrorResult("ürün güncellenemedi");
    }

    public IDataResult<Concept> Get(int id)
    {
        var result = _conceptRepository.Get(id);
        if (result.Id<=0)
        {
            return new ErrorDataResult<Concept>("Ürün Bulunamadı");
        }

        return new SuccessDataResult<Concept>(result);
    }

    public IDataResult<List<Concept>> GetAll()
    {
      var result=  _conceptRepository.GetAll();
      return  new SuccessDataResult<List<Concept>>(result);
    }

    public IResult AddWithImage(AddConseptDto entity)
    {
        if (!string.IsNullOrEmpty(entity.Name) )
        {
            Concept concept = new Concept();
            concept.Name = entity.Name;
            concept.Feature = entity.Feacure;
            concept.CreatedDate=DateTime.UtcNow;
            concept.Active = true;
            using (var memoryStream = new MemoryStream())
            {
                entity.Image.CopyTo(memoryStream);

                byte[] bytes = memoryStream.ToArray();
                string base64String = Convert.ToBase64String(bytes);
                concept.Image = base64String;
              
            }
   
           
            _conceptRepository.AddWithImage(concept);
            return new SuccesResult("Konsept Başarıyla Eklendi");
        }

        return new ErrorResult("hata oluşut");


    }
}