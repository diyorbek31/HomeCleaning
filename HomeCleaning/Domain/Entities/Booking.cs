using HomeCleaning.Domain.Commons;

namespace HomeCleaning.Domain.Entities;

public class Booking : Auditable
{
    public string UserEmail {  get; set; }
    public string Service {  get; set; }
    public string Provider {  get; set; }
    public string Time {  get; set; }
}
