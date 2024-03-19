class Program
{
   static void Main(){
      string[] names = ["Eduardo", "Joao"];

      // Console.WriteLine(a[0]);

      // for(int i =0; i < names.Length; i++){
      //    Console.WriteLine(names[i]);
      // }

      if (string.Equals(names[0], "eduardo", StringComparison.OrdinalIgnoreCase)){
         Console.WriteLine("igual");
      }

      Console.WriteLine(names[0].Length);
      Console.WriteLine(names[0].StartsWith('E'));
      Console.WriteLine(names[0].Contains("Ed"));
      Console.WriteLine(names[0].IndexOf('a'));
      Console.WriteLine(names[0].IndexOf('p'));
      Console.WriteLine(string.IsNullOrWhiteSpace("  "));
      Console.WriteLine(string.Join(' ', names));


      foreach (string name in names){
         Console.WriteLine(name);
      }
   }
}

