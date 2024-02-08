using Microsoft.VisualBasic;

public class Program
{
    public static void Main()
    {
        int seed = (int)DateTime.Now.Ticks;
        Random random = new Random();
        int draws = 0;
        int wins = 0;
        int losses = 0;

        do
        {
            // get user option
            int userMove;
            
            do 
            {
                Console.WriteLine("Choose [r]ock, [p]aper, [s]cissors, or [q]uit:");
                string input = Console.ReadLine().ToLower();

                if (input == "r" || input == "rock")
                {
                    userMove = 0; // rock
                }
                else if (input == "p" || input == "paper")
                {
                    userMove = 1; // paper
                }
                else if (input == "s" || input == "scissor")
                {
                    userMove = 2;   // scissors
                }
                else if (input == "q" || input == "quit")
                {
                    userMove = 3;   // quit
                }
                else
                {
                    Console.WriteLine("Invalid entry");
                    userMove = -1;  // invalid
                }
            } while (userMove == -1);

            if (userMove == 3) return;

            int computerMove = random.Next(0, 3); // random number of [0,1,2]

            int result = 0; // draw
            if (userMove == 0 /* rock */ )
            {
                if (computerMove == 1 /* paper */)
                {
                    result = 1;  // computer win
                }
                else if (computerMove == 2 /* scissors */)
                {
                    result = -1; // user win
                }
                else /* rock */
                {
                    result = 0; // draw
                }
            }
            else if (userMove == 1 /* paper */ )
            {
                if (computerMove == 2 /* scissors */)
                {
                    result = 1; // computer win
                }
                else if (computerMove == 0 /* rock */)
                {
                    result = -1; // user win
                }
                else /* paper */
                {
                    result = 0;
                }
            }
            else if (userMove == 2 /* scissor */ )
            {
                if (computerMove == 0 /* rock */)
                {
                    result = 1; // computer win
                }
                else if (computerMove == 1 /* paper */)
                {
                    result = -1; // user win
                }
                else /* paper */
                {
                    result = 0;
                }
            }

            switch (userMove)
            {
                case 0: 
                    Console.Write("You choose rock");
                    break;
                case 1: 
                    Console.Write("You choose paper");
                    break;
                case 2: 
                    Console.Write("You choose scissors");
                    break;
            }

            
            switch (computerMove)
            {
                case 0: 
                    Console.WriteLine(" and Computer choose rock");
                    break;
                case 1: 
                    Console.WriteLine(" and Computer choose paper");
                    break;
                case 2: 
                    Console.WriteLine(" and Computer choose scissors");
                    break;
            }
            
            switch (result)
            {
                case 0: // draw
                    Console.WriteLine("This game was a draw.");
                    draws++;
                    break;
                case 1: // computers wins
                    Console.WriteLine("You lose.");
                    losses++;
                    break;
                case -1: // user wins
                    Console.WriteLine("You win.");
                    wins++;
                    break;
                default:
                    Console.WriteLine("Error, invalid outcome");
                    break;
            }

            Console.WriteLine("Score: {0} wins, {1} losses, {2} draws", wins, losses, draws);
        }
        while (true);
    }
}