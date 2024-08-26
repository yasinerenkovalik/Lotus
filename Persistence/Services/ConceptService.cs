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

   

   

}