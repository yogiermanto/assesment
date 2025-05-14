// See https://aka.ms/new-console-template for more information

Console.Write("Input number: ");
var input = Console.ReadLine();
if (input is null or "")
{
    Console.WriteLine("Number cannot be empty");
    return;
}

input = input.Replace(".", "");
if (!int.TryParse(input, out _))
{
    Console.WriteLine("Input must be number!");
    return;
}

for (int i = 0; i < input.Length; i++)
{
    var number = input[i];
    if (number == '0')
    {
        continue;
    }

    var digit = (input.Length - 1) - i;
    var zeros = new string('0', digit);
    
    Console.WriteLine($"{number}{zeros}");
}