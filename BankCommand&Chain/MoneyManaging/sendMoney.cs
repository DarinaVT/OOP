public class SendMoney : ICommand
{
    private readonly Client _sender;
    private readonly Client _receiver;
    private readonly decimal _amount;

    public SendMoney(Client sender, Client receiver,  decimal amount)
    {
        _sender = sender;
        _receiver = receiver;
        _amount = amount;
    }
    public void Execute()
    {
        if (_sender.HasEnoughBalance(_amount))
        {
            _sender.Balance -= _amount;
            _receiver.Balance += _amount;
            Console.WriteLine($"{_sender.FirstName} {_sender.LastName} sent {_receiver.FirstName} {_receiver.LastName} {_amount}");
        }
        else
        {
            Console.WriteLine($"\n{_sender.FirstName} {_sender.LastName} does not have enough money");
            Console.WriteLine($"Balance: {_sender.Balance}");
        }
    }
}
