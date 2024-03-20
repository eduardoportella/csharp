using Bank;
// using Testing;

class Program
{
   static void Main(){
      BankAccount acc = new BankAccount("Eduardo", 100, new ConsoleLogger());
      "Eduardo".WriteLine(ConsoleColor.Red);
      // logger.Test();
   }
}
// namespace Testing {
namespace System {
static class Extensions {
   public static void WriteLine(this string text, ConsoleColor color){
      Console.ForegroundColor = color;
      Console.WriteLine(text);
      Console.ResetColor();
   }

   public static int Test(this int number){
      // "Testando".WriteLine(ConsoleColor.Green);

      return 1;
   }
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
      private string name;
      public readonly ILogger logger;

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

      public BankAccount(string name, decimal balance, ILogger logger){
         if (string.IsNullOrWhiteSpace(name)){
            // throw new Exception("Nome inválido.");
            throw new ArgumentException("Nome inválido.", nameof(name));
         }
         if (balance <= 0){
            throw new Exception("Saldo não pode ser negativo");
         }
         this.name = name;
         Balance = balance;
         this.logger = logger;
      }

      public void Deposit(decimal amount){
         if (amount <= 0){
            logger.Log($"Não é possível depositar {amount} na conta de {name}");
            // throw new ArgumentException("Depósito não pode ser menor ou igual a zero.", nameof(amount));
         }
         Balance += amount;
      }

   }
}
