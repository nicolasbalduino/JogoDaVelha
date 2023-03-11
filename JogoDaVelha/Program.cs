char[,] tabuleiro = new char[3, 3];
char letra;
int linha, coluna, contador;

bool InsereNaPosicao(int linha, int coluna, char letra)
{
    if ((linha > 3 || linha == null) || (coluna > 3 || coluna == null))
        return false;
    if (tabuleiro[linha, coluna] != 'X' && tabuleiro[linha, coluna] != 'O')
    {
        tabuleiro[linha, coluna] = letra;
        return true;
    }
    return false;
}

void MostraTabuleiro()
{
    for (linha = 0; linha < 3; linha++)
    {
        for (coluna = 0; coluna < 3; coluna++)
            Console.Write("[" + tabuleiro[linha, coluna] + "]");
        Console.WriteLine();
    }
}

bool ExistePosicaoVazia()
{
    for (linha = 0; linha < 3; linha++)
    {
        for (coluna = 0; coluna < 3; coluna++)
            if (tabuleiro[linha, coluna] != 'X' && tabuleiro[linha, coluna] != 'O')
                return true;
    }
    return false;
}

bool VerificaLinha()
{
    int somaX, somaO;

    for (linha = 0; linha < 3; linha++)
    {
        somaX = 0;
        somaO = 0;
        for (coluna = 0; coluna < 3; coluna++)
        {
            if (tabuleiro[linha, coluna] == 'X')
                somaX++;
            else
                if (tabuleiro[linha, coluna] == 'O')
                somaO++;

        }
        if (somaX == 3)
            return true;
        else
            if (somaO == 3)
            return true;
    }
    return false;
}

bool VerificaColuna()
{
    int somaX, somaO;

    for (coluna = 0; coluna < 3; coluna++)
    {
        somaX = 0;
        somaO = 0;
        for (linha = 0; linha < 3; linha++)
        {
            if (tabuleiro[linha, coluna] == 'X')
                somaX++;
            else
                if (tabuleiro[linha, coluna] == 'O')
                somaO++;

        }
        if (somaX == 3)
            return true;
        else
            if (somaO == 3)
            return true;
    }
    return false;
}

bool VerificaDiagonalPrincipal()
{
    int somaX = 0, somaO = 0;

    for (int diagonal = 0; diagonal < 3; diagonal++)
    {
        if (tabuleiro[diagonal, diagonal] == 'X')
            somaX++;
        else
            if (tabuleiro[diagonal, diagonal] == 'O')
            somaO++;

    }
    if (somaX == 3)
        return true;
    else
        if (somaO == 3)
        return true;
    return false;
}

bool VerificaDiagonalSecundaria()
{
    int somaX = 0, somaO = 0;

    for (int diagonal = 0; diagonal < 3; diagonal++)
    {
        if (tabuleiro[diagonal, (2 - diagonal)] == 'X')
            somaX++;
        else
            if (tabuleiro[diagonal, (2 - diagonal)] == 'O')
            somaO++;

    }
    if (somaX == 3)
        return true;
    else
        if (somaO == 3)
        return true;
    return false;
}

bool Ganhador()
{
    if (VerificaLinha() || VerificaColuna() || VerificaDiagonalPrincipal() || VerificaDiagonalSecundaria())
        return true;
    else
        return false;
}

MostraTabuleiro();

letra = 'X';
while (ExistePosicaoVazia() && !Ganhador())
{
    Console.WriteLine("\nLetra " + letra);
    do
    {
        Console.Write("Informe o numero da linha: ");
        linha = int.Parse(Console.ReadLine());
        Console.Write("Informe o numero da coluna: ");
        coluna = int.Parse(Console.ReadLine());
    } while (!InsereNaPosicao(linha, coluna, letra));

    if (letra == 'X')
        letra = 'O';
    else
        letra = 'X';

    MostraTabuleiro();
}

Console.WriteLine("\nACABOU!");
Console.ReadLine();
