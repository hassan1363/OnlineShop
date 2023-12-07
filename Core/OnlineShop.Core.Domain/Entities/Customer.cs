using OnlineShop.Core.Domain.Common;

namespace OnlineShop.Core.Domain.Entities;
public class Customer : BaseEntity<long>
{
    public string FirtsName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}
