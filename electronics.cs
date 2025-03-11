class Program
{
    public static void Main()
    {
        Laptop laptop = new Laptop("Dell", "XPS 15", 16, 6000);
        Desktop desktop = new Desktop("HP", "Omen 45L", 32, "Mid Tower");
        Smartphone smartphone = new Smartphone("Apple", "iPhone 15", 6.1, 48);
        Tablet tablet = new Tablet("Samsung", "Galaxy Tab S9", 11.0, true);
        Refrigerator refrigerator = new Refrigerator("LG", "InstaView", "A++", 500);
        Microwave microwave = new Microwave("Panasonic", "NN-SN966S", "A+", true);

        List<ElectronicDevices> electronicDevices = new List<ElectronicDevices> { laptop, desktop, smartphone, tablet, refrigerator, microwave };
        foreach (var device in electronicDevices)
        {
            Console.WriteLine(device.GetInfo());
        }
    }
}

//base class
class ElectronicDevices
{
    public string Brand { get; set; }
    public string Model { get; set; }

    public ElectronicDevices(string brand, string model)
    {
        Brand = brand;
        Model = model;
    }
    public virtual string GetInfo()
    {
        return $"brand - {Brand}, model - {Model}";
    }
}

//inherits from base class
class Computers : ElectronicDevices
{
    private int _ram;
    public int RAM
    {
        get
        {
            return _ram;
        }
        set
        {
            if(value <= 0)
            {
                throw new ArgumentException("RAM memory cannot be less than 0");
            }
            else
            {
                _ram = value;
            }
        }
    }
    public Computers(string brand, string model, int ram) : base(brand, model)
    {
        RAM = ram;
    }
    public override string GetInfo()
    {
        return base.GetInfo() + $", RAM - {RAM} GB";
    }
}

//inherits from Computers
class Laptop : Computers
{
    private int _batteryCapacity;
    public int BatteryCapacity 
    {
        get
        {
            return _batteryCapacity;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Capacity cannot be negative");
            }
            else
            {
                _batteryCapacity = value;
            }
        }
    }
    public Laptop(string brand, string model, int ram, int batteryCapacity) : base(brand, model, ram)
    {
        BatteryCapacity = batteryCapacity;
    }
    public override string GetInfo()
    {
        return "Laptop: " + base.GetInfo() + $", battery capacity - {BatteryCapacity}mAh";
    }
}

//inherits from Computers
class Desktop : Computers
{
    public string CaseSize { get; set; }
    public Desktop(string brand, string model, int ram, string caseSize) : base (brand, model, ram)
    {
        CaseSize = caseSize;
    }
    public override string GetInfo()
    {
        return "Desktop: " + base.GetInfo() + $", case size - {CaseSize}";
    }
}

//inherits from base class
class MobileDevices : ElectronicDevices
{
    private double _screenSize;
    public double ScreenSize
    {
        get
        {
            return _screenSize;
        }
        set
        {
            if(value < 0)
            {
                throw new ArgumentException(", Screen size must be a positive number");
            }
            else
            {
                _screenSize = value;
            }
        }
    }
    public MobileDevices(string brand, string model, double screenSize) : base(brand, model)
    {
        ScreenSize = screenSize;
    }
    public override string GetInfo()
    {
        return base.GetInfo() + $", screen size - {ScreenSize}in";
    }
}

//inherits from MobileDevices
class Smartphone : MobileDevices
{
    private int _cameraResolution;
    public int CameraResolution
    {
        get
        {
            return _cameraResolution;
        }
        set
        {
            if(value < 0)
            {
                throw new ArgumentException("Resolution must be a positive number");
            }
            else
            {
                _cameraResolution = value;
            }
        }
    }
    public Smartphone(string brand, string model, double screenSize, int cameraResolution) : base(brand, model, screenSize)
    {
        CameraResolution = cameraResolution;
    }
    public override string GetInfo()
    {
        return "Smartphone: " + base.GetInfo() + $", camera resolution - {CameraResolution}px";
    }
}

//inehirts from MobileDevices
class Tablet : MobileDevices
{
    public bool SIM { get; set; }
    public Tablet(string  brand, string model, double screenSize, bool sim) : base(brand, model, screenSize)
    {
        SIM = sim;
    }
    public override string GetInfo()
    {
        if (SIM)
        {
            return "Tablet: " + base.GetInfo() + $", SIM - yes";

        }
        else
        {
            return "Tablet: " + base.GetInfo() + $", SIM - no";
        }
    }
}

//inherits from base class
class HomeAppliances : ElectronicDevices
{
    public string EnergyRating { get; set; }
    public HomeAppliances(string brand, string model, string energyRating) : base(brand, model)
    {
        EnergyRating = energyRating;
    }
    public override string GetInfo()
    {
        return base.GetInfo() +  $", energy rating - {EnergyRating}";
    }
}

//inherits from HomeAppliances
class Refrigerator : HomeAppliances
{
    private int _capacity;
    public int Capacity
    {
        get
        {
            return _capacity;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Capacity must be a positive number");
            }
            else
            {
                _capacity = value;
            }

        }
    }
    public Refrigerator(string brand, string model, string energyRating, int capacity) : base(brand, model, energyRating)
    {
        Capacity = capacity;
    }
    public override string GetInfo()
    {
        return "Refrigerator: " + base.GetInfo() + $", capacity - {Capacity}L";
    }
} 

//inherits from HomeAppliences
class Microwave : HomeAppliances
{
    public bool CookingOption { get; set; }
    public Microwave(string brand, string model, string energyRating, bool cookingOption) : base(brand, model, energyRating)
    {
        CookingOption = cookingOption;
    }
    public override string GetInfo()
    {
        if (CookingOption)
        {
            return "Microwave: " + base.GetInfo() + $", cooking option - yes";

        }
        else
        {
            return "Microwave: " + base.GetInfo() + $", cooking option - no";
        }
    }
}
