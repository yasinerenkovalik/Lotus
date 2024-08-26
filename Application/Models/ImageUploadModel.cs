using Microsoft.AspNetCore.Http;

namespace LotusApi.Models;

public class ImageUploadModel
{
    public string Name { get; set; }
    public string Title { get; set; }
    public string Feature { get; set; }
    public List<IFormFile> Images { get; set; } // Birden fazla resim yüklemek için liste kullanın

}