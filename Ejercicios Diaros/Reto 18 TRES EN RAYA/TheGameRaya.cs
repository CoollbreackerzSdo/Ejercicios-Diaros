using BenchmarkDotNet.Attributes;
using System.ComponentModel.DataAnnotations;
/*
 * Crea una función que analice una matriz 3x3 compuesta por "X" y "O"
 * y retorne lo siguiente:
 * - "X" si han ganado las "X"
 * - "O" si han ganado los "O"
 * - "Empate" si ha habido un empate
 * - "Nulo" si la proporción de "X", de "O", o de la matriz no es correcta.
 *   O si han ganado los 2.
 * Nota: La matriz puede no estar totalmente cubierta.
 * Se podría representar con un vacío "", por ejemplo.
 */
namespace Ejercicios_Diaros.Reto_18_TRES_EN_RAYA;
/// <summary>
/// Tablero y logica de 3 en raya
/// </summary>
public class TheGameRaya
{
    public TheGameRaya()
    {
        _Tablero = new char[9]
        {
            ' ',' ',' ',
            ' ',' ',' ',
            ' ',' ',' '
        };
    }
    /// <summary>
    /// retorna el los valores del tablero siendo un total de 9
    /// </summary>
    /// <returns></returns>
    public Span<char> GetTablero() => new(_Tablero);
    /// <summary>
    /// Verifica si ya todas las casillas estas completadas
    /// </summary>
    /// <returns></returns>
    public bool AnGanado()
    {
        Span<char> validador = _Tablero;
        //Verificar de manera vartical
        // A 1 2 3//
        if (validador[0] == validador[1] && validador[1] == validador[2] && validador[0] is not ' ')
            return true;
        // B 1 2 3//
        if (validador[3] == validador[4] && validador[4] == validador[5] && validador[3] is not ' ')
            return true;
        // C 1 2 3//
        if (validador[6] == validador[7] && validador[7] == validador[8] && validador[6] is not ' ')
            return true;
        //Verificar de manera Horizontal
        // A 1
        // B 1
        // C 1
        if (validador[0] == validador[3] && validador[3] == validador[6] && validador[0] is not ' ')
            return true;
        // A 2
        // B 2
        // C 2
        if (validador[1] == validador[4] && validador[4] == validador[7] && validador[1] is not ' ')
            return true;
        // A 3
        // B 3
        // C 3
        if (validador[2] == validador[5] && validador[5] == validador[8] && validador[2] is not ' ')
            return true;
        //Verificar en diagonal
        // A 1 
        // B  2
        // C   3
        if (validador[0] == validador[4] && validador[4] == validador[8] && validador[0] is not ' ')
            return true;
        // A   3 
        // B  2
        // C 1
        if (validador[2] == validador[4] && validador[4] == validador[6] && validador[2] is not ' ')
            return true;

        Turno = !Turno;
        _Count++;
        return false;
    }
    /// <summary>
    /// Verificamos si ya la partida tubo su total de jugadas si es haci es empate
    /// </summary>
    /// <returns></returns>
    public bool EsEmpate() => _Count is 9;
    /// <summary>
    /// Insertamos los valores en el tablero
    /// </summary>
    /// <param name="posicion"></param>
    /// <param name="carater"></param>
    public bool InsetarFicha([MaxLength(8), MinLength(0)] int posicion, char carater)
    {
        Span<char> validador = _Tablero;

        if (validador[posicion] is not ' ')
            return false;

        validador[posicion] = carater;
        return true;
    }
    /// <summary>
    /// Contador de jugadas echas
    /// </summary>
    private int _Count { get; set; } = 0;
    /// <summary>
    /// Tablero xD
    /// </summary>
    private char[] _Tablero;

    public bool Turno = true;
}
public class ConsoleGameRaya
{
    public ConsoleGameRaya()
    {
        _TheGame = new();
    }
    /// <summary>
    /// Juego de tres en taya
    /// </summary>
    public void Run()
    {
        //si ya todo acabo o se empato se termina el juego
        while (!_TheGame.AnGanado() && !_TheGame.EsEmpate())
        {
            //verificamos si no estan los mismos caracteres
            if (Fichas[0] == Fichas[1]) break;

            //mostramos el tablero
            Console.WriteLine($"""
                 !Tres en raya!
                     1 2 3
                    ╔═╦═╦═╗
                  A ║{_TheGame.GetTablero()[0]}║{_TheGame.GetTablero()[1]}║{_TheGame.GetTablero()[2]}║
                    ╠═╬═╬═╣
                  B ║{_TheGame.GetTablero()[3]}║{_TheGame.GetTablero()[4]}║{_TheGame.GetTablero()[5]}║ 
                    ╠═╬═╬═╣
                  C ║{_TheGame.GetTablero()[6]}║{_TheGame.GetTablero()[7]}║{_TheGame.GetTablero()[8]}║ 
                    ╚═╩═╩═╝
                Turno:{_TheGame.Turno switch
                {
                    true => Jugadores[0],
                    false => Jugadores[1]
                }}:jugaras con :{_TheGame.Turno switch
                {
                    true => Fichas[0],
                    false => Fichas[1]
                }}
                """);
            //ahora le pedimos al jugador de turno que juege
            do
            {
                Console.WriteLine("Ingresa tu posicion:");
                _Posicion = Console.ReadLine();
            } while (!Comandos());
            Console.Clear();
        }
        //si es empate se dice
        if (_TheGame.EsEmpate())
        {
            Console.WriteLine($"{Jugadores[0]}:{Jugadores[1]}:an empatado");
            return;
        }
        //Mostramos el jugador ganador
        Console.WriteLine($"El ganador es:{_TheGame.Turno switch
        {
            true => Jugadores[0],
            false => Jugadores[1]
        }}");
        Console.ReadKey();
    }
    /// <summary>
    /// insertamos los comandos en el tablero
    /// </summary>
    /// <returns></returns>
    private bool Comandos() => _Posicion switch
    {
        //ficha 1
        "A1" => _TheGame.InsetarFicha(0, _TheGame.Turno switch
        {
            true => Fichas[0],
            false => Fichas[1]
        }),
        "A2" => _TheGame.InsetarFicha(1, _TheGame.Turno switch
        {
            true => Fichas[0],
            false => Fichas[1]
        }),
        "A3" => _TheGame.InsetarFicha(2, _TheGame.Turno switch
        {
            true => Fichas[0],
            false => Fichas[1]
        }),
        //ficha 2
        "B1" => _TheGame.InsetarFicha(3, _TheGame.Turno switch
        {
            true => Fichas[0],
            false => Fichas[1]
        }),
        "B2" => _TheGame.InsetarFicha(4, _TheGame.Turno switch
        {
            true => Fichas[0],
            false => Fichas[1]
        }),
        "B3" => _TheGame.InsetarFicha(5, _TheGame.Turno switch
        {
            true => Fichas[0],
            false => Fichas[1]
        }),
        //ficha 3
        "C1" => _TheGame.InsetarFicha(6, _TheGame.Turno switch
        {
            true => Fichas[0],
            false => Fichas[1]
        }),
        "C2" => _TheGame.InsetarFicha(7, _TheGame.Turno switch
        {
            true => Fichas[0],
            false => Fichas[1]
        }),
        "C3" => _TheGame.InsetarFicha(8, _TheGame.Turno switch
        {
            true => Fichas[0],
            false => Fichas[1]
        }),
        _ => false
    };
    /// <summary>
    /// tablero de juego
    /// </summary>
    private readonly TheGameRaya _TheGame;
    /// <summary>
    /// chichas de los jugadores
    /// </summary>
    [MaxLength(2), MinLength(2)]
    public required char[] Fichas { internal get; set; }
    /// <summary>
    /// Nombre de los jugadores
    /// </summary>
    [MaxLength(2), MinLength(2)]
    public required string[] Jugadores { internal get; set; }
    /// <summary>
    /// Representa la posicion del puntero
    /// </summary>
    private string? _Posicion { get; set; } = string.Empty;
}