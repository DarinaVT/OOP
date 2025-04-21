public class CheckBalance : ICommand
{
    private readonly Client _client;

    public CheckBalance(Client client)
    {
        _client = client;
    }

    public void Execute()
    {
        Console.WriteLine($"{_client.FirstName} {_client.LastName}'s balance is: {_client.Balance}");
    }
}
