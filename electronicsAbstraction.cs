class Program
{
    static void Main()
    {
        Store store = new Store();

        //IPersonalDevice
        store.AddProduct(new Laptop("Dell XPS 15", 1599.99, 12));
        store.AddProduct(new Smartphone("iPhone 15 Pro", 1099.99, 48));
        store.AddProduct(new Tower("Corsair Vengeance Gaming PC", 1899.99, "ATX"));

        //IOfficeDevice
        store.AddProduct(new Printer("HP LaserJet Pro MFP M227fdw", 299.99, 28));
        store.AddProduct(new Scanner("Canon CanoScan LiDE 400", 89.99, 4800));
        store.AddProduct(new Shredder("Fellowes Powershred 79Ci", 179.99, 16));

        //IHomeAppliance
        store.AddProduct(new Refrigerator("Samsung Family Hub", 2699.99, 600));
        store.AddProduct(new Microwave("Panasonic NN-SN686S", 189.99, 1200));
        store.AddProduct(new Oven("LG Smart Wi-Fi Convection Oven", 1299.99, 250));

        //ICleaning
        store.AddProduct(new Spray("Endust Electronics Cleaning Spray", 7.99, 300));
        store.AddProduct(new MicrofiberCloth("MagicFiber Cleaning Cloth", 9.99, 320));
        store.AddProduct(new Wipe("Clorox Disinfecting Wipes", 5.99, true));

        //IProtection
        store.AddProduct(new CoolingPad("Havit HV-F2056 Laptop Cooling Pad", 24.99, 2800));
        store.AddProduct(new CableOrganiser("JOTO Cord Management System", 14.99, 10));
        store.AddProduct(new ScreenProtector("amFilm Tempered Glass for iPhone", 12.99, "9H"));

        //IRepairment
        store.AddProduct(new ToolKit("iFixit Pro Tech Toolkit", 69.99, 64));
        store.AddProduct(new Battery("Anker PowerCore 26800mAh", 79.99, 26800));
        store.AddProduct(new Multimeter("Fluke 117 Digital Multimeter", 199.99, 600));

        //Show all products
        store.ShowProducts();
    }
}

public abstract class Product
{
    public string Name { get; set; }
    private double _price;
    public double Price
    {
        get
        {
            return _price;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Price cannot be negative");
            }
            else
            {
                _price = value;
            }
        }
    }
    protected Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    protected abstract string GetProductDetails();

    public virtual string GetInfo()
    {
        return $"Product - {Name}, Price - ${Price}, Category - {this.GetType().Name}, " + GetProductDetails() + "\n";
    }
}

public class Store
{
    private List<Product> productsList = new List<Product>();
    public void AddProduct(Product product)
    {
        productsList.Add(product);
    }
    public void RemoveProduct(Product product)
    {
        productsList.Remove(product);
    }
    public void ShowProducts()
    {
        foreach (Product product in productsList)
        {
            Console.WriteLine(product.GetInfo());
        }
    }
}


