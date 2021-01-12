using System;

namespace TicTacToe
{
    class MainClass
    {
        static int player = 1;
        static int playerField;
        static char token;
        static bool validEntry = false;
        static int count = 0;

        //Game board that will constantly get updated.
        static char[,] game =
            {
                {'1', '2', '3' },
                {'4', '5', '6' },
                {'7', '8', '9' }
            };

        //Intial gameboard
        static char[,] gameInitial =
            {
                {'1', '2', '3' },
                {'4', '5', '6' },
                {'7', '8', '9' }
            };


        public static void Main(string[] args)
        {
            do
            {
                SetField();
                CheckIfWinner();

                do
                {
                    Console.Write("\nPlayer{0}, state your field: ", player);

                    try
                    {
                        playerField = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\nPlease enter a valid number");
                    }


                    //Does not change gameboard if invalid entry
                    validEntry = isValidEntry(playerField);
                    if (validEntry)
                    {
                        playerChoice(player, playerField);
                        if (player == 1)
                            player = 2;
                        else
                            player = 1;
                    }
                    else
                        Console.WriteLine("Invalid entry, please try again");

                } while (!validEntry);

            } while (true);
        }

        //Draw tic tac toe board, and clear console everytime method is run.
        public static void SetField()
        {
            Console.Clear();
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", game[0, 0], game[0, 1], game[0, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", game[1, 0], game[1, 1], game[1, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", game[2, 0], game[2, 1], game[2, 2]);
            Console.WriteLine("     |     |     ");
        }

        //Method to restart game
        public static void ResetField()
        {
            game = gameInitial;
            player = 1;
            SetField();
            count = 0;
        }

        //Replace number on gameboard with either players token (X or O).
        public static void playerChoice(int player, int value)
        {
            switch (player)
            {
                case 1: token = 'X'; break;
                case 2: token = 'O'; break;
            }

            switch (value)
            {
                case 1: game[0, 0] = token; break;
                case 2: game[0, 1] = token; break;
                case 3: game[0, 2] = token; break;
                case 4: game[1, 0] = token; break;
                case 5: game[1, 1] = token; break;
                case 6: game[1, 2] = token; break;
                case 7: game[2, 0] = token; break;
                case 8: game[2, 1] = token; break;
                case 9: game[2, 2] = token; break;
            }

            count++;
        }

        //Check if entered value by player is valid or not.
        public static bool isValidEntry(int value)
        {
            switch (value)
            {
                case 1:
                    if (game[0, 0] == '1')
                        return true;
                    else
                        return false;
                   
                case 2:
                    if (game[0, 1] == '2')
                        return true;
                    else
                        return false;

                case 3:
                    if (game[0, 2] == '3')
                        return true;
                    else
                        return false;

                case 4:
                    if (game[1, 0] == '4')
                        return true;
                    else
                        return false;

                case 5:
                    if (game[1, 1] == '5')
                        return true;
                    else
                        return false;

                case 6:
                    if (game[1, 2] == '6')
                        return true;
                    else
                        return false;

                case 7:
                    if (game[2, 0] == '7')
                        return true;
                    else
                        return false;

                case 8:
                    if (game[2, 1] == '8')
                        return true;
                    else
                        return false;

                case 9:
                    if (game[2, 2] == '9')
                        return true;
                    else
                        return false;

                default:
                    return false;

            }
        }


        //Check if there is a winner and restart.
        public static void CheckIfWinner()
        {
            char[] tokens = { 'X', 'O' };

            foreach (char token in tokens)
            {
                if (((game[0, 0] == token) && (game[0, 1] == token) & (game[0, 2] == token))
                    || ((game[1, 0] == token) && (game[1, 1] == token) & (game[1, 2] == token))
                    || ((game[2, 0] == token) && (game[2, 1] == token) & (game[2, 2] == token))
                    || ((game[0, 0] == token) && (game[1, 0] == token) & (game[2, 0] == token))
                    || ((game[0, 1] == token) && (game[1, 1] == token) & (game[2, 1] == token))
                    || ((game[0, 2] == token) && (game[1, 2] == token) & (game[2, 2] == token))
                    || ((game[0, 0] == token) && (game[1, 1] == token) & (game[2, 2] == token))
                    || ((game[0, 2] == token) && (game[1, 1] == token) & (game[2, 0] == token)))
                {
                    if (token == 'X')
                        Console.WriteLine("\nPlayer1 is the winner!");
                    else
                        Console.WriteLine("\nPlayer2 is the winner!");

                    Console.WriteLine("Press any key to play again.");
                    Console.ReadKey();

                    ResetField();
                }

                else if (count == 9)
                {
                    Console.WriteLine("DRAW!");
                    Console.WriteLine("Press any key to play again.");
                    Console.ReadKey();
                    ResetField();
                }
            }
        }
    }
}
