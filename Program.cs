using System;

class DungeonEscapeGame
{
    static int playerPosition = 1;
    static bool hasKey = false;
    static bool isGameOver = false;

    // Wall positions that block movement
    static int[] wallPositions = { 3, 7 };

    static void Main(string[] args)
    {
        while (!isGameOver)
        {
            DisplayGame();
            HandlePlayerInput();
        }

        // Keep console window open after game ends
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void DisplayGame()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Dungeon Escape Game");
        Console.WriteLine($"Current Position: {playerPosition}");
        Console.WriteLine($"Key Found: {hasKey}");

        //// Grid representation of the dungeon. W = Wall, T = Trap, K = Key, E = Exit
        //Console.WriteLine(" 1 | 2 | W ");
        //Console.WriteLine(" T | 5 | E ");
        //Console.WriteLine(" W | 8 | K ");

        Console.WriteLine(" 1 | 2 | 3 ");
        Console.WriteLine(" 4 | 5 | 6 ");
        Console.WriteLine(" 7 | 8 | 9 ");

    }
    // Handles players movement
    static void HandlePlayerInput()
    {
        Console.Write("Move (up/down/left/right): ");
        string input = Console.ReadLine().ToLower();

        // Temporary variable to check move
        int newPosition = playerPosition;

        if (playerPosition == 1)
        {
            if (input == "right") newPosition = 2;
            else if (input == "down") newPosition = 4;
            else
            {
                Console.WriteLine("Invalid move!");
                Console.ReadKey();
                return;
            }
        }
        else if (playerPosition == 2)
        {
            if (input == "left") newPosition = 1;
            else if (input == "right") newPosition = 3;
            else if (input == "down") newPosition = 5;
            else
            {
                Console.WriteLine("Invalid move!");
                Console.ReadKey();
                return;
            }
        }
        else if (playerPosition == 3)
        {
            // Wall - prevent movement
            Console.WriteLine("A wall blocks your path!");
            Console.ReadKey();
            return;
        }
        else if (playerPosition == 4)
        {
            if (input == "up") newPosition = 1;
            else if (input == "right") newPosition = 5;
            else if (input == "down") newPosition = 7;
            else
            {
                Console.WriteLine("Invalid move!");
                Console.ReadKey();
                return;
            }
        }
        else if (playerPosition == 5)
        {
            if (input == "up") newPosition = 2;
            else if (input == "left") newPosition = 4;
            else if (input == "right") newPosition = 6;
            else if (input == "down") newPosition = 8;
            else
            {
                Console.WriteLine("Invalid move!");
                Console.ReadKey();
                return;
            }
        }
        else if (playerPosition == 6)
        {
            if (input == "up") newPosition = 3;
            else if (input == "left") newPosition = 5;
            else if (input == "down") newPosition = 9;
            else
            {
                Console.WriteLine("Invalid move!");
                Console.ReadKey();
                return;
            }
        }
        else if (playerPosition == 7)
        {
            // Wall - prevent movement
            Console.WriteLine("A wall blocks your path!");
            Console.ReadKey();
            return;
        }
        else if (playerPosition == 8)
        {
            if (input == "up") newPosition = 5;
            else if (input == "left") newPosition = 7;
            else if (input == "right") newPosition = 9;
            else
            {
                Console.WriteLine("Invalid move!");
                Console.ReadKey();
                return;
            }
        }
        else if (playerPosition == 9)
        {
            if (input == "up") newPosition = 6;
            else if (input == "left") newPosition = 8;
            else
            {
                Console.WriteLine("Invalid move!");
                Console.ReadKey();
                return;
            }
        }

        // Check if new position is a wall
        if (Array.Exists(wallPositions, w => w == newPosition))
        {
            Console.WriteLine("A wall blocks your path!");
            Console.ReadKey();
            return;
        }

        // Update position
        playerPosition = newPosition;

        CheckSpecialPositions();
    }
    // Check if player is on a special position
    static void CheckSpecialPositions()
    {
        switch (playerPosition)
        {
            case 9: // Key location 
                if (!hasKey)
                {
                    hasKey = true;
                    Console.WriteLine("You found the key!");
                    Console.ReadKey();
                }
                break;

            case 6: // Exit
                if (hasKey)
                {
                    Console.WriteLine("Congratulations! You escaped!");
                    isGameOver = true;
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("You need the key to escape!");
                    Console.ReadKey();
                }
                break;

            case 4: // Trap
                Console.WriteLine("You fell into a trap!");
                Console.WriteLine("Game over!!!");
                isGameOver = true;
                Console.ReadKey();
                break;
        }
    }
}