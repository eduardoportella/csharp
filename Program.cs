using System.Diagnostics;

class Program
{
   static void Main(){
   //   Run(Multiply);
      var multiply = delegate (int x, int y) {return x*y;};
      var sum = delegate (int x, int y) {return x+y;};
      Run(multiply);
      Run(sum);

      // Action<string> teste = delegate (string name) {Console.WriteLine($"Olá {name}");};
      var teste = delegate (string name) {Console.WriteLine($"Olá, {name}");};

      teste("Eduardo Portella");
      // Console.WriteLine(multiply(2, 5));
   }

   static void Run(Func<int, int, int> calc){
      Console.WriteLine(calc(20,30));
   }

   // static int Multiply(int x, int y){
   //    return x*y;
   // }

   static int Sum(int a, int b){
      return a + b;
   }
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
