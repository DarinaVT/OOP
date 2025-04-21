public interface IAccount
{
    protected float Balance { get; set; }
    protected float InterestRate { get; set; }
    protected DateTime DateOpen { get; set; }
    protected int MonthsPassed { get; set; }

    protected void Deposit(float amount);
    protected float Interest();
}

public interface IClient
{
    protected string Name { get; }
    protected string Address { get; }
}

public abstract class Client : IClient
{
    public string Name { get; set; }
    public string Address { get; set; }

    protected Client(string name, string address)
    {
        Name = name;
        Address = address;
    }
}

public abstract class Account : IAccount
{
    public IClient Client { get; set; }
    public float Balance { get; set; }
    public float InterestRate { get; set; }
    public DateTime DateOpen { get; set; }
    public int MonthsPassed { get; set; }

    public Account(IClient client, float balance, float interestRate, DateTime dateOpen)
    {
        Client = client;
        Balance = balance;
        InterestRate = interestRate;
        DateOpen = dateOpen;
    }

    public void Deposit(float amount)
    {
        Balance += amount;
    }

    public abstract float Interest();
}
public class Individual : Client
{
    public string LastName { get; set; }

    public Individual(string name, string address, string lastName) : base(name, address)
    {
        LastName = lastName;
    }
}

public class Company : Client
{
    public string LEI { get; set; }

    public Company(string name, string address, string lei) : base(name, address)
    {
        LEI = lei;
    }
}

public class Deposit : Account
{
    public Deposit(IClient client, float balance, float interestRate, DateTime dateOpen) : base(client, balance, interestRate, dateOpen)
    {
        if (balance > 0 && balance <= 1000)
        {
            InterestRate = 0;
        }
    }

    public override float Interest()
    {
        DateTime currentDate = DateTime.Now;
        MonthsPassed = ((currentDate.Year - DateOpen.Year) * 12) + currentDate.Month - DateOpen.Month;

        if (Balance > 1000 || Balance < 0)
        {
            return MonthsPassed * InterestRate;
        }

        return 0;
    }
}

public class Loan : Account
{
    public Loan(IClient client, float balance, float interestRate, DateTime dateOpen) : base(client, balance, interestRate, dateOpen)
    {
    }

    public override float Interest()
    {
        DateTime currentDate = DateTime.Now;
        MonthsPassed = ((currentDate.Year - DateOpen.Year) * 12) + currentDate.Month - DateOpen.Month;

        if (Client is Individual && MonthsPassed < 4)
        {
            return 0;
        }
        else if (Client is Company && MonthsPassed < 3)
        {
            return 0;
        }

        return MonthsPassed * InterestRate;
    }
}

public class Mortgage : Account
{
    public Mortgage(IClient client, float balance, float interestRate, DateTime dateOpen) : base(client, balance, interestRate, dateOpen)
    {
    }

    public override float Interest()
    {
        DateTime currentDate = DateTime.Now;
        MonthsPassed = ((currentDate.Year - DateOpen.Year) * 12) + currentDate.Month - DateOpen.Month;

        if (Client is Company && MonthsPassed < 13)
        {
            return (MonthsPassed * InterestRate) / 2;
        }
        else if (Client is Individual && MonthsPassed < 7)
        {
            return 0;
        }

        return MonthsPassed * InterestRate;
    }
}
