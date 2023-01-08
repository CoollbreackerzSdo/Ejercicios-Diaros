namespace Ejercicios_Diaros.Reto_8_DECIMAL_A_BINARIO;
/*
 * Crea un programa se encargue de transformar un número
 * decimal a binario sin utilizar funciones propias del lenguaje que lo hagan directamente.
 */
public static class ConvertBinario
{
    public static string ToBinarioString(this int num)
    {
        List<char> elemts = new();
        int value = num;
        while (true)
        {
            if (value % 2 == 0)
                elemts.Add('0');
            if (!(value % 2 == 0))
                elemts.Add('1');
            value /= 2;
            if (value is 0)
                break;
        }
        return new(elemts.ToArray().Reverse().ToArray());
    }
    
    public static IEnumerable<char> ConvertCharIEnumerable(string text)
    {
        foreach (char c in text)
        {
            yield return c;
        }
    }
    public static IEnumerable<char> InvertCharIEnumerable(IEnumerable<char> chars)
    {
        var caracteres = chars.ToArray();

        for (int i = caracteres.Length - 1; i >= 0; i--)
        {
            yield return caracteres[i];
        }
    }
}
