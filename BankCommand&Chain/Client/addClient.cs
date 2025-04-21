public class AddClient : ManageClient
{
    public static List<Client> Clients = new List<Client>();
    public override void Manage(Client client, decimal balance)
    {
        Clients.Add(client);
        Console.WriteLine($"\n{client.FirstName} {client.LastName} with balance of {balance} was succesfully added in the bank system");
        base.Manage(client, balance);
    }
}
