using Microsoft.AspNetCore.Http;

namespace LotusApi.Models;

public class ModificeConseptDto
{
    public int  Id { get; set; }
    public string Name { get; set; }
    public IFormFile Image { get; set; }
    public string   Feacure { get; set; }
}