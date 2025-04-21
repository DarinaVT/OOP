public class BankSystem
{
    private Dictionary<string, Client> clients = new();

    public void Run()
    {
        Console.WriteLine("Use the following commands:");
        Console.WriteLine("createUser FirstName LastName Balance");
        Console.WriteLine("withdraw FirstName LastName Amount");
        Console.WriteLine("sendMoney SenderFirstName SenderLastName ReceiverFirstName ReceiverLastName Amount");
        Console.WriteLine("loanMoney FirstName LastName");
        Console.WriteLine("checkBalance FirstName LastName");
        Console.WriteLine("listClients");
        Console.WriteLine("exit");

        while (true)
        {
            Console.Write("\n-");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                continue;
            }

            string[] parts = input.Split(' ');
            string command = parts[0].ToLower();

            if (command == "createuser")
            {
                decimal balance = decimal.Parse(parts[3]);
                Client client = new Client
                {
                    FirstName = parts[1],
                    LastName = parts[2],
                    Balance = balance
                };
                clients[$"{client.FirstName} {client.LastName}"] = client;
                AddClient addClient = new AddClient();
                addClient.Manage(client, balance);
            }
            else if (command == "withdraw")
            {
                string fullName = parts[1] + " " + parts[2];
                if (clients.TryGetValue(fullName, out var client))
                {
                    decimal amount = decimal.Parse(parts[3]);
                    Withdraw withdraw = new Withdraw(client, amount);
                    withdraw.Execute();
                }
            }
            else if (command == "sendmoney")
            {
                string senderFullName = parts[1] + " " + parts[2];
                string receiverFullName = parts[3] + " " + parts[4];
                if (clients.TryGetValue(senderFullName, out var sender) && clients.TryGetValue(receiverFullName, out var receiver))
                {
                    decimal amount = decimal.Parse(parts[5]);
                    SendMoney sendMoney = new SendMoney(sender, receiver, amount);
                    sendMoney.Execute();
                }
            }
            else if (command == "loanmoney")
            {
                string fullName = parts[1] + " " + parts[2];

                if (clients.TryGetValue(fullName, out var client))
                {
                    Console.WriteLine("Which loan are you requesting");
                    Console.WriteLine("1 - Front office loan (up to 10,000)");
                    Console.WriteLine("2 - Regional office loan (up to 50,000)");
                    Console.Write("> ");
                    string choice = Console.ReadLine();

                    decimal amount;
                    Console.Write("Enter loan amount: ");
                    if (!decimal.TryParse(Console.ReadLine(), out amount))
                    {
                        Console.WriteLine("Invalid amount");
                        continue;
                    }

                    var front = new FrontOffice();
                    var regional = new RegionalOffice();

                    if (choice == "1")
                    {
                        front.Manage(amount, client);
                    }
                    else if (choice == "2")
                    {
                        regional.Manage(amount, client);
                    }
                    else
                    {
                        Console.WriteLine("No such loan type");
                    }
                }
            }
            else if (command == "checkbalance")
            {
                string fullName = parts[1] + " " + parts[2];
                if (clients.TryGetValue(fullName, out var client))
                {
                    CheckBalance checkBalance = new CheckBalance(client);
                    checkBalance.Execute();
                }
            }
            else if (command == "listclients")
            {
                Console.WriteLine("Clients of the bank:");
                foreach (var client in AddClient.Clients)
                {
                    Console.WriteLine(client.FirstName + ' ' + client.LastName);
                }
            }
            else if (command == "exit")
            {
                break;
            }
            else
            {
                Console.WriteLine("No such command");
            }
        }
    }
}
