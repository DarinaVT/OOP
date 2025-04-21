public class Withdraw : ICommand
{
    private readonly Client _client;
    private readonly decimal _amount;

    public Withdraw(Client client, decimal amount)
    {
        _client = client;
        _amount = amount;
    }

    public void Execute()
    {
        if (_client.HasEnoughBalance(_amount))
        {
            _client.Balance -= _amount;
            Console.WriteLine($"\n{_client.FirstName} {_client.LastName} withdrew {_amount}");
            Console.WriteLine($"Current balance now is {_client.Balance}");
        }
        else
        {
            Console.WriteLine($"\n{_client.FirstName} {_client.LastName} cannot withdraw this amount due to insufficient funds");
            Console.WriteLine($"Balance: {_client.Balance}");
        }
    }
}
