using System.Text;

namespace Ejercicios_Diaros.Reto_12_ES_UN_PALÍNDROMO;
/*
 * Escribe una función que reciba un texto y retorne verdadero o
 * falso (Boolean) según sean o no palíndromos.
 * Un Palíndromo es una palabra o expresión que es igual si se lee
 * de izquierda a derecha que de derecha a izquierda.
 * NO se tienen en cuenta los espacios, signos de puntuación y tildes.
 * Ejemplo: Ana lleva al oso la avellana.
 */
public static class Palíndromos
{
    public static bool IsPalindromo(this string textConten)
    {
        var texFinal1 = DeleteSpace(textConten);

        var texFinal2 = InvertString(texFinal1);

        return texFinal1.Equals(texFinal2,StringComparison.OrdinalIgnoreCase);
    }
    public static string DeleteSpace(string obj)
    {
        var constructor = "";

        for (int i = 0; i < obj.Length; i++)
            if (obj[i] is not ' ')
                constructor += obj[i];

        return constructor;
    }
    public static string InvertString(string obj)
    {
        var constructor = "";

        for (int i = obj.Length - 1; i >= 0; i--)
            if (obj[i] is not ' ')
                constructor += obj[i];

        return constructor;
    }
}
