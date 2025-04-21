public class Client
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal Balance { get; set; }
    public bool HasEnoughBalance(decimal amount) => Balance >= amount;
    public string Email { get; set; }
}
