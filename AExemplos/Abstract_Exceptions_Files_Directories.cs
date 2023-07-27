//using Course.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Exemplos
{
    internal class Abstract_Exceptions_Files_Directories
    {
    }
}

//// CLASS PROGRAM------------------------------ HERANÇA-POLIMORFISMO-METODOS.ABSTRATOS-MUITOMAIS

//List<TaxPayer> list = new List<TaxPayer>();

//Console.Write("Enter the number of tax payers: ");
//int n = int.Parse(Console.ReadLine());

//for (int i = 1; i <= n; i++)
//{
//    Console.WriteLine($"Tax payer #{i} data:");
//    Console.Write("Individual or company (i/c)? ");
//    char type = char.Parse(Console.ReadLine());
//    Console.Write("Name: ");
//    string name = Console.ReadLine();
//    Console.Write("Anual income: ");
//    double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

//    if (type == 'i')
//    {
//        Console.Write("Health Expenditures: ");
//        double expenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

//        list.Add(new Individual(name, anualIncome, expenditures));
//    }
//    else if (type == 'c')
//    {
//        Console.Write("Number of employees: ");
//        int employees = int.Parse(Console.ReadLine());

//        list.Add(new Company(name, anualIncome, employees));
//    }
//    else
//    {
//        Console.WriteLine("This type doesn't exist! Try again.");
//    }
//}
//Console.WriteLine();
//Console.WriteLine("TAXES PAID:");

//double sum = 0.0;
//foreach (TaxPayer taxPayer in list)
//{
//    Console.WriteLine(taxPayer.Name + ": $ " + taxPayer.Tax().ToString("F2", CultureInfo.InvariantCulture));

//    sum += taxPayer.Tax();
//}
//Console.WriteLine();
//Console.WriteLine("TOTAL TAXES: $ " + sum.ToString("f2", CultureInfo.InvariantCulture));


//// CLASS TAXPAYER = CONTRIBUÍNTE--------------------------------------------

//abstract class TaxPayer  // Contribuínte
//{
//    public string Name { get; set; }
//    public double AnualIncome { get; set; }  // anual income = renda anual

//    protected TaxPayer(string name, double anualIncome)
//    {
//        Name = name;
//        AnualIncome = anualIncome;
//    }

//    public abstract double Tax();

//    public override string ToString()
//    {
//        return Name + ": $ ";
//    }
//}


//// CLASS INDIVIDUAL = PESSOA FÍSICA-----------------------------------------

//public double HealthExpenditures { get; set; }

//public Individual(string name, double anualIncome, double healthExpenditures)
//            : base(name, anualIncome)
//        {
//    HealthExpenditures = healthExpenditures;
//}

//public override double Tax()
//{
//    if (AnualIncome < 20000.0)
//    {
//        return AnualIncome * 15 / 100.0 - HealthExpenditures * 50 / 100.0;
//    }
//    else
//    {
//        return AnualIncome * 25 / 100.0 - HealthExpenditures * 50 / 100.0;
//    }
//}


//// CLASS COMPANY = PESSOA JURÍDICA---------------------------------------

//public int NumberEmployees { get; set; }

//public Company(string name, double anualIncome, int numberEmployees)
//            : base(name, anualIncome)
//        {
//    NumberEmployees = numberEmployees;
//}

//public override double Tax()
//{
//    if (NumberEmployees <= 10)
//    {
//        return AnualIncome * 16 / 100.0;
//    }
//    else
//    {
//        return AnualIncome * 14 / 100.0;
//    }
//}

//-------------------------------------------------------------------------------

//// ------------------TRATAMENTO DE EXCEÇÕES-----------------------

// CLASS PROGRAM------------

//try
//{
//    Console.Write("Room number: ");
//    int number = int.Parse(Console.ReadLine());
//    Console.Write("Check-in date (dd/MM/yyyy): ");
//    DateTime checkIn = DateTime.Parse(Console.ReadLine());
//    Console.Write("Check-out date (dd/MM/yyyy): ");
//    DateTime checkOut = DateTime.Parse(Console.ReadLine());

//    Reservation reservation = new Reservation(number, checkIn, checkOut);
//    Console.WriteLine("Reservation: " + reservation);

//    Console.WriteLine();
//    Console.WriteLine("Enter data to update the reservation:");

//    Console.Write("Check-in date (dd/MM/yyyy): ");
//    checkIn = DateTime.Parse(Console.ReadLine());
//    Console.Write("Check-out date (dd/MM/yyyy): ");
//    checkOut = DateTime.Parse(Console.ReadLine());

//    reservation.UpdateDates(checkIn, checkOut);
//    Console.WriteLine("Reservation: " + reservation);
//}

//catch (DomainException e)                                    // clausula catch, ela captura a exceção
//{
//    Console.WriteLine("Error in reservation: " + e.Message);
//}
//catch (FormatException e)
//{
//    Console.WriteLine("Format error: " + e.Message);
//}
//catch (Exception e)
//{
//    Console.WriteLine("Unespected error: " + e.Message);
//}


//// CLASS RESERVATION-----------------------------------

//public int RoomNumber { get; set; }
//public DateTime CheckIn { get; set; }
//public DateTime CheckOut { get; set; }

//public Reservation() { }

//public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut)
//{
//    if (checkOut <= checkIn)
//    {
//        throw new DomainException("Check-out date must be after Check-in date");
//    }
//    RoomNumber = roomNumber;
//    CheckIn = checkIn;
//    CheckOut = checkOut;
//}

//public int Duration()
//{
//    TimeSpan duration = CheckOut.Subtract(CheckIn);      // <-- forma simplificada, mas tbm dá assim: CheckOut.Subtract(CheckIn)
//    return (int)duration.TotalDays;
//}

//public void UpdateDates(DateTime checkIn, DateTime checkOut)
//{
//    DateTime now = DateTime.Now;
//    if (checkIn < now || checkOut < now)
//    {
//        throw new DomainException("Reservation dates for update must be future dates");
//    }
//    if (checkOut <= checkIn)
//    {
//        throw new DomainException("Check-out date must be after Check-in date");
//    }
//    CheckIn = checkIn;
//    CheckOut = checkOut;
//}

//public override string ToString()
//{
//    return "Room "
//        + RoomNumber
//        + ", check-in: "
//        + CheckIn.ToString("dd/MM/yyyy")
//        + ", check-out: "
//        + CheckOut.ToString("dd/MM/yyyy")
//        + ", "
//        + Duration()
//        + " nights";
//}

//// CLASS DOMAIN EXCEPTION----------------------- Exer.Entities.Exceptions

//class DomainException : ApplicationException
//{
//    public DomainException(string message) : base(message)
//    {
//    }
//}

//-----------------------------------------------------------------------------end


//// CLASS PROGRAM - EXERCICIO DE EXCEÇÃO------------------------------------

//try
//{
//    Console.WriteLine("Enter account data");

//    Console.Write("Number: ");
//    int number = int.Parse(Console.ReadLine());
//    Console.Write("Holder: ");
//    string holder = Console.ReadLine();
//    Console.Write("Initial balance: ");
//    double balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
//    Console.Write("Withdraw limit: ");
//    double wdLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

//    Account account = new Account(number, holder, balance, wdLimit);
//    Console.WriteLine();

//    Console.Write("Enter amount for withdraw: ");
//    double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

//    account.Withdraw(amount);

//    Console.WriteLine("New balance: " + account.Balance);
//}
//catch (DomainExceptions e)
//{
//    Console.WriteLine("Withdraw error: " + e.Message);
//}


//// CLASS ACCOUNT----------------------------------

//public int Number { get; set; }
//public string Holder { get; set; }
//public double Balance { get; set; }
//public double WithdrawLimit { get; set; }

//public Account() { }

//public Account(int number, string holder, double balance, double withdrawLimit)
//{
//    Number = number;
//    Holder = holder;
//    Balance = balance;
//    WithdrawLimit = withdrawLimit;
//}

//public void Deposit(double amount)
//{
//    Balance += amount;
//}

//public void Withdraw(double amount)
//{
//    if (Balance <= 0 || amount > Balance && amount <= WithdrawLimit)
//    {
//        throw new DomainExceptions("Not enough balance");
//    }
//    if (amount > WithdrawLimit)
//    {
//        throw new DomainExceptions("The amount exceeds withdraw limit");
//    }
//    Balance -= amount;
//}

//// CLASS DOMAINEXCEPTION
//class DomainExceptions : ApplicationException
//{
//    public DomainExceptions(string message) : base(message)
//    {
//    }

//----------------------------------------------------------------------------------

//try
//{
//    int n1 = int.Parse(Console.ReadLine());
//    int n2 = int.Parse(Console.ReadLine());

//    int result = n1 / n2;
//    Console.WriteLine(result);
//}
//catch (DivideByZeroException e)
//{
//    Console.WriteLine("Division by zero is not allowed");
//}
//catch (FormatException e)
//{ 
//    Console.WriteLine("Format error!" + e.Message); 
//}


//// BLOCO FINALLY

//FileStream fs = null;
//try
//{
//    fs = new FileStream(@"C:\Temp\data.txt", FileMode.Open);
//    StreamReader sr = new StreamReader(fs);
//    string line = sr.ReadLine();
//    Console.WriteLine(line);
//}
//catch (FileNotFoundException e)
//{
//    Console.WriteLine(e.Message);
//}
//finally
//{
//    if (fs != null)
//    {
//        fs.Close();
//    }
//}

//-----------------------------------------------------------------------

//// FILE, FILEINFO E IOEXCEPTION

//string sourcePath = @"C:\Temp\file1.txt";
//string targetPath = @"C:\Temp\file2.txt";             // aqui criou o file2 auto (CRIOU NAO X)

//try
//{
//    FileInfo fileInfo = new(sourcePath);             // criado um obj do tipo FileInfo, recebendo um path de um file. FileInfo precisa de uma instancia
//    fileInfo.CopyTo(targetPath);

//    string[] lines = File.ReadAllLines(sourcePath);  // aqui a classe File foi chamada diretamente pois não precisa de instancia, classe e metodos estaticos
//    foreach (string line in lines)
//    {
//        Console.WriteLine(line);
//    }
//}
//catch (IOException e)
//{
//    Console.WriteLine("An error accurred");
//    Console.WriteLine(e.Message);
//}

//-----------------------------------

//// forma não reduzida

//string path = @"C:\Temp\file1.txt";

//FileStream fileStream = null;
//StreamReader streamReader = null;

//try
//{
//    fileStream = new FileStream(path, FileMode.Open);    // instanciei um obj FileStream(stream binaria) associado a um arquivo com a finalidade de abrir o arquivo para acesso(filemode.open).
//    streamReader = new StreamReader(fileStream);         // instanciei um obj StreamReader(stream caracter), agora, a partir desse obj eu posso fazer por ex. uma leitura no arquivo.
//    string line = streamReader.ReadLine();
//    Console.WriteLine(line);
//}
//catch (IOException e)
//{
//    Console.WriteLine("An error occurred");
//    Console.WriteLine(e.Message);
//}
//finally
//{
//    if (streamReader != null) streamReader.Close();       //  "se estiver aberto, fecha"
//    if (fileStream != null) fileStream.Close();
//}


//-----------------------------------


//// forma reduzida

//string path = @"C:\Temp\file1.txt";

//StreamReader streamReader = null;

//try
//{
//    streamReader = File.OpenText(path);         // OpenText IMPLICITAMENTE instancia o FileStream e instancia o StreamReader em cima dele
//    while (!streamReader.EndOfStream)           // permite ler todas as linhas do arquivo
//    {
//        string line = streamReader.ReadLine();
//        Console.WriteLine(line);
//    }
//}
//catch (IOException e)
//{
//    Console.WriteLine("An error occurred");
//    Console.WriteLine(e.Message);
//}
//finally
//{
//    if (streamReader != null) streamReader.Close();
//}


//--------------------------------------------------------------------------

//// bloco USING - maneira nao tao simplificada

//string path = @"C:\Temp\file5.txt";


//try
//{
//    using (FileStream fs = new(path, FileMode.Open))   // tudo o que colocra nesse bloco vai ser executado, e ao final desse bloco esse recurso instanciado será automaticamente fechado
//    {
//        using (StreamReader sr = new(fs))              // aqui serve pra ler em caracteres o que o  FileStream pegou em binário 
//        {
//            while (!sr.EndOfStream)
//            {
//                string line = sr.ReadLine();
//                Console.WriteLine(line);
//            }
//        }
//    }
//}
//catch (IOException e)
//{
//    Console.WriteLine("An error accurred");
//    Console.WriteLine(e.Message);
//}

//-------------------------------------------------

//// bloco USING mais simplificado

//string path = @"C:\Temp\file1.txt";

//try
//{
//    using (StreamReader sr = File.OpenText(path))    //simp / naturalmente o file.opentext instancia um filestream e um streamreader(mágica)
//    {
//        while (!sr.EndOfStream)                      // ENQUANTO NÃO chega o final da stream sr StreamReader, executa isso:
//        {
//            string line = sr.ReadLine();             // declara a variável line aleatória, e ela recebe o que o programa ler em cada linha da stream sr
//            Console.WriteLine(line);                 // depois cwl 
//        }
//    }
//}
//catch (IOException e)
//{
//    Console.WriteLine("An error accurred");
//    Console.WriteLine(e.Message);
//}

//---------------------------------------------------------------

//// STREAMWRITER

//string sourcePath = @"C:\Temp\file1.txt";
//string targetPath = @"C:\Temp\file2.txt";

//try
//{
//    string[] lines = File.ReadAllLines(sourcePath);         // leu todo o conteudo do arquivo e guardou no vetor de strings

//    using (StreamWriter sw = File.AppendText(targetPath))   // AppendText - vai abrir o arquivo para escrita e tudo oq mandar escrever, vai escrever a partir do final do arquivo append = concatenação
//    {
//        foreach (string line in lines)
//        {
//            sw.WriteLine(line.ToUpper());
//        }
//    }

//}
//catch (IOException e)
//{
//    Console.WriteLine("An error accurred");
//    Console.WriteLine(e.Message);
//}

//------------------------------------------------------------

//// DIRECTORY--------------------------------
/// Listar as pastas (subpastas) a partir de uma pasta informada
/// Listar os arquivos(até das sub) a partir de uma pasta informada

//string path = @"C:\Temp\myfolder";

//try    
//{
//    // é assim que funciona a operação de pegar todas as subpastas a partir de uma pasta original
//    IEnumerable<string> folders = Directory.EnumerateDirectories(path, "*.*", SearchOption.AllDirectories);  //"*.*" = "doc.txt"
////  ou: var folders = ... (o c# faz a inferência de tipo).
//    Console.WriteLine("FOLDERS:");
//    foreach (string s in folders)
//    {
//        Console.WriteLine(s);
//    }

//-----------------

////    é assim que funciona a operação de pegar todos os arquivos a partir de uma pasta original
//      var files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);  //"*.*" = "doc.txt"
//      Console.WriteLine("FILES:");
//      foreach (string s in files)
//      {
//          Console.WriteLine(s);
//      }

//----------------

////    é assim que se cria uma pasta
//      Directory.CreateDirectory(path + "\\newfolder1");

//}
//catch (IOException e)
//{
//    Console.WriteLine("An error accurred");
//    Console.WriteLine(e.Message);
//}

//

//-------------------------------------------------------------------------------------

//// CLASSE PATH - AÇÕES-------------------------------

//string path = @"C:\Temp\myfolder\file1.txt";

//Console.WriteLine("DirectorySeparatorChar: " + Path.DirectorySeparatorChar);
//Console.WriteLine("PathSeparator: " + Path.PathSeparator);
//Console.WriteLine("GetDirectoryName: " + Path.GetDirectoryName(path));
//Console.WriteLine("GetFileName: " + Path.GetFileName(path));
//Console.WriteLine("GetExtension: " + Path.GetExtension(path));
//Console.WriteLine("GetFileNameWithoutExtension: " + Path.GetFileNameWithoutExtension(path));
//Console.WriteLine("GetFullPath: " + Path.GetFullPath(path));
//Console.WriteLine("GetTempPath: " + Path.GetTempPath());


//------------------------------------------------------------------------------------


//// ERA UMA VEZ UM EXERCICIO

//string sourcePath = @"C:\Temp\myfolder\products.csv";  // caminho do arquivo que criei

//string[] prod = File.ReadAllLines(sourcePath);         // vetor que vai armazenar cada linha do arquivo, ou seja, cada item

//foreach (string proditem in prod)                      // foreach para percorrer cada linha do vetor para...
//{
//    string[] vet = proditem.Split(',');                // PODER pegar cada informação do produto e separar por ','
//    string nome = vet[0];
//    double valor = double.Parse(vet[1]);
//    int quant = int.Parse(vet[2]);

//    Produto p = new(nome, valor, quant);              // produto instanciado com as informações
//}


//string targetPath = @"C:\Temp\myfolder\out\summary.csv";


//----------------------------------------------------------------------------------

//// VERSION BY PROF NELIO

//Console.Write("Enter file full path: ");
//string sourceFilePath = Console.ReadLine();

//try
//{
//    string[] lines = File.ReadAllLines(sourceFilePath);

//    string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);    // caminho da pasta de origem - aqui ele pega o diretorio (path até a pasta) do path que o usuario digita
//    string targetFolderPath = sourceFolderPath + @"\out";               // caminho da pasta de destino
//    string targetFilePath = targetFolderPath + @"\summary.csv";         // caminho do arquivo de destino

//    Directory.CreateDirectory(targetFolderPath);                        // criou o diretorio = pasta

//    using (StreamWriter sw = File.AppendText(targetFilePath))           // instanciou um sw pra escrever no targetFilePath "summary.csv"
//    {
//        foreach (string line in lines)
//        {
//            string[] fields = line.Split(',');                    // aqui pega cada linha do vetor e separa por ',' armazenando no vetor de string fields
//            string name = fields[0];
//            double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
//            int quantity = int.Parse(fields[2]);

//            Product prod = new Product(name, price, quantity);

//            sw.WriteLine(prod.Name + "," + prod.Total().ToString("f2", CultureInfo.InvariantCulture));
//        }
//    }
//    Console.WriteLine(sourceFolderPath);
//    Console.WriteLine(targetFolderPath);
//    Console.WriteLine(targetFilePath);
//}
//catch (IOException e)
//{
//    Console.WriteLine("An error occurred");
//    Console.WriteLine(e.Message);
//}