// See https://aka.ms/new-console-template for more information

Console.Write("Input number: ");
var input = Console.ReadLine();
if (input is null or "")
{
    Console.WriteLine("Input cannot be empty");
    return;
}

if (!int.TryParse(input, out var number))
{
    Console.WriteLine("Input must be number");
    return;
}

for (int i = 1; i <= number; i++)
{
    var output = "";
    if (i % 5 == 0 && i != 5)
    {
        output = "IDIC";
    }
    else if (i % 6 == 0 && i != 6)
    {
        output = "LPS";
    }
    else
    {
        output = i.ToString();
    }
    
    Console.Write($"{output} ");
}