namespace Course.Exemplos
{
    internal class Enumeracoes_Heranca_Poliformismo
    {
    }
}

//// CLASS PROGRAM----------------------------

//Order order = new Order
//{
//    Id = 1080,
//    Moment = DateTime.Now,
//    Status = OrderStatus.PendingPayment
//};

//Console.WriteLine(order);

//string txt = OrderStatus.PendingPayment.ToString();  // conversão de enumerado para string

//OrderStatus os = Enum.Parse<OrderStatus>("Delivered");  // conversão de string para enumerado

//Console.WriteLine(os);
//Console.WriteLine(txt);


//// CLASS ORDER-----------------------------

//public int Id { get; set; }
//public DateTime Moment { get; set; }
//public OrderStatus Status { get; set; }

//public override string ToString()
//{
//    return Id
//        + ","
//        + Moment
//        + ","
//        + Status;
//}


//// CLASS (ENUMS) ORDERSTATUS------------------

//namespace Course.Entities.Enums
//{
//    enum OrderStatus : int
//    {
//        PendingPayment = 0,
//        Processing = 1,
//        Shipped = 2,
//        Delivered = 3
//    }
//}


//----------------------------------------------------------

////CLASS PROGRAM--------------------------

//BusinessAccount account = new BusinessAccount(8010, "Ana SB", 100.0, 500.0);
//Console.WriteLine(account.Balance);

//// account.Balance = 200.0; # p/ exemplo de que o protected não deixa modificar
//// quando está além da classe de origem e de sua subclasse

////CLASS ACCOUNT---------------------------------------
//public int Number { get; private set; }           // amount = quantia
//public string Holder { get; private set; }        // holder = titular
//public double Balance { get; protected set; }       // balance = saldo // #program

//public Account()
//{}

//public Account(int number, string holder, double balance)
//{
//    Number = number;
//    Holder = holder;
//    Balance = balance;
//}

//public void WithDraw(double amount)       // withdraw = saque recebe uma quantia como parâmetro
//{
//    Balance -= amount;                    // esse saque retira do saldo essa quantia
//}

//public void Deposit(double amount)        // deposito recebe uma quantia como parâmetro
//{
//    Balance += amount;                    // esse deposito acrescenta no saldo essa quantia
//}

//// SUBCLASS DE ACCOUNT, BUSINESSACCOUNT-----------------------------
//class BusinessAccount : Account
//{
//    public double LoanLimit { get; set; }     // loan = empréstimo

//    public BusinessAccount()
//    {}

//    public BusinessAccount(int number, string holder, double balance, double loanLimit) : base(number, holder, balance)
//    {
//        LoanLimit = loanLimit;
//    }

//    public void Loan(double amount) // LOAN MEANS EMPRESTIMO
//    {
//        if (amount <= LoanLimit)
//        { Balance += amount; }
//    }

//----------------------------------------------------------------------------------------


// Program - UPCASTING E DOWNCASTING

//Account acc = new Account(1001, "Ana", 0.0);
//BusinessAccount bacc = new BusinessAccount(1002, "cecilia", 0.0, 500.0);

//// UPCASTING----------------------

//Account acc1 = bacc;
//Account acc2 = new BusinessAccount(1003, "alex", 0.0, 200.0);
//Account acc3 = new SavingsAccount(1004, "bob", 0.0, 0.01);

//// DOWNCASTING--------------------

//BusinessAccount acc4 = (BusinessAccount)acc2;

//acc4.Loan(100.0);

//// BusinessAccount acc5 = (BusinessAccount)acc3;

//if (acc3 is BusinessAccount)
//{
//    //BusinessAccount acc5 = (BusinessAccount)acc3;  // 1ª forma de fazer casting
//    BusinessAccount acc5 = acc3 as BusinessAccount;
//    acc5.Loan(200.0);
//    Console.WriteLine("Loan!");
//}

//if (acc3 is SavingsAccount)
//{
//    //SavingsAccount acc5 = (SavingsAccount)acc3;
//    SavingsAccount acc5 = acc3 as SavingsAccount;
//    acc5.UpdateBalance();
//    Console.WriteLine("Update!");
//}

//-----------------------------------------------------------------------------------------

//// CLASS PROGRAM-------------------------------

//List<Employee> list = new List<Employee>();

//Console.Write("Enter the number of employees: ");
//int n = int.Parse(Console.ReadLine());

//for (int i = 1; i <= n; i++)
//{
//    Console.WriteLine($"Employee #{i} data: ");  // interpolação
//    Console.Write("Outsourced (y/n)? ");
//    char ch = char.Parse(Console.ReadLine());
//    Console.Write("Name: ");
//    string name = Console.ReadLine();
//    Console.Write("Hours: ");
//    int hours = int.Parse(Console.ReadLine());
//    Console.Write("Value per hour: ");
//    double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

//    if (ch == 'y')
//    {
//        Console.Write("Additional Charge: ");
//        double additionalCharge = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

//        list.Add(new OutsourcedEmployee(name, hours, valuePerHour, additionalCharge));  // ao adicionar na lista, já instancia o objeto
//    }
//    else
//    {
//        list.Add(new Employee(name, hours, valuePerHour));
//    }
//}
//Console.WriteLine("PAYMENTS:");

//foreach (Employee emp in list)
//{
//    Console.WriteLine(emp.Name + " - $ " + emp.Payment().ToString("F2", CultureInfo.InvariantCulture));
//}

//// CLASS EMPLOYEE--------------------------------

//public string Name { get; set; }
//public int Hours { get; set; }
//public double ValuePerHour { get; set; }

//public Employee() { }

//public Employee(string name, int hours, double valuePerHour)
//{
//    Name = name;
//    Hours = hours;
//    ValuePerHour = valuePerHour;
//}

