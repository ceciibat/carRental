
namespace Course_Assembly.AExemplos
{
    internal class Interface_Generics_Equals_GetHashCode
    {
    }
}

// Program GENERICS-------------------------------------------------------

//PrintService<int> printService = new PrintService<int>();

//Console.Write("How many values? ");
//int n = int.Parse(Console.ReadLine());

//for (int i = 0; i < n; i++)
//{
//    int x = int.Parse(Console.ReadLine());
//    printService.AddValue(x);                        // armazenei o valor x dentro do vetor do PrintService
//}

//printService.Print();                                // printa todos os valores

//Console.WriteLine("First: " + printService.First());       // printa o primeiro valor


// CLASS SERVICE---------------------------------------------------------------------

//namespace Fix
//{
//    class PrintService<T>               // agora toda a classe é de um tipo GENÉRICO ESPECÍFICO
//    {

//        // implementação do service PrintService

//        private T[] _values = new T[10];
//        private int _count = 0;

//        public void AddValue(T value)
//        {
//            if (_count == 10)  // invalido pois o vetor já esta cheio
//            {
//                throw new InvalidOperationException("PrintService is full");
//            }
//            _values[_count] = value;
//            _count++;
//        }

//        public T First()   // retornar o 1° numero inserido
//        {
//            if (_count == 0)  // invalido pois o vetor esta vazio
//            {
//                throw new InvalidOperationException("PrintService is empty");
//            }
//            return _values[0];
//        }

//        public void Print()
//        {
//            Console.Write("[");
//            for (int i = 0; i < _count - 1; i++)   // imprimindo só até a penultima posição do vetor
//            {
//                Console.Write(_values[i] + ", ");
//            }
//            if (_count > 0)
//            {
//                Console.Write(_values[_count - 1]);
//            }
//            Console.WriteLine("]");
//        }

//    }
//}


//--------------------------------------------------------------

//// Program MAIN  - EQUALS E GETHASHCODE

//Client a = new Client { Name = "maria", Email = "maria@gmail.com" };
//Client b = new Client { Name = "alex", Email = "maria@gmail.com" };

//Console.WriteLine(a.Equals(b));                 // aqui o equals vai comparar o conteúdo "Email" (que estão iguais como maria)
//Console.WriteLine(a == b);                      // aqui serão comparadas as referências dos objetos (que são diferentes)
//Console.WriteLine(a.GetHashCode());
//Console.WriteLine(b.GetHashCode());

//// uma coisa é comparar referencia de memória,
//// outra coisa é comparar conteúdo.
///

//// CLASS CLIENT

//public string Name { get; set; }
//public string Email { get; set; }

//public override bool Equals(object? obj)
//{
//    if (!(obj is Client))                   // programação defensiva!
//    {
//        return false;
//    }
//    Client other = obj as Client;          // downcasting = casting da superclasse (Object) para subclasse (Client). isto  é necessário pois senão você não teria acesso à propriedade Email, pois o tipo Object não possui a propriedade Email. 

//    return Email.Equals(other.Email);
//}

//public override int GetHashCode()
//{
//    return Email.GetHashCode();
//}

//// CONJUNTOS - COLEÇÕES GENÉRICAS-----------09/08/2023

//// HashSet<T>----------------
//HashSet<string> set = new HashSet<string>();

//set.Add("TV");
//set.Add("Notebook");
//set.Add("Tablet");
//Console.WriteLine(set.Contains("comp"));

//foreach (string p in set)
//{
//    Console.WriteLine(p);
//}

//// SortedSet<T>---------------
//// main
//static void Main(string[] args)
//{
//    SortedSet<int> a = new SortedSet<int>() { 0, 2, 4, 5, 6, 8, 10 };
//    SortedSet<int> b = new SortedSet<int>() { 5, 6, 7, 8, 9, 10 };

//    // union  - ele vai unir os 2 conjuntos, mas como diz em sua regra, não deve haver repetição, 
//    // pOrtanto, ele irá adicionar apenas aqueles que ainda não estão. ele tbm vai >ordenar< 

//    SortedSet<int> c = new SortedSet<int>(a);
//    c.UnionWith(b);
//    PrintCollection(c);

//    // intersection  - mostra os elementos em comum nos 2 conjuntos

//    SortedSet<int> d = new SortedSet<int>(a);
//    d.IntersectWith(b);
//    PrintCollection(d);

//    // difference  - mostra apenas os elementos que existem exclusivamente no conjunto 'a', com exceção dos que se intersectam com 'b'

//    SortedSet<int> e = new SortedSet<int>(a);
//    e.ExceptWith(b);
//    PrintCollection(e);
//}

//// MÉTODO p/ imprimir a coleção----------------

//static void PrintCollection<T>(IEnumerable<T> collection)   // IEnumerable é uma interface implementada por todas as coleções basic do sys.collec.gener 
//{
//    foreach (T obj in collection)
//    {
//        Console.Write(obj + " ");
//    }
//    Console.WriteLine();
//}

//-----------------------------------------------------------------

////Como as coleções Hash testam igualdade?????????????????????????

            //// SE GetHashCode e Equalsestiverem implementados:

            //HashSet<string> set = new HashSet<string>();          

            //set.Add("maria");
            //set.Add("alex");

            //// a função Contains vai primeiro testar o GetHashCode do "maria" de baixo, aí se dentro do conj. set tiver um elemento indexado por esse hashCode,
            //// ele vai e usa o Equals para confirmar que realmente o elemento está lá. e dessa eu tenho a answer se esse elemento pertence ao HashSet.
            //// resultado dará = True
            //// MAS isso PORQUE a classe STRING que é o TIPO do HashSet<string> set, possui a >implementação< do GetHashCode e Equals.

            //Console.WriteLine(set.Contains("maria"));

//------------como comparam igualdade??
// Program main
//HashSet<Product> a = new HashSet<Product>();

//a.Add(new Product("TV", 900.0));
//a.Add(new Product("Notebook", 1200.0));
//// criamos um conjunto a com 2 produtos dentro dele

//HashSet<Point> b = new HashSet<Point>();

//b.Add(new Point(3, 4));
//b.Add(new Point(5, 10));

//Product prod = new Product("Notebook", 1200.0);
//Console.WriteLine(a.Contains(prod));               // aí o coontainnnsss vai usar o gethashcode e equals
//// ^^
//// || sem implementação do gethashcode e equals, ele compara pela referencia. (o que dava falso)
//// com implementação ele vai comparar primeiro pelo hashCode e, se for igual, ele testa no Equals se o nome e o preço são iguais
//// agora, para o HashSet, este prod está contido no conjunto 'a'


//Point p = new Point(5, 10);
//Console.WriteLine(b.Contains(p));
//// quando o tipo é struct ele vai comparar por conteúdo, não por referência

//CLASS PRODUCT---------------

    //class Product          // tipo referencia
    //{
    //    public string Name { get; set; }
    //    public double Price { get; set; }
    //    public Product(string name, double price)
    //    {
    //        Name = name;
    //        Price = price;
    //    }

    //    public override int GetHashCode()                       
    //    {
    //        // vamos considerar que pra um produto ser igual a outro pelo hashcode, tem que bater o hashcode do nome e o hashcode do preço

    //        return Name.GetHashCode() + Price.GetHashCode();        // soma dos 2 hashcode p/ o equals confirmar (muito coincidentemente essa soma pode dar igual)          
    //    }

    //    public override bool Equals(object? obj)             
    //    {
    //        // quando que um Product será igual a outro Product?

    //        if (!(obj is Product))                                // programação defensiva p/ testar se esse obj é um Product
    //        {
    //            return false; 
    //            //poderia ser tbm uma exceção
    //        }

    //        // r = quando eles forem iguais tanto no Name quanto no Price

    //        Product other = obj as Product;
    //        //ou: Product other = (Product)obj; = cast explicito

    //        return Name.Equals(other.Name) && Price.Equals(other.Price);

    //     // = o Name do Product que eu estou .Equals(o Name do outro) EE o Price do Product que eu tô .Equals(o Price do outro)
    //    }
    //}

//STRUCT POINT------------------

    //struct Point   // tipo valor
    //{
    //    public int X { get; set; }
    //    public int Y { get; set; }
    //    public Point(int x, int y) : this()
    //    {
    //        X = x;
    //        Y = y;
    //    }
    //}
