public class Coordinates
{
    private const int SIZE = 3;
    private string[,] matrix = new string[SIZE, SIZE];
    public string[,] Matrix { get => matrix; set => matrix = value; }

    public int[] ObtainPositionInMatrix(int positionInArray)
    {
        int x = GetXPosition(positionInArray);
        int y = GETYPosition(positionInArray);
        int[] positionInMatrix = { x, y };
        return positionInMatrix;
    }


    private int GetXPosition(int positionInArray)
    {
        return positionInArray % SIZE;
    }
    private int GETYPosition(int positionInArray)
    {
        return positionInArray / SIZE;
    }
    private int GetIndexFromCoordinates(int x, int y)
    {
        return x + y * SIZE;
    }

    public void SavePositionInMatrix(string player, int[] positionInMatrix)
    {
        Matrix[positionInMatrix[0], positionInMatrix[1]] = player;
    }

    public void CleanMatrix()
    {
        for (int column = 0; column < Matrix.GetLength(1); column++)
        {
            for (int row = 0; row < Matrix.GetLength(0); row++)
            {
                Matrix[row, column] = null;
            }
        }
        
    }

    public string GetPlayerPositions(string[,] matrix, string player)
    {
        string playerPositions = "";
        for (int column = 0; column < matrix.GetLength(1); column++)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, column] == player)
                {
                    playerPositions += GetIndexFromCoordinates(row, column).ToString();
                }
            }
        }
        return playerPositions;
    }
}