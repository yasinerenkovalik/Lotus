using Microsoft.AspNetCore.Http;

namespace Domain;

public class Concept:BaseEntity
{
    public string Name { get; set; }
    public string Feature { get; set; }
    public string Image { get; set; }
}