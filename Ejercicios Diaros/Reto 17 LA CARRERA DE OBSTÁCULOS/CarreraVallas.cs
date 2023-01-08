using BenchmarkDotNet.Attributes;

namespace Ejercicios_Diaros.Reto_17_LA_CARRERA_DE_OBSTÁCULOS;
/*
 * Crea una función que evalúe si un/a atleta ha superado correctamente una
 * carrera de obstáculos.
 * - La función recibirá dos parámetros:
 *      - Un array que sólo puede contener String con las palabras
 *        "run" o "jump"
 *      - Un String que represente la pista y sólo puede contener "_" (suelo)
 *        o "|" (valla)
 * - La función imprimirá cómo ha finalizado la carrera:
 *      - Si el/a atleta hace "run" en "_" (suelo) y "jump" en "|" (valla)
 *        será correcto y no variará el símbolo de esa parte de la pista.
 *      - Si hace "jump" en "_" (suelo), se variará la pista por "x".
 *      - Si hace "run" en "|" (valla), se variará la pista por "/".
 * - La función retornará un Boolean que indique si ha superado la carrera.
 * Para ello tiene que realizar la opción correcta en cada tramo de la pista.
 */
public class CarreraVallas
{
    public bool Run(ReadOnlySpan<string> Jugador, ReadOnlySpan<char> Pista)
    {
        if (Jugador.Length != Pista.Length) return false;

        for (int i = 0; i < Pista.Length; i++)
        {
            if (Jugador[i] is "jump" && Pista[i] is '_')
            {
                Console.Write('x');
                count++;
            }
            if (Jugador[i] is "run" && Pista[i] is '|')
            {
                Console.Write('/');
                count++;
            }
            else
                Console.Write(Pista[i]);
        }
        return count is 0;
    }
    public int count { get; set; } = 0;
}
