namespace Ejercicios_Diaros.Reto_10_EXPRESIONES_EQUILIBRADAS;
/*
 * Crea un programa que comprueba si los paréntesis, llaves y corchetes
 * de una expresión están equilibrados.
 * - Equilibrado significa que estos delimitadores se abren y cieran
 *   en orden y de forma correcta.
 * - Paréntesis, llaves y corchetes son igual de prioritarios.
 *   No hay uno más importante que otro.
 * - Expresión balanceada: { [ a * ( c + d ) ] - 5 }
 * - Expresión no balanceada: { a * ( c + d ) ] - 5 }
 */
public static class EquilibradorCorchetes
{
    public static bool EquilibrioDeCorchetes(this string text)
    {
        var pila = new Stack<char>();
        //guardamos los caracteres a especiales y eliminando todo el texto del espacio solo para ver los caracteres
        var caracteres = ExtraerCaracteres(text, new char[]{
            '(','[','{','}',']',')'
        }).ToArray();

        var residuo = new char();

        int i = 0;

        while (caracteres[i] is not '\0')
        {
            if (caracteres[i] is '(' || caracteres[i] is '[' || caracteres[i] is '{')
                pila.Push(caracteres[i]);
            if(caracteres[i] is ')' || caracteres[i] is ']' || caracteres[i] is '}')
            {
                 residuo = pila.Pop();
                if (caracteres[i] is ')' && residuo is not '(') return false;
                if (caracteres[i] is ']' && residuo is not '[') return false;
                if (caracteres[i] is '}' && residuo is not '{') return false;
            }

            if (i == caracteres.Length - 1) break;

            i++;
        }
        if(pila.Count is not 0)return false;

        return true;
    }
    /// <summary>
    /// Extractor de caracteres segun los ingresados
    /// </summary>
    /// <param name="text"></param>
    /// <param name="caracteres"></param>
    /// <returns></returns>
    public static IEnumerable<char> ExtraerCaracteres(string text, IEnumerable<char> caracteres)
    {
        //buscamos si el texto en el que estamos pertenece a los caracteres dados
        var EsCaracter = (char caracter, IEnumerable<char> chars) =>
        {
            foreach (var item in chars)
            {
                if (caracter == item)
                    return true;
            }
            return false;
        };
        foreach (var item in text)
        {
            if (EsCaracter(item, caracteres))
                yield return item;
        }
    }
}