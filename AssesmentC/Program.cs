// See https://aka.ms/new-console-template for more information

Console.Write("Input word: ");
var input = Console.ReadLine();
if (input is null or "")
{
    Console.WriteLine("Input cannot be empty");
    return;
}

input = input.Replace(" ", "");

var dict = new Dictionary<char, int>();
for (int i = 0; i < input.Length; i++)
{
    var isExist = dict.ContainsKey(input[i]);
    if (isExist)
    {
        dict[input[i]] += 1;
    }
    else
    {
        dict[input[i]] = 1;
    }
}

foreach (var d in dict)
{
    Console.WriteLine($"{d.Key} - {d.Value}");
}