//electronic devices
interface IElectronic
{

}
    interface IPersonalDevice : IElectronic
    {

    }
        class Tower : Product, IPersonalDevice
        {
            public string TowerType { get; set; }
            public Tower(string name, double price, string towerType) : base (name, price)
            {
                TowerType = towerType;
            }
            protected override string GetProductDetails()
            {
                return $"Tower type - {TowerType}.";
            }
        }
        class Laptop : Product, IPersonalDevice
        {
            private int _batteryLife;
            public int BatteryLife
            {
                get
                {
                    return _batteryLife;
                }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Battery life should be positive");
                    }
                    else
                    {
                        _batteryLife = value;
                    }
                }
            }
            public Laptop(string name, double price, int batteryLife) : base(name, price)
            {
                 BatteryLife = batteryLife;
            }
            protected override string GetProductDetails()
            {
                return $"Battery life - {BatteryLife} hours.";
            }
        }
        class Smartphone : Product, IPersonalDevice
        {
            private int _resolution;
            public int Resolution
            {
                get
                {
                    return _resolution;
                }
                set
                {
                    if (value < 0)
                    {
                throw new ArgumentException("Camera resolution cannot be a negative number");
                    }
                    else
                    {
                        _resolution = value;
                    }
                }
            }
            public Smartphone(string name, double price, int resolution) : base(name, price)
            {
                Resolution = resolution;
            }
            protected override string GetProductDetails()
            {
                return $"Camera resolution - {Resolution} MP.";
            }
        }

    interface IOfficeDevice : IElectronic
    {

    }
        class Printer : Product, IOfficeDevice
        {
            private int _ppm;
            public int PPM
            {
                get
                { 
                    return _ppm; 
                }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("PPM value cannot be negative");
                    }
                    else
                    {
                        _ppm = value;
                    }
                }
            }
            public Printer(string name, double price, int ppm) : base(name, price)
            {
                PPM = ppm;
            }
            protected override string GetProductDetails()
            {
                return $"Pages per minute - {PPM} ppm.";
            }
        }
        class Scanner : Product, IOfficeDevice
        {
            private int _dpi;
            public int DPI
            {
                get
                {
                    return _dpi;
                }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("DPI value cannot be negative");
                    }
                    else
                    {
                        _dpi = value;
                    }
                }
            }
            public Scanner(string name, double price, int dpi) : base(name, price)
            {
                DPI = dpi;
            }
            protected override string GetProductDetails()
            {
                return $"DPI - {DPI} dpi.";
            }
        }
        class Shredder : Product, IOfficeDevice
            {
            private int _sheetCapacity;
            public int SheetCapacity
            {
                get
                {
                    return _sheetCapacity;
                }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Sheet capacity value cannot be negative");
                    }
                    else
                    {
                        _sheetCapacity = value;
                    }
                }
            }
            public Shredder(string name, double price, int sheetCapacity) : base(name, price)
            {
                SheetCapacity = sheetCapacity;
            }
            protected override string GetProductDetails()
            {
                return $"Sheet capacity - {SheetCapacity}.";
            }
        }

    interface IHomeAppliance : IElectronic
    {

    }
        class Refrigerator : Product, IHomeAppliance
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
                        throw new ArgumentException("Capacity value cannot be 0");
                    }
                    else
                    {
                        _capacity = value;
                    }
                }
            }
            public Refrigerator(string name, double price, int  capacity) : base(name, price)
            {
                Capacity = capacity;
            }
            protected override string GetProductDetails()
            {
                return $"Capacity - {Capacity} L.";
            }
        }
        class Microwave : Product, IHomeAppliance
        {
            private int _power;
            public int Power
            {
                get
                {
                    return _power;
                }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Power value cannot be negative");
                    }
                    else
                    {
                        _power = value;
                    }
                }
            }
            public Microwave(string name, double price, int power) : base(name, price)
            {
                Power = power;
            }
            protected override string GetProductDetails()
            {
                return $"Power - {Power} W";
            }
        }
        class Oven : Product, IHomeAppliance
        {
            private int _maxTemp;
            public int MaxTemp
            {
                get
                {
                    return _maxTemp;
                }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Temperature value cannot be negative");
                    }
                    else
                    {
                        _maxTemp = value;
                    }
                }
            }
            public Oven(string name, double price, int maxTemp) : base(name, price)
            {
                MaxTemp = maxTemp;
            }
            protected override string GetProductDetails()
            {
                return $"Temperature range - {MaxTemp} C°.";
            }
        }

//maintenance
interface IMaintenance
{

}
    interface ICleaning : IMaintenance
    {

    }
        class Spray : Product, ICleaning
        {
            private int _mililiters;
            public int Mililiters
            {
                get
                {
                    return _mililiters;
                }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Mililiters value cannot be negative");
                    }
                    else
                    {
                        _mililiters = value;
                    }
                }
            }
            public Spray(string name, double price, int mililiters) : base(name, price)
            {
                Mililiters = mililiters;
            }
            protected override string GetProductDetails()
            {
                return $"Size - {Mililiters} ml.";
            }

        }
        class MicrofiberCloth : Product, ICleaning
        {
            private int _density;
            public int Density
            {
                get
                {
                    return _density;
                }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Density value cannot be negative");
                    }
                    else
                    {
                        _density = value;
                    }
                }
            }
            public MicrofiberCloth(string name, double price, int density) : base(name, price)
            {
                Density = density;
            }
            protected override string GetProductDetails()
            {
                return $" Density - {Density} gsm.";
            }
        }
    class Wipe : Product, ICleaning
    {
        public bool Wet { get; set; }
        public string PreMoistured { get; }
        public Wipe(string name, double price, bool wet) : base(name, price)
        {
            Wet = wet;
            PreMoistured = Wet switch
            {
                true => "yes",
                _ => "no"
            };
        }
        protected override string GetProductDetails()
        {
            return $" Pre-moistured - {PreMoistured}.";
        }
    }

    interface IProtection : IMaintenance
    {

    }
        class CoolingPad : Product, IProtection
        {
            private int _fanSpeed;
            public int FanSpeed
            {
                get
                {
                    return _fanSpeed;
                }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Fan speed value cannot be negative");
                    }
                    else
                    {
                        _fanSpeed = value;
                    }
                }
            }
            public CoolingPad(string name, double price, int fanSpeed) : base(name, price)
            {
                FanSpeed = fanSpeed;
            }
            protected override string GetProductDetails()
            {
                return $" Fan speed - {FanSpeed} rpm.";
            }
        }
        class CableOrganiser : Product, IProtection
        {
            private int _cablesCapacity;
            public int CablesCapacity
            {
                get
                {
                    return _cablesCapacity;
                }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Cables capacity value cannot be negative");
                    }
                    else
                    {
                        _cablesCapacity = value;
                    }
                }
            }
            public CableOrganiser(string name, double price, int cables) : base(name, price)
            {
                CablesCapacity = cables;
            }
            protected override string GetProductDetails()
            {
                return $"Cables capacity - {CablesCapacity}.";
            }
        }
        class ScreenProtector : Product, IProtection
        {
            public string HardnessRating;
            public ScreenProtector(string name, double price, string hardnessRating) : base(name, price)
            {
                HardnessRating = hardnessRating;
            }
            protected override string GetProductDetails()
            {
                return $"Hardness rating - {HardnessRating}.";
            }
        }

    interface IRepairment : IMaintenance
    {

    }
        class ToolKit : Product, IRepairment
        {
            private int _tools;
            public int Tools
            {
                get
                {
                    return _tools;
                }
                set
                {
                    if (value < 0)
                    {
                        throw new ArgumentException("Tools value cannot be negative");
                    }
                    else
                    {
                        _tools = value;
                    }
                }
            }
            public ToolKit(string name, double price, int  tools) : base(name, price)
            {
                Tools = tools;
            }
            protected override string GetProductDetails()
            {
                return $"Tools amount - {Tools}.";
            }
        }
        class Battery : Product, IRepairment
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
                        throw new ArgumentException("Battery capacity value cannot be negative");
                    }
                    else
                    {
                        _batteryCapacity = value;
                    }
                }
            }
            public Battery(string name, double price, int batteryCapacity) : base(name, price)
            {
                BatteryCapacity = batteryCapacity;
            }
            protected override string GetProductDetails()
            {
                return $" Battery capacity - {BatteryCapacity} mAh.";
            }
        }
        class Multimeter : Product, IRepairment
        {
        private int _voltage;
        public int Voltage
        {
            get
            {
                return _voltage;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Voltage value cannot be negative");
                }
                else
                {
                    _voltage = value;
                }
            }
        }
        public Multimeter(string name, double price, int voltage) : base(name, price)
        {
            Voltage = voltage;
        }
        protected override string GetProductDetails()
        {
            return $"Voltage range - {Voltage} V.";
        }
    }
