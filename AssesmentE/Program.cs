// See https://aka.ms/new-console-template for more information

Console.Write("Input word: ");
var input = Console.ReadLine();
if (input is null or "")
{
    Console.WriteLine("Input cannot be empty");
    return;
}

input = input.ToLower();

var formatBiasa = input[0].ToString().ToUpper() + input.Substring(1);
var formatJudul = "";

var subInput = input.Split(" ");
for (int i = 0; i < subInput.Length; i++)
{
    var word = subInput[i][0].ToString().ToUpper() + subInput[i].Substring(1);
    formatJudul += word + " ";
}

Console.WriteLine($"Format Judul: {formatJudul}");
Console.WriteLine($"Format Biasa: {formatBiasa}");