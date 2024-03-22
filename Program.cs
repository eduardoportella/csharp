using System.Text.Json;
using System.Text.Json.Serialization;
using Bank;
// using Testing;

class Program
{
   static void Main(){
      int[] numbers = [1,2,3, 44, 12, 123];

      // var n = numbers.First(number => number > 123);
      // var n = numbers.FirstOrDefault(number => number > 123);
      var n = numbers.OrderByDescending(number => number);

      foreach (var item in n)
      {
         Console.WriteLine(item);
      }

      var accounts = new List<BankAccount>{
         new BankAccount("Eduardo", 100) { 
            Branch = "123"
         },
         new BankAccount("Larissa", 50){
            Branch = "124"
         }
      };

      var acc = accounts.GroupBy(account => account.Branch);
      // var acc = accounts.OrderBy(account => account.Balance).ToArray();

      foreach (var group in acc)
      {
         Console.WriteLine($"Agência: {group.Key}");
         foreach (var account in group){
            Console.WriteLine($"{account.Name} possui {account.Balance}");
         }
         Console.WriteLine("-------");
      }

      //Classe anonima so funciona get, por razoes obvias
      var namesQuery = accounts.Select(account => new {
         // FullName = account.Name,
         // Branch = account.Branch
         account.Name,
         account.Branch
      });

      var test = Enumerable.Empty<int>();

      Console.WriteLine(namesQuery);


   }
}

class BranchCustomer {
   public string Name { get; set; }
   public string Branch { get; set; }
}

namespace Bank {

   public class FileLogger : ILogger
   {
      private readonly string filePath;

      public FileLogger(string filePath){
         this.filePath = filePath;
      }
      public void Log(string message){
         File.AppendAllText(filePath, $"{message}{Environment.NewLine}");
      }
   }

   public class ConsoleLogger : ILogger
   {
   }

   public interface ILogger {
      void Log(string message){
         Console.WriteLine($"LOGGER: {message}");
      }
   }

   public class BankAccount
   {
      public readonly ILogger logger;

      public string Branch;

      public string Name {
         get; private set;
      }

      public decimal Balance {
         get; private set;
         // get {return balance; } 
         // private set {
         //    if (value >= 0 ) {
         //       balance = value; 
         //    } else {
         //       // ...
         //    }
         // } 
      }


      [JsonConstructor]
      public BankAccount(string name, decimal balance) : this(name, balance, new ConsoleLogger()){

      }

      public BankAccount(string name, decimal balance, ILogger logger){
         if (string.IsNullOrWhiteSpace(name)){
            // throw new Exception("Nome inválido.");
            throw new ArgumentException("Nome inválido.", nameof(name));
         }
         if (balance <= 0){
            throw new Exception("Saldo não pode ser negativo");
         }
         Name = name;
         Balance = balance;
         this.logger = logger;
      }

      public void Deposit(decimal amount){
         if (amount <= 0){
            logger.Log($"Não é possível depositar {amount} na conta de {Name}");
            // throw new ArgumentException("Depósito não pode ser menor ou igual a zero.", nameof(amount));
         }
         Balance += amount;
      }

   }
}
