using System.Diagnostics;

class Program
{
   static void Main(){
   

   // int i = 10;

   // if (int.TryParse("asdfadsf", out int result)){
   //    Console.WriteLine("sucesso");
   // } else {
   //    Console.WriteLine("false");
   // }
   
   // Console.WriteLine(result);

   // int i = 10;
   // long l = 10;


   // //Long pode armazenar inteiro
   // l = i;

   // //Int nao pode receber devido a memoria
   // // i = l;

   // i = (int)l; //Conversao explicita
   // string s = l.ToString();

   // Console.WriteLine(i);

   int i = 10;
   int i2 = i;
   i = 30;
   // i2 = 20;

   Test t = new Test();
   t.X = 12;

   // Test t2 = t; //Aqui eh referencia pra t
   Test t2 = new Test();
   t2.X = 20;

   Console.WriteLine(t.X);

   }
}

class Test{

   public int X;

}

