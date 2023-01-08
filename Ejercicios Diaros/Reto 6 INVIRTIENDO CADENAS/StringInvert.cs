using System.Text;

namespace Ejercicios_Diaros.Reto_6_INVIRTIENDO_CADENAS;
/*
 * Crea un programa que invierta el orden de una cadena de texto
 * sin usar funciones propias del lenguaje que lo hagan de forma automática.
 * - Si le pasamos "Hola mundo" nos retornaría "odnum aloH"
 */
public static class StringInvert
{
    public static string Invert(string text)
    {
        string Alt = "";
        var elemts = InvertStrinIEnum(text).ToArray();
        foreach (var item in elemts)
        {
            Alt += item;
        }
        return Alt;
    }
    public static char[] InvertString(string text)
    {
        var elemnts = new char[text.Length];
        int i = text.Length - 1;
        foreach (var item in text)
        {
            elemnts[i] = item;
            i--;
        }
        return elemnts;
    }
    public static IEnumerable<char> InvertStrinIEnum(string text)
    {
        int iterador = text.Length - 1;
        for (int i = 0; i < text.Length; i++)
        {
            yield return text[iterador];
            iterador --;
        }
    }
}
