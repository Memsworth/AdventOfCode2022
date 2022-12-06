namespace AdventOfCode;

public static class DayTwo
{
    public static void Solve(string filePath)
    {
        Console.WriteLine($"{Left.A.ToString()}");
        var inputs = File.ReadAllLines(filePath);
        var totalScore = 0;
        foreach (var item in inputs)
        {
            Left leftSide = Left.A;
            Right rightSide = Right.X;
            
            switch (item[0])
            {
                case 'A':
                    leftSide = Left.A;
                    break;
                case 'B':
                    leftSide = Left.B;
                    break;
                case 'C':
                    leftSide = Left.C;
                    break;
            }

            switch (item[2])
            {
                case 'X':
                    rightSide = Right.X;
                    break;
                case 'Y':
                    rightSide = Right.Y;
                    break;
                case 'Z':
                    rightSide = Right.Z;
                    break;
            }

            int currentScore = PartTwoSolver(leftSide, rightSide);
            totalScore += currentScore;
        }

        Console.WriteLine(totalScore);
    }

    private static int PartTwoSolver(Left leftSide, Right rightSide)
    {
        int match = 0;
        switch (rightSide)
        {
            case Right.X:
                match = GetLosePoint(leftSide);
                break;
            case Right.Y:
                match = GetDrawPoint(leftSide);
                break;
            case Right.Z:
                match = GetWinPoint(leftSide);
                break;
        }

        return match;
    }

    private static int GetWinPoint(Left leftSide)
    {
        return leftSide switch
        {
            Left.A => (int)Right.Y + (int)GameState.Win,
            Left.B => (int)Right.Z + (int)GameState.Win,
            Left.C => (int)Right.X + (int)GameState.Win,
        };
    }

    private static int GetDrawPoint(Left leftSide)
    {
        return leftSide switch                           
        {                                                
            Left.A => (int)Right.X + (int)GameState.Draw,
            Left.B => (int)Right.Y + (int)GameState.Draw,
            Left.C => (int)Right.Z + (int)GameState.Draw,
        };                                               
    }

    private static int GetLosePoint(Left leftSide)
    {
        return leftSide switch                           
        {                                                
            Left.A => (int)Right.Z + (int)GameState.Lose,
            Left.B => (int)Right.X + (int)GameState.Lose,
            Left.C => (int)Right.Y + (int)GameState.Lose,
        };                                               
    }

    private static int PartOneSolver(Left leftSide, Right rightSide)
    {
        int match = 0;
        if (leftSide == (Left)rightSide)
        {
            match = (int)GameState.Draw + (int)rightSide;
        }
        else
        {
            switch (rightSide)
            {
                case Right.X when leftSide == Left.C:
                case Right.Y when leftSide == Left.A:
                case Right.Z when leftSide == Left.B:
                    match = (int)rightSide + (int)GameState.Win;
                    break;
                
                case Right.X when leftSide == Left.B:           
                case Right.Y when leftSide == Left.C:           
                case Right.Z when leftSide == Left.A:           
                    match = (int)rightSide + (int)GameState.Lose;
                    break;                                      
            }
        }

        return match;
    }

    public enum Left
    {
        A =1, B=2, C=3
    }
    
    public enum Right
    {
        X=1, Y=2, Z=3
    }
    
    public enum GameState
    {
        Lose = 0,
        Draw = 3,
        Win = 6
    }
}