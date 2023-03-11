char[,] board = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };

int move = 1;
char XO = 'X';
bool win = false;
char winner = '\0';

void PrintBoard()
{
    for (int i = 0; i < 3; i++)
    {
        blankLine();
        for (int j = 0; j < 3; j++)
        {
            Console.Write("  " + board[i, j] + "  ");
            if (j < 2)
                Console.Write("|");
        }
        Console.WriteLine();
        if (i < 2)
            fillLine();
    }
    blankLine();
}

void blankLine()
{
    int pipe = 0;
    for (int i = 0; i < 15; i++)
    {
        Console.Write(' ');
        pipe++;
        if (pipe == 5 || pipe == 10)
            Console.Write('|');
    }
    Console.WriteLine();
}

void fillLine()
{
    int pipe = 0;
    for (int i = 0; i < 15; i++)
    {
        Console.Write('_');
        pipe++;
        if (pipe == 5 || pipe == 10)
            Console.Write('|');
    }
    Console.WriteLine();
}

bool InsertPosition(int position, char XO)
{
    int pos = 1;

    for (int line = 0; line < board.GetLength(0); line++)
        for (int column = 0; column < board.GetLength(1); column++)
        {
            if (position < 1 || position > 9)
            {
                Console.WriteLine("Posição não encontrada. Informe outra posição");
                return false;
            }

            if (position == pos)
                if (board[line, column] != 'X' && board[line, column] != 'O')
                {
                    board[line, column] = XO;
                    return true;
                }
                else
                {
                    Console.WriteLine("Jogada inválida. Informe outra posição");
                    return false;
                }

            pos++;
        }
    return false;
}

bool CheckLine()
{
    int addX, addO;

    for (int line = 0; line < board.GetLength(0); line++)
    {
        addX = 0;
        addO = 0;

        for (int column = 0; column < board.GetLength(1); column++)
        {
            if (board[line, column] == 'X')
            {
                addX++;
                if (addX == 3)
                {
                    winner = 'X';
                    return true;
                }
            }
            else
            {
                if (board[line, column] == 'O')
                {
                    addO++;
                    if (addO == 3)
                    {
                        winner = 'O';
                        return true;
                    }
                }
            }
        }
    }

    return false;
}

bool CheckColumn()
{
    int addX, addO;

    for (int column = 0; column < board.GetLength(0); column++)
    {
        addX = 0;
        addO = 0;

        for (int line = 0; line < board.GetLength(1); line++)
            if (board[line, column] == 'X')
            {
                addX++;
                if (addX == 3)
                {
                    winner = 'X';
                    return true;
                }
            }
            else
                if (board[line, column] == 'O')
            {
                addO++;
                if (addO == 3)
                {
                    winner = 'O';
                    return true;
                }
            }
    }
    return false;
}

bool CheckDiagonal()
{
    int addX, addO, diagonalSec = board.GetLength(0);

    addX = 0;
    addO = 0;

    for (int diagonal = 0; diagonal < board.GetLength(0); diagonal++)
        if (board[diagonal, diagonal] == 'X')
            addX++;
        else
            if (board[diagonal, diagonal] == 'O')

            addO++;

    if (addX == 3)
    {
        winner = 'X';
        return true;
    }
    if (addO == 3)
    {
        winner = 'O';
        return true;
    }

    addX = 0;
    addO = 0;

    for (int diagonal = 0; diagonal < board.GetLength(0); diagonal++)
        if (board[diagonal, diagonalSec - 1 - diagonal] == 'X')
            addX++;
        else
            if (board[diagonal, diagonalSec - 1 - diagonal] == 'O')
            addO++;

    if (addX == 3)
    {
        winner = 'X';
        return true;
    }
    if (addO == 3)
    {
        winner = 'O';
        return true;
    }

    return false;
}

bool CheckWinner()
{
    if (CheckLine() || CheckColumn() || CheckDiagonal())
        return true;
    else
        return false;
}

PrintBoard();

do
{
    bool emptyPosition;
    do
    {
        int position;

        Console.Write($"\nJogador {XO}. Informe a posicao: ");
        position = int.Parse(Console.ReadLine());
        Console.WriteLine();

        emptyPosition = InsertPosition(position, XO);

    } while (!emptyPosition);

    if (XO == 'X')
        XO = 'O';
    else
        XO = 'X';

    Console.Clear();
    PrintBoard();

    if (move >= 5)
        win = CheckWinner();

    move++;
} while (move <= 9 && !win);

Console.Clear();
PrintBoard();

if (win)
    Console.WriteLine("\nJOGADOR '" + winner + "' VENCEU !!");
else
    Console.Write("\nDEU VELHA!");

Console.WriteLine("\nPressione qualquer tecla para encerrar...");
Console.ReadKey();