public class CreateClient : ICommand
{
    private readonly Client _client;
    private readonly ManageClient _manager;
    public CreateClient(Client client, ManageClient manager)
    {
        _client = client;
        _manager = manager;
    }
    public void Execute()
    {
        _manager.Manage(_client, _client.Balance);
    }
}
