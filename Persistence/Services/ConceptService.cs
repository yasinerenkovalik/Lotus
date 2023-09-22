using Application;
using Application.Repository;
using Application.Utilities;
using Domain;

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
            return new ErrorResult("Konsept Eklenirken Hata Oluştu");
         
        }

       var result= _conceptRepository.Add(entity);
       if (result.Success==false)
       {
           return new ErrorResult("Konsept Eklenirken başka bir hata");
       }
       
        return new SuccesResult("Konsept Eklendi");

    }

    public IResult Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IResult Update(Concept entity)
    {
        throw new NotImplementedException();
    }

    public IDataResult<Concept> Get(int id)
    {
        throw new NotImplementedException();
    }

    public IDataResult<List<Concept>> GetAll()
    {
      var result=  _conceptRepository.GetAll();
      
      Console.WriteLine(result);
      return new SuccessDataResult<List<Concept>>();
    }
}