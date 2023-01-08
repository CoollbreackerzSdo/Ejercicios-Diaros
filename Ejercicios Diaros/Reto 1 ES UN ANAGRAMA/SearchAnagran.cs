/*
 * Escribe una función que reciba dos palabras (String) y retorne
 * verdadero o falso (Bool) según sean o no anagramas.
 * - Un Anagrama consiste en formar una palabra reordenando TODAS
 *   las letras de otra palabra inicial.
 * - NO hace falta comprobar que ambas palabras existan.
 * - Dos palabras exactamente iguales no son anagrama.
 */
using System.Globalization;
using System.Linq;

namespace Ejercicios_Diaros.Reto_1_ES_UN_ANAGRAMA;

public static class SearchAnagran
{
    public static bool IsAnagran(this string conten,string element)
    {
        if (conten.Equals(element))
            return false;
        //convertimos todo el texto a minusculas luego lo ordenamos y despues convertimos a string
        string text1 = new(conten.ToLower().Order().ToString());
        string text2 = new(element.ToLower().Order().ToString());
        //si sus valores son iguales si es un anagrama de lo contrario no es
        return text1.Equals(text2);
    }
}
