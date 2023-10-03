using Application.Utilities;
using Domain;
using LotusApi.Models;

namespace Application;

public interface IConceptService:IGenericService<Concept>
{
    IResult AddWithImage(AddConseptDto entity);
}