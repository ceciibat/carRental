﻿
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

