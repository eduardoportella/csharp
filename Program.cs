using System.Diagnostics;

class Program
{
   static void Main(){
      BankAccount acc1 = new BankAccount("Eduardo", 1000);
      BankAccount acc2 = new BankAccount("Larissa", 999);

      // acc1.Deposit(-100);
      acc2.Deposit(200);

      Console.WriteLine(acc2.Balance);
   }
}

class BankAccount
{
   private string name;

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

   public BankAccount(string name, decimal balance){
      if (string.IsNullOrWhiteSpace(name)){
         // throw new Exception("Nome inválido.");
         throw new ArgumentException("Nome inválido.", nameof(name));
      }
      if (balance < 0){
         throw new Exception("Saldo não pode ser negativo");
      }
      this.name = name;
      Balance = balance;
   }

   public void Deposit(decimal amount){
      if (amount <= 0){
         throw new ArgumentException("Depósito não pode ser menor ou igual a zero.", nameof(amount));
      }
      Balance += amount;
   }

}
