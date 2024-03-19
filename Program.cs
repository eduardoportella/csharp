Console.Write("Digite seu nome: ");
string nome = Console.ReadLine();

Console.WriteLine($"Olá, {nome}");

Console.Write("Digite o ano do seu nascimento: ");
int year = int.Parse(Console.ReadLine());

int age = 2024-year;

Console.WriteLine($"Você tem {age} anos");

if (age > 18){
   Console.WriteLine("Você é maior de idade");
} else {
   Console.WriteLine("Você é menor de idade");
}
