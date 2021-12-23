double balance = 1000;
int[] red = { 32, 19, 21, 25, 34, 27, 36, 30, 23, 5, 16, 1, 14, 9, 18, 7, 12, 3 };
int[] black = { 15, 4, 2, 17, 6, 13, 11, 8, 10, 24, 33, 20, 31, 22, 29, 28, 35, 26 };

while (balance != 0)
{
    Random r = new Random();
    int RandomNumber = r.Next(0, 36);
    int RandomColor = r.Next(1, 3);
    int ComputerRandomNumberRed = red[r.Next(0, 18)];
    int ComputerRandomNumberBlack = black[r.Next(0, 18)];
    int ComputerRandomNumberColor = (RandomColor == 1) ? ComputerRandomNumberRed : ComputerRandomNumberBlack;

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
            bool isBetingNumber = int.TryParse(Console.ReadLine(), out int roulletNumber);

            if (isBetingNumber && (roulletNumber >= 0 && roulletNumber < 36))
            {

                if (RandomNumber == roulletNumber)
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
            bool isBetingColor = int.TryParse(Console.ReadLine(), out int roulletColor);

            if (isBetingColor && (roulletColor == 1 || roulletColor == 2))
            {

                if (RandomColor == roulletColor)
                {
                    balance += betMoney + (betMoney / 5);
                    Console.WriteLine($"you won: {betMoney + (betMoney / 5)}: current balance {balance}: computer color {RandomColor}");
                }
                else
                {
                    balance -= betMoney;
                    Console.WriteLine($"you lost: {betMoney} current balance {balance} collor number {RandomColor}");

                };


            }
            else
            {
                Console.WriteLine("Enter correct roulette collor");
                continue;
            }


        }

        //colors and numbers should match exaclty win 5X
        if (gameMode == 3)
        {

            Console.Write("choose color number 1) black  2) red : ");
            bool isBetingColor = int.TryParse(Console.ReadLine(), out int roulletColor);

            Console.Write("Enter Number Between (0, 35) range: ");
            bool isBetingNumber = int.TryParse(Console.ReadLine(), out int roulletNumber);

            if (isBetingNumber && isBetingColor)
            {
                if (ThirGameModeValidator(roulletColor, roulletNumber))
                {
                    if (ComputerRandomNumberColor == roulletNumber)
                    {
                        balance += betMoney;
                        Console.WriteLine($"you Won {5 * betMoney} current balance: {balance}");
                        Console.WriteLine($"you color {roulletColor} number {roulletNumber} computer number {ComputerRandomNumberColor}");
                    }
                    else
                    {
                        balance -= betMoney;
                        Console.WriteLine($"You lost computer picked number: {ComputerRandomNumberRed} current balance: {balance}");
                        continue;
                    }

                }
                else
                {
                    Console.WriteLine("check if color matchs the number in table. or enter correct values");
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

bool ThirGameModeValidator(int roulletColor, int roulletNumber)
{
    bool validated = false;

    bool validatedColor = (roulletColor == 1 || roulletColor == 2) ? true : false;
    bool validatedNumber = (roulletNumber >= 0 && roulletNumber < 36) ? true : false;

    if (roulletColor == 1 && black.Contains(roulletNumber)) { validated = true; }
    else if (roulletColor == 2 && red.Contains(roulletNumber)) { validated = true; }
    else { validated = false; }


    return validated && validatedColor && validatedNumber;

}