using Application;
using Application.Repository;
using Application.Utilities;
using Domain;
using LotusApi.Models;


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
            _conceptRepository.Delete(id);
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
        var result = _conceptRepository.GetAll(e => e.Active == true);
        return new SuccessDataResult<List<Concept>>(result);
    }

   

    public IResult AddWithImage(AddConseptDto entity)
    {
        if (!string.IsNullOrEmpty(entity.Name) && entity.Image != null)
        {
            Concept concept = new Concept();
            concept.Name = entity.Name;
            concept.Feature = entity.Feature;
            concept.CreatedDate = DateTime.UtcNow;
            concept.Active = true;

            using (var memoryStream = new MemoryStream())
            {
                entity.Image.CopyTo(memoryStream);
                byte[] bytes = memoryStream.ToArray();
                string base64String = Convert.ToBase64String(bytes);
                concept.Image = base64String;
            }

            if (entity.Image2 != null)
            {
                using (var memoryStream2 = new MemoryStream())
                {
                    entity.Image2.CopyTo(memoryStream2);
                    byte[] bytes2 = memoryStream2.ToArray();
                    string base64String2 = Convert.ToBase64String(bytes2);
                    concept.Image2 = base64String2;
                }
            }

            if (entity.Image3 != null)
            {
                using (var memoryStream3 = new MemoryStream())
                {
                    entity.Image3.CopyTo(memoryStream3);
                    byte[] bytes3 = memoryStream3.ToArray();
                    string base64String3 = Convert.ToBase64String(bytes3);
                    concept.Image3 = base64String3;
                }
            }

            _conceptRepository.AddWithImage(concept);
            return new SuccesResult("Konsept Başarıyla Eklendi");
        }
        else
        {
            return new ErrorResult("Lütfen geçerli bir isim ve ana resim sağlayın.");
        }
    }

}