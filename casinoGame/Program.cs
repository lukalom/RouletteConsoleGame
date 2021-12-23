double balance = 1000;
int[] red = { 32, 19, 21, 25, 34, 27, 36, 30, 23, 5, 16, 1, 14, 9, 18, 7, 12, 3 };


while (balance != 0)
{
    Random r = new Random();
    int RandomNumber = r.Next(0, 37);

    Console.Write("(1) only numbers, (2) only colors (3) both should match: ");
    bool isGameMode = int.TryParse(Console.ReadLine(), out int gameMode);


    if (isGameMode && (gameMode == 1 || gameMode == 2 || gameMode == 3))
    {
        Console.Write("Bet Money between 0 to 60: ");
        bool isBetMoney = int.TryParse(Console.ReadLine(), out int betMoney);

        if (isBetMoney && (betMoney > 0 && betMoney <= 60))
        {
            if (betMoney <= balance)
            {
                Console.WriteLine("Wish you luck ;)");
            }
            else
            {
                Console.WriteLine("you dont have enought money ;(");
                break;
            }
        }
        else
        {
            Console.WriteLine("betting error! bet in range (0, 60)");
            continue;
        }

        //only numbers win 2X
        if (gameMode == 1)
        {
            Console.Write("Enter Number Between (0, 35) range: ");
            bool isBetingNumber = int.TryParse(Console.ReadLine(), out int rouletteNumber);

            if (isBetingNumber && (rouletteNumber >= 0 && rouletteNumber < 36))
            {

                if (RandomNumber == rouletteNumber)
                {
                    balance += betMoney * 2;
                    Console.WriteLine($"you won: {betMoney * 2}: current balance {balance}");
                }
                else
                {
                    balance -= betMoney;
                    Console.WriteLine($"you lost: {betMoney} current balance {balance} computer number {RandomNumber}");
                };
            }
            else
            {
                Console.WriteLine("Enter correct roulette number");
                continue;
            }
        }

        //only colors win 20%
        if (gameMode == 2)
        {
            Console.Write("choose color number 1) black  2) red : ");
            bool isBetingColor = int.TryParse(Console.ReadLine(), out int rouletteColor);

            if (isBetingColor && (rouletteColor == 1 || rouletteColor == 2))
            {

                if (red.Contains(RandomNumber) && rouletteColor == 2)
                {
                    balance += betMoney + (betMoney / 5);
                    Console.WriteLine($"you won: {betMoney + (betMoney / 5)}: current balance {balance}");
                }
                else if (!red.Contains(RandomNumber) && rouletteColor == 1)
                {
                    balance += betMoney + (betMoney / 5);
                    Console.WriteLine($"you won: {betMoney + (betMoney / 5)}: current balance {balance}");
                }
                else
                {
                    balance -= betMoney;
                    Console.WriteLine($"you lost: {betMoney} current balance {balance}");

                };


            }
            else
            {
                Console.WriteLine("Enter correct roulette collor");
                continue;
            }


        }

        //colors and numbers should match exaclty win 2X + 20%
        if (gameMode == 3)
        {

            Console.Write("choose color number 1) black  2) red : ");
            bool isBetingColor = int.TryParse(Console.ReadLine(), out int rouletteColor);

            Console.Write("Enter Number Between (0, 35) range: ");
            bool isBetingNumber = int.TryParse(Console.ReadLine(), out int rouletteNumber);

            if (isBetingNumber && isBetingColor)
            {
                if ((rouletteColor == 1 || rouletteColor == 2) && (rouletteNumber >= 0 && rouletteNumber < 36))
                {       //19 witeli
                    if (RandomNumber == rouletteNumber && rouletteColor == 1 && !red.Contains(rouletteNumber) && !red.Contains(RandomNumber))
                    {
                        balance += 2 * betMoney + betMoney / 5;
                        Console.WriteLine($"you Won {2 * betMoney + betMoney / 5} current balance: {balance}");
                        Console.WriteLine($"you color {rouletteColor} number {rouletteNumber} computer number {RandomNumber}");
                    }
                    else if (RandomNumber == rouletteNumber && rouletteColor == 2 && red.Contains(rouletteNumber) && red.Contains(RandomNumber))
                    {
                        balance += 2 * betMoney + betMoney / 5;
                        Console.WriteLine($"you Won {2 * betMoney + betMoney / 5} current balance: {balance}");
                        Console.WriteLine($"you color {rouletteColor} number {rouletteNumber} computer number {RandomNumber}");
                    }
                    else if (RandomNumber == rouletteNumber)
                    {
                        if (rouletteNumber == 0)
                        {
                            balance += 36 * betMoney;
                            Console.WriteLine($"its Zero you Won 36X current balance: {balance}");
                        }
                        balance += 2 * betMoney;
                        Console.WriteLine($"you Won {2 * betMoney} current balance: {balance}");
                    }
                    else if (rouletteColor == 1 && !red.Contains(RandomNumber))
                    {
                        balance += betMoney / 5;
                        Console.WriteLine($"you Won {betMoney / 5} current balance: {balance}");
                    }
                    else if (rouletteColor == 2 && red.Contains(RandomNumber))
                    {
                        balance += betMoney / 5;
                        Console.WriteLine($"you Won {betMoney / 5} current balance: {balance}");
                    }
                    else
                    {
                        balance -= betMoney;
                        Console.WriteLine($"You lost computer picked number: {RandomNumber} current balance: {balance}");
                        continue;
                    }

                }
                else
                {
                    Console.WriteLine("enter correct collor or number");
                    continue;
                }
            }
            else
            {
                Console.WriteLine("Enter correct roulette collor and number");
                continue;
            }
        }
    }
    else
    {
        continue;
    }
}
