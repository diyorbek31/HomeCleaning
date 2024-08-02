using HomeCleaning.Domain.Commons;

namespace HomeCleaning.Domain.Entities;

public class Provider : Auditable
{
    public string Name {  get; set; }
    public string Service { get; set; }
    public string AvailableTime { get; set; }
    public decimal Price {  get; set; }
}
