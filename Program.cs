using System.Diagnostics;

class Program
{
   static void Main(){
      var logger = new FileLogger("mylog.txt");
      var acc1 = new BankAccount("Eduardo", 1000, logger);
      var acc2 = new BankAccount("Larissa", 999, logger);

      // List<BankAccount> accounts = new List<BankAccount>(){
      var accounts = new List<BankAccount>(){
         acc1,
         acc2
      };
      // accounts.Add(acc1);
      // accounts.Add(acc2);
      // accounts.Remove(acc1);
      // accounts.Remove(acc2);

      // List<int> numbers = new List<int>() {1, 2, 3};

      // foreach (BankAccount account in accounts){
      //    Console.WriteLine(account.Balance);
      // }

      // DataStore<string> store = new DataStore<string>();
      var store = new DataStore<string>();
      store.Value = "String";
      Console.WriteLine(store.Value.Length);
   }
}

class DataStore<T>{
   public T Value { get; set; }
}

class FileLogger : ILogger
{
    private readonly string filePath;

    public FileLogger(string filePath){
        this.filePath = filePath;
    }
   public void Log(string message){
      File.AppendAllText(filePath, $"{message}{Environment.NewLine}");
   }
}

class ConsoleLogger : ILogger
{
}

interface ILogger {
   void Log(string message){
      Console.WriteLine($"LOGGER: {message}");
   }
}

class BankAccount
{
   private string name;
    private readonly ILogger logger;

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
