using System.Text.Json;
using System.Text.Json.Serialization;
using Bank;
// using Testing;

class Program
{
   static void Main(){
      BankAccount acc = new BankAccount("Eduardo", 100, new ConsoleLogger());
        string json = JsonSerializer.Serialize(acc);

        Console.WriteLine(json);

      BankAccount acc2 = JsonSerializer.Deserialize<BankAccount>(json);

        Console.WriteLine(acc2.Name);

   }
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
