using Microsoft.VisualBasic;

public class Program
{
    enum Move {
        Invalid = -1,
        Rock,
        Paper,
        Scissor,
        Quit
    }

    const int MinMove = (int)Move.Rock;
    const int MaxMove = (int)Move.Scissor + 1;

    enum Outcome {
        Draw = 0,
        UserWin = -1,
        ComputerWin = 1
    }

    public static void Main()
    {
        int seed = (int)DateTime.Now.Ticks;
        Random random = new Random(seed);
        int draws = 0;
        int wins = 0;
        int losses = 0;

        do
        {
            Console.Clear();

            Move userMove;
            
            do 
            {
                Console.WriteLine("Choose [r]ock, [p]aper, [s]cissors, or [q]uit:");
                string input = Console.ReadLine().ToLower();

                if (input == "r" || input == "rock")
                {
                    userMove = Move.Rock;
                }
                else if (input == "p" || input == "paper")
                {
                    userMove = Move.Paper;
                }
                else if (input == "s" || input == "scissor")
                {
                    userMove = Move.Scissor;
                }
                else if (input == "q" || input == "quit")
                {
                    userMove = Move.Quit;
                }
                else
                {
                    Console.WriteLine("Invalid entry");
                    userMove = Move.Invalid;  // invalid
                }
            } while (userMove == Move.Invalid);

            if (userMove == Move.Quit) return;

            Move computerMove = (Move)random.Next(MinMove, MaxMove);

            Outcome outcome = Outcome.Draw;
            if (userMove == Move.Rock)
            {
                if (computerMove == Move.Paper)
                {
                    outcome = Outcome.ComputerWin;
                }
                else if (computerMove == Move.Scissor)
                {
                    outcome = Outcome.UserWin;
                }
                else if (computerMove == Move.Rock)
                {
                    outcome = Outcome.Draw;
                }
            }
            else if (userMove == Move.Paper)
            {
                if (computerMove == Move.Scissor)
                {
                    outcome = Outcome.ComputerWin;
                }
                else if (computerMove == Move.Rock)
                {
                    outcome = Outcome.UserWin;
                }
                else if (computerMove == Move.Paper)
                {
                    outcome = Outcome.Draw;
                } 
            }
            else if (userMove == Move.Scissor )
            {
                if (computerMove == Move.Rock)
                {
                    outcome = Outcome.ComputerWin;
                }
                else if (computerMove == Move.Paper)
                {
                    outcome = Outcome.UserWin;
                }
                else if (computerMove == Move.Scissor)
                {
                    outcome = Outcome.Draw;
                }
            }

            switch (userMove)
            {
                case Move.Rock: 
                    Console.Write("You choose rock");
                    break;
                case Move.Paper: 
                    Console.Write("You choose paper");
                    break;
                case Move.Scissor: 
                    Console.Write("You choose scissors");
                    break;
            }

            
            switch (computerMove)
            {
                case Move.Rock: 
                    Console.WriteLine(" and Computer choose rock");
                    break;
                case Move.Paper: 
                    Console.WriteLine(" and Computer choose paper");
                    break;
                case Move.Scissor: 
                    Console.WriteLine(" and Computer choose scissors");
                    break;
            }
            
            switch (outcome)
            {
                case Outcome.Draw: // draw
                    Console.WriteLine("This game was a draw.");
                    draws++;
                    break;
                case Outcome.ComputerWin: // computers wins
                    Console.WriteLine("You lose.");
                    losses++;
                    break;
                case Outcome.UserWin: // user wins
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