using Domain;
using Microsoft.AspNetCore.Http;

namespace LotusApi.Models;

public class AddConseptDto
{
    public string Name { get; set; }
    public IFormFile Image { get; set; }
    public IFormFile Image2 { get; set; } // Nullable olarak tanımlandı
    public IFormFile Image3 { get; set; } // Nullable olarak tanımlandı
    public string Feature { get; set; }
}
