namespace Ejercicios_Diaros.Reto_7_CONTANDO_PALABRAS;
/*
 * Crea un programa que cuente cuantas veces se repite cada palabra
 * y que muestre el recuento final de todas ellas.
 * - Los signos de puntuación no forman parte de la palabra.
 * - Una palabra es la misma aunque aparezca en mayúsculas y minúsculas.
 * - No se pueden utilizar funciones propias del lenguaje que
 *   lo resuelvan automáticamente.
 */
public static class CountStrings
{
    public static IDictionary<string, int> GetListFinalBLock(this string texto, IEnumerable<char> caracteresAEliminar)
    {
        var element = RemoverCaracteresEnTextos(texto, caracteresAEliminar);

        return ObtenerListadoDePalabrasDiferentes(DividirStringSpace(element));
    }
    public static string RemoverCaracteresEnTextos(string Texto, IEnumerable<char> Caracteres)
    {
        var text = Texto.ToCharArray();

        var Remplace = (char caracter, IEnumerable<char> chars1) =>
        {
            foreach (var item in chars1)
            {
                if (caracter == item)
                    return true;
            }
            return false;
        };

        for (int i = 0; i < Texto.Length; i++)
        {
            if (Remplace(Texto[i], Caracteres))
                text[i] = ' ';
        }

        return new(text);
    }
    public static List<string> DividirStringSpace(string text)
    {
        var elemts = new List<string>();
        string[] texts = text.Split();

        var eleminar = (string elment) =>
        {
            List<char> chars = new();

            foreach (var item in elment)
            {
                if (item != ' ')
                    chars.Add(item);
            }
            return new string(chars.ToArray());
        };

        for (int i = 0; i < texts.Length; i++)
        {
            if (!texts[i].StartsWith(' '))
                elemts.Add(eleminar(texts[i]));
        }

        return elemts;
    }
    private static IDictionary<string, int> ObtenerListadoDePalabrasDiferentes(IEnumerable<string> elements)
    {
        Dictionary<string, int> stringDistint = new Dictionary<string, int>();

        var CantIteraciones = (string text, IEnumerable<string> strings) =>
        {
            int cont = 0;
            foreach (var item in strings)
            {
                if (text.Equals(item, StringComparison.OrdinalIgnoreCase))
                    cont += 1;
            }
            return cont;
        };

        var BuscarSiExiste = (string text, IDictionary<string, int> keyValuePairs) =>
        {
            foreach (var item in keyValuePairs)
            {
                if (string.Equals(text,item.Key,StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        };

        foreach (string element in elements)
        {
            if (!BuscarSiExiste(element,stringDistint) && element is not "")
                stringDistint.Add(element, CantIteraciones(element, elements));
        }

        return stringDistint;
    }
}