//public virtual double Payment()
//{
//    return Hours * ValuePerHour;
//}

//// CLASS OUTSOURCEDEMPLOYEE---------------------------

//class OutsourcedEmployee : Employee
//{
//    public double AdditionalCharge { get; set; }

//    public OutsourcedEmployee()
//    {
//    }

//    public OutsourcedEmployee(string name, int hours, double valuePerHour, double additionalCharge)
//        : base(name, hours, valuePerHour)
//    {
//        AdditionalCharge = additionalCharge;
//    }

//    public override double Payment()
//    {
//        return base.Payment() + 1.1 * AdditionalCharge;
//    }
//}

//------------------------------------------------------------------------------------------

//// CLASS PROGRAM------------------------------------

//List<Product> list = new List<Product>();

//Console.Write("Enter the number of products: ");
//int n = int.Parse(Console.ReadLine());

//for (int i = 1; i <= n; i++)
//{
//    Console.WriteLine($"Product #{i} data:");
//    Console.Write("Commom, used or imported (c/u/i)? ");
//    char p = char.Parse(Console.ReadLine());
//    Console.Write("Name: ");
//    string name = Console.ReadLine();
//    Console.Write("Price: ");
//    double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

//    if (p == 'c')  // no lugar de 'p', prof nelio pôs 'type'
//    {
//        list.Add(new Product(name, price));
//    }
//    else if (p == 'u')
//    {
//        Console.Write("Manufacture date (DD/MM/YYYY): ");
//        DateTime manufacture = DateTime.Parse(Console.ReadLine());
//        list.Add(new UsedProduct(name, price, manufacture));
//    }
//    else if (p == 'i')
//    {
//        Console.Write("Customs fee: ");
//        double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
//        list.Add(new ImportedProduct(name, price, customsFee));
//    }
//}

//Console.WriteLine();
//Console.WriteLine("PRICE TAGS:");

//foreach (Product product in list)
//{
//    Console.WriteLine(product.PriceTag());
//}


//// CLASS PRODUCT---------------------------------------

//public string Name { get; set; }
//public double Price { get; set; }

//public Product()
//{
//}

//public Product(string name, double price)
//{
//    Name = name;
//    Price = price;
//}

//public virtual string PriceTag()
//{
//    return Name + " $ " + Price.ToString("F2", CultureInfo.InvariantCulture);
//}


//// CLASS IMPORTEDPRODUCT-------------------------------------

//public double CustomsFee { get; set; }

//public ImportedProduct() { }

//public ImportedProduct(string name, double price, double customsFee)
//            : base(name, price)
//        {
//    CustomsFee = customsFee;
//}

//public double TotalPrice()
//{
//    return Price += CustomsFee;
//}

//public override string PriceTag()
//{
//    return Name
//        + " $ "
//        + TotalPrice().ToString("F2", CultureInfo.InvariantCulture)
//        + " (Customs fee: $ "
//        + CustomsFee.ToString("F2", CultureInfo.InvariantCulture)
//        + ")";
//}


//// CLASS USEDPRODUCT--------------------------------------

//public DateTime ManufactureDate { get; set; }

//public UsedProduct()
//{
//}

//public UsedProduct(string name, double price, DateTime manufactureDate)
//            : base(name, price)
//        {
//    ManufactureDate = manufactureDate;
//}

//public override string PriceTag()
//{
//    return Name
//        + " (used) $ "
//        + Price.ToString("F2", CultureInfo.InvariantCulture)
//        + " (Manufacture date: "
//        + ManufactureDate.ToString("dd/MM/yyyy")
//        + ")";
//}

//--------------------------------------------------------------------------

//// CLASS PROGRAM-----------------------------

//List<Shape> list = new List<Shape>();

//Console.Write("Enter the number of shapes: ");
//int n = int.Parse(Console.ReadLine());

//for (int i = 1; i <= n; i++)
//{
//    Console.WriteLine($"Shape #{i} data: ");
//    Console.Write("Rectangle or circle (r/c): ");
//    char ch = char.Parse(Console.ReadLine());
//    Console.Write("Color (Black/Blue/Red): ");
//    Color color = Enum.Parse<Color>(Console.ReadLine()); // Enum / .Parse / < tipo específico do enum > / (Console.ReadLine());
//    if (ch == 'r')
//    {
//        Console.Write("Width: ");
//        double width = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
//        Console.Write("Height: ");
//        double height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

//        list.Add(new Rectangle(width, height, color));
//    }
//    else if (ch == 'c')
//    {
//        Console.Write("Radius: ");
//        double radius = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

//        list.Add(new Circle(color, radius));
//    }
//}
//Console.WriteLine();
//Console.WriteLine("SHAPE AREAS:");
//foreach (Shape shape in list)
//{
//    Console.WriteLine(shape.Area().ToString("F2", CultureInfo.InvariantCulture));
//}


//// CLASS SHAPE---------------------------------

//public Color Color { get; set; }

//public Shape(Color color)
//{
//    Color = color;
//}

//public abstract double Area();  // não é implementada porque a classe shape é genérica demais


//// CLASS RECTANGLE--------------------------------

//public double Width { get; set; }
//public double Height { get; set; }

//public Rectangle(double width, double height, Color color) :base(color)
//        {
//    Width = width;
//    Height = height;
//}

//public override double Area()
//{
//    return Width * Height;
//}


//// CLASS CIRCLE-----------------------------------

//public double Radius { get; set; }

//public Circle(Color color, double radius) : base(color)
//{
//    Radius = radius;
//}

//public override double Area()
//{
//    return Math.PI * Radius * Radius;
//}

////  ++ ENUM COLOR-----------

//enum Color
//{
//    Black,
//    Blue,
//    Red
//}


//------------------------------------------------------------------------
