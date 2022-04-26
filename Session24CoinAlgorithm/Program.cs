
Console.WriteLine("Please, enter the price of the item:");
string input1 = Console.ReadLine();
if (double.TryParse(input1, out double itemPrice) == false)
{
    Console.WriteLine("Please, enter a valid price.");
    return;
}

Console.WriteLine("Please, enter how much you've given to the cashier:");
string input2 = Console.ReadLine();
if (double.TryParse(input2, out double moneyPaid) == false)
{
    Console.WriteLine("Please, enter a valid sum of money you've paid.");
    return;
}

if (itemPrice > moneyPaid)
{
    Console.WriteLine("Please, pay the full price!");
    return;
}

decimal changeGiven = (decimal)(moneyPaid - itemPrice);

Dictionary<string, decimal> CoinValuesDict = new Dictionary<string, decimal>();
CoinValuesDict.Add("Two Euro", 2);
CoinValuesDict.Add("One Euro", 1);
CoinValuesDict.Add("Fifty Cents", 0.5M);
CoinValuesDict.Add("Ten Cents", 0.1M);
CoinValuesDict.Add("Five Cents", 0.05M);
CoinValuesDict.Add("Two Cents", 0.02M);
CoinValuesDict.Add("One Cent", 0.01M);

var changeToGive = new Dictionary<string, int>();
foreach (var coin in CoinValuesDict)
{
    var amountOfCoins = (int)(changeGiven / coin.Value);
    if (amountOfCoins == 0)
    {
        continue;
    }

    changeToGive.Add(coin.Key, amountOfCoins);

    changeGiven = changeGiven - coin.Value * amountOfCoins;
    if (changeGiven == 0)
    {
        break;
    }
}

Console.WriteLine();
Console.WriteLine("The cashier gave you change this way:");

foreach (var coin in changeToGive)
{
    Console.WriteLine($"The number of {coin.Key} coins is: {coin.Value}");
}