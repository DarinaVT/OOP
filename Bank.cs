using System;
using System.Globalization;

class Bank
{
    public static void Main()
    {
        Accountee ordinaryUser = new Accountee("Иван Петров", 48000);
        Special specialUser = new Special("Петър Иванов", 50000);
        Console.WriteLine(ordinaryUser.Status());
        Console.WriteLine(specialUser.Status());
    }
}

class Accountee
{
    public string Name { get; set; }
    public double Balance { get; set; }

    public Accountee(string name, double balance)
    {
        Name = name;
        Balance = balance;
    }

    public virtual string Status()
    {
        double converted = Balance * 1.798;
        CultureInfo culture = new CultureInfo("bg-BG");
        return $"Name: {Name}, balance: {converted.ToString("C", culture)}";
    }
}

class Special : Accountee
{
    public Special(string name, double balance) : base(name, balance)
    {
    }

    public override string Status()
    {
        double conversion = Balance * 1.798;
        double interest = conversion + (conversion * 0.02);
        CultureInfo culture = new CultureInfo("bg-BG");
        return $"Hello, {Name}, balance: {interest.ToString("C", culture)}";
    }
}
