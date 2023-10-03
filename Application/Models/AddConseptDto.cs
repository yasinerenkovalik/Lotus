using Domain;
using Microsoft.AspNetCore.Http;

namespace LotusApi.Models;

public class AddConseptDto
{
    public string Name { get; set; }
    public IFormFile Image { get; set; }
    public string   Feacure { get; set; }
}