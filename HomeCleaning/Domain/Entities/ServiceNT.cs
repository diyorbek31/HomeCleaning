using HomeCleaning.Domain.Commons;

namespace HomeCleaning.Domain.Entities;

public class ServiceNT : Auditable
{
    public string Name {  get; set; }
    public string Description { get; set; }
}
