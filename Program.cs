using System.Diagnostics;

class Program
{
   static void Main(){
      // string s = null;
      int[] numbers = [1];


      try
      {
         Console.WriteLine(numbers[1]);
   
      }
      // catch (System.Exception)
      catch (System.NullReferenceException exception)
      {
         Console.WriteLine($"erro de referência nula. {exception.Message}");
      }

      catch (System.IndexOutOfRangeException exception)
      {
         Console.WriteLine($"erro. {exception.Message}");
      }

      catch (Exception exception){
         Console.WriteLine($"Erro: {exception.Message}");
      }



   }
}
