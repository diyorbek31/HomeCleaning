using HomeCleaning.Domain.Commons;

namespace HomeCleaning.Domain.Entities;

public class User : Auditable
{
    public string Name {  get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
