using System;

namespace tictactoe
{
    class Program
    {
        static void Main(string[] args)
        {
            //game board array
            string[,] gameBoard = new string[5, 10]
            {
                {" "," "," "," "," "," "," "," "," "," "},
                {" ", "1"," ","|"," ", "2", " ","|"," ", "3"},
                {" ", "4"," ","|"," ", "5", " ","|"," ", "6"},
                {" ", "7"," ","|"," ", "8", " ","|"," ", "9"},
                {" "," "," "," "," "," "," "," "," "," "}
            };
            int turnCounter = 0;
            string playerMark = "X";
            int playerTurn = 1;
            Boolean gameOn = true;
            //game loop

            while (gameOn)
            {
                drawGameBoard(gameBoard);
                Console.Write($"Player{playerTurn}, Choose a space: ");

                int playerChoice = PlayerInput();
                while (playerChoice == 0)
                {
                    playerChoice = PlayerInput();
                }
                ChooseSpace(playerChoice, gameBoard, playerMark, playerTurn);


                if (WinCheck(playerMark, gameBoard))
                {
                    drawGameBoard(gameBoard);
                    Console.WriteLine($"Tic Tac Toe, three in a row! Player{playerTurn} Wins.");
                    gameOn = false;

                }
                //change turns
                if (playerTurn == 1)
                {
                    playerTurn = 2;
                    playerMark = "O";
                }
                else if (playerTurn == 2)
                {
                    playerTurn = 1;
                    playerMark = "X";
                }
                turnCounter++;
                if (turnCounter == 9)
                {
                    Console.WriteLine("Tie Game!");
                    gameOn = false;
                }
                if (gameOn == false)
                {
                    GameReset(ref gameBoard, ref gameOn, ref turnCounter, ref playerMark, ref playerTurn);
                }
            }
        }
        //Methods
        //method to draw gameboard
        public static void drawGameBoard(string[,] gameBoard)
        {
            int lineCounter = 0;
            Console.WriteLine("Welcome to Tic Tac Toe!");
            foreach (string x in gameBoard)
            {
                Console.Write(x);
                lineCounter++;
                if (lineCounter >= 10)
                {
                    Console.WriteLine();
                    lineCounter = 0;
                }
            }
        }
        //method to let users choose space and place their mark
        public static void ChooseSpace(int playerChoice, string[,] gameBoard, string playerMark, int playerTurn)
        {
            int x = GetIndex(gameBoard, playerChoice).Item1;
            int y = GetIndex(gameBoard, playerChoice).Item2;
            // check to see if position already filled. tuple(0,0) from method 'GetIndex' means a particular space has an X or O on the space.
            if (x == 0 && y == 0)
            {
                Console.Clear();
                drawGameBoard(gameBoard);
                Console.WriteLine("Position is already filled. Please choose another");
                Console.WriteLine($"Player{playerTurn}, Please choose a space.");
                playerChoice = PlayerInput();
                ChooseSpace(playerChoice, gameBoard, playerMark, playerTurn);
            }
            else
            {
                gameBoard[x, y] = playerMark;
            }
            Console.Clear();
        }
        public static bool WinCheck(string playerMark, string[,] gameBoard)
        {
            return (gameBoard[1, 1] == playerMark && gameBoard[2, 1] == playerMark && gameBoard[3, 1] == playerMark) ||
                   (gameBoard[1, 5] == playerMark && gameBoard[2, 5] == playerMark && gameBoard[3, 5] == playerMark) ||
                   (gameBoard[1, 9] == playerMark && gameBoard[2, 9] == playerMark && gameBoard[3, 9] == playerMark) ||
                   (gameBoard[1, 1] == playerMark && gameBoard[1, 5] == playerMark && gameBoard[1, 9] == playerMark) ||
                   (gameBoard[2, 1] == playerMark && gameBoard[2, 5] == playerMark && gameBoard[2, 9] == playerMark) ||
                   (gameBoard[3, 1] == playerMark && gameBoard[3, 5] == playerMark && gameBoard[3, 9] == playerMark) ||
                   (gameBoard[1, 1] == playerMark && gameBoard[2, 5] == playerMark && gameBoard[3, 9] == playerMark) ||
                   (gameBoard[1, 9] == playerMark && gameBoard[2, 5] == playerMark && gameBoard[3, 1] == playerMark);
        }
        public static Tuple<int, int> GetIndex(string[,] gameBoard, int playerChoice)
        {
            int lineCounter = 0;
            int num1 = 0;
            int num2 = 0;
            foreach (string x in gameBoard)
            {
                if (x == playerChoice.ToString())
                {
                    num1 = lineCounter / 10;
                    num2 = lineCounter % 10;
                    break;
                }
                else
                {
                    lineCounter++;
                    continue;
                }
            }
            return Tuple.Create(num1, num2);
        }

        public static int PlayerInput()
        {
            bool inputSuccess = int.TryParse(Console.ReadLine(), out int result);
            if (inputSuccess && result > 0 && result < 10)
            {
                return result;
            }

            else
            {
                Console.WriteLine("Invalid number. Please choose between 1 and 9");
                return 0;
            }
        }
        public static void GameReset(ref string[,] gameBoard, ref Boolean gameOn, ref int turnCounter, ref string playerMark, ref int playerTurn)
        {
            Console.WriteLine("Press enter to play again or close window to exit");
            Console.ReadKey();
            Console.Clear();
            gameBoard = new string[5, 10]
            {
                        {" "," "," "," "," "," "," "," "," "," "},
                        {" ", "1"," ","|"," ", "2", " ","|"," ", "3"},
                        {" ", "4"," ","|"," ", "5", " ","|"," ", "6"},
                        {" ", "7"," ","|"," ", "8", " ","|"," ", "9"},
                        {" "," "," "," "," "," "," "," "," "," "}
            };
            turnCounter = 0;
            playerMark = "X";
            playerTurn = 1;
            gameOn = true;
        }
    }
}
