/*
 * Crea un programa que calcule quien gana más partidas al piedra,
 * papel, tijera.
 * - El resultado puede ser: "PaperPlayer 1", "PaperPlayer 2", "Tie" (empate)
 * - La función recibe un listado que contiene pares, representando cada jugada.
 * - El par puede contener combinaciones de "R" (piedra), "P" (papel)
 *   o "S" (tijera).
 * - Ejemplo. Entrada: [("R","S"), ("S","R"), ("P","S")]. Resultado: "PaperPlayer 2".
 */
using System.ComponentModel.DataAnnotations;

namespace Ejercicios_Diaros.Reto_25_PIEDRA__PAPEL__TIJERA;
/// <summary>
/// Logica de PaperGame
/// </summary>
public sealed class PaperGame
{
    public PaperGame(string playerOne,string playerTwo)
    {
        _playerNames = new string[]
        {
            playerOne,
            playerTwo
        };
    }
    /// <summary>
    /// ingresa la opcion correspondiente de (P(papel),S(tijera),R(piedra)) 
    /// </summary>
    /// <param name="tick1">
    /// ficha de la jugada del jugador 1 ya sea (P,S,R)
    /// </param>
    /// <param name="tick2">
    /// ficha de la jugada del jugador 2 ya sea (P,S,R)
    /// </param>
    /// <returns>
    /// el ganador de la ronda o un empate si se da el caso mostrado en consola
    /// </returns>
    //solamente obtenemos las jugadas de los jugadores y incrementamos sus contadores de partidas ganadas
    public string PaperRun(string tick1, string tick2) => (tick1, tick2) switch
    {
        //papel vs tijera
        ("P","S") => $"Ganadro:{_playerNames[1]}: y a ganado:{_partidasGanatasPlayerTwo++}",
        //tijera vs papel
        ("S","P") => $"Ganador:{_playerNames[0]}: y a ganado:{_partidasGanatasPlayerOne++}",
        //tijera vs piedra
        ("S","R") => $"Ganador:{_playerNames[1]}: y a ganado:{_partidasGanatasPlayerTwo++}",
        //piedra vs tijera
        ("R","S") => $"Ganador:{_playerNames[0]}: y a ganado:{_partidasGanatasPlayerOne++}",
        //piedra vs papel
        ("R","P") => $"Ganador:{_playerNames[1]}: y a ganado:{_partidasGanatasPlayerTwo++}",
        //papel vs piedra
        ("P","R") => $"Ganador:{_playerNames[0]}: y a ganado:{_partidasGanatasPlayerOne++}",
        //por defauld
        _ => "Empate"
    };
    /// <summary>
    /// </summary>
    /// <returns>
    /// El ganador con la mayor numero de partidas ganadas
    /// </returns>
    //mostramos quien gano mas partidas
    public string GanadorFinal() => _partidasGanatasPlayerOne > _partidasGanatasPlayerTwo ? 
        $"Ganador total:{_playerNames[0]}" : 
        $"Ganador total:{_playerNames[1]}";
    
    private int _partidasGanatasPlayerTwo { get; set; } = 1;
    private int _partidasGanatasPlayerOne { get; set; } = 1;
    private readonly string[] _playerNames;
}
/// <summary>
/// PaperGame para consola de juegos automaticos
/// </summary>
public class PaperGameIaPlayersConsole
{
    public PaperGameIaPlayersConsole()
    {
        _game = new("Player1","player2");
    }
    /// <summary>
    /// establece las Ias para el juego
    /// </summary>
    public void GenerateIa()
    {
        _iaPlayerOne = new();
        _iaPlayerTwo = new();
    }
    /// <summary>
    /// Inicializa la partidad
    /// </summary>
    /// <param name="numberParts">
    /// Numero de partidas que se ejecutaran
    /// </param>
    /// <exception cref="NullReferenceException">
    /// Si las Ias no estan inicializadas lanzara una exepcion 
    /// </exception>
    public void Run(int numberParts)
    {
        if (_iaPlayerOne is null || _iaPlayerTwo is null) throw new NullReferenceException("Las Ias son nulas");

        for (int i = 0; i < numberParts; i++)
        {
            Console.WriteLine(_game.PaperRun(_iaPlayerOne.Tick(),_iaPlayerTwo.Tick()));
        }

        Console.WriteLine();
        Console.WriteLine(_game.GanadorFinal());
    }
    private IaPlayerPaperGame? _iaPlayerTwo { get; set; }
    private IaPlayerPaperGame? _iaPlayerOne { get; set; }
    private readonly PaperGame _game;
}
/// <summary>
/// Modelos de ias para el juego PaperGame
/// </summary>
public record class IaPlayerPaperGame()
{
    /// <summary>
    /// Generador de jugadas
    /// </summary>
    /// <returns>
    /// Obten la jugada correspondiente de manera aleatoria entre (P,R,S) 
    /// </returns>
    public string Tick()
    {
        var JugadasAleatorias = new Random();

        int result = JugadasAleatorias.Next(0, 15);

        if (result >= 0 && result <= 5) return "P";
        if (result > 5 && result <= 10) return "R";
        else return "S";
    }
};