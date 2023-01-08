using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using System.ComponentModel;

namespace Ejercicios_Diaros.Reto_16_EN_MAYÚSCULA;
/*
 * Crea una función que reciba un String de cualquier tipo y se encargue de
 * poner en mayúscula la primera letra de cada palabra.
 * - No se pueden utilizar operaciones del lenguaje que
 *   lo resuelvan directamente.
 */
public class UpOneText
{
    public UpOneText()
    {
        _caracteres = new Dictionary<char, char>()
        {
            {'a','A'},
            {'b','B'},
            {'c','C'},
            {'d','D'},
            {'e','E'},
            {'f','F'},
            {'g','G'},
            {'h','H'},
            {'i','I'},
            {'j','J'},
            {'k','k'},
            {'l','L'},
            {'n','N'},
            {'m','M'},
            {'o','O'},
            {'p','P'},
            {'q','Q'},
            {'s','S'},
            {'r','R'},
            {'t','T'},
            {'u','U'},
            {'v','V'},
            {'w','W'},
            {'x','X'},
            {'y','y'},
            {'z','Z'}
        };
    }
    /// <summary>
    /// ingresa un texto retorna el texto con su inicial en mayuscula
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public Span<char> ToUpOneis(Span<char> text)
    {
        try
        {
            text[0] = _caracteres[text[0]];
            return text;
        }
        catch (Exception)
        {
            return text;
        }
    }
    private readonly IDictionary<char, char> _caracteres;
}
