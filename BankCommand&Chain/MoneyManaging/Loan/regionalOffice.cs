public class RegionalOffice : LoanRequest
{
    public override void Manage(decimal amount, Client client)
    {
        if (amount <= 50000)
        {
            client.Balance += amount;
            Console.WriteLine($"\nRegional office manager loan approved for {client.FirstName} {client.LastName}");
        }
        else
        {
            Console.WriteLine($"\nRegional office loan was not approved for {client.FirstName} {client.LastName}");
        }
    }
}
