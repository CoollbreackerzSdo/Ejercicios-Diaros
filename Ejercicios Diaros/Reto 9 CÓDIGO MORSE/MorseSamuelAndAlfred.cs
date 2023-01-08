namespace Ejercicios_Diaros.Reto_9_CÓDIGO_MORSE;
/*
 * 
 * Nivel Medio
 * 
 * Crea un programa que sea capaz de transformar texto natural a código
 * morse y viceversa.
 * - Debe detectar automáticamente de qué tipo se trata y realizar
 *   la conversión.
 * - En morse se soporta raya "—", punto ".", un espacio " " entre letras
 *   o símbolos y dos espacios entre palabras "  ".
 * - El alfabeto morse soportado será el mostrado en
 *   https://es.wikipedia.org/wiki/Código_morse.
 */
public class MorseSamuelAndAlfred : IMorseSourceProvider
{
    public MorseSamuelAndAlfred()
    {
        _caracter = new Dictionary<char, string>()
        {
            { 'a',"· —" },
            {'b',"— · · ·" },
            {'c',"— · — ·" },
            { 'd',"— · ·" },
            { 'e', "·"},
            { 'f',"· · — ·"},
            {'g', "— — ·" },
            {'h',"· · · ·" },
            {'i' , "· ·" },
            {'j', "· — — —" },
            { 'k', "— · —"},
            {'l', "· — · ·" },
            {  'm' , "— —"},
            {'n', "— ·" },
            {'ñ', "— — · — —" },
            { 'o',"— — —"},
            { 'p', "· — — ·"},
            {'q',"— — · —" },
            { 'r',"· — ·" },
            {'s',"· · ·" },
            {'t',"—" },
            {'u',"· · —" },
            {'v',"· · · —" },
            {'w',"· — —" },
            {'x',"— · · —" },
            {'y',"— · — —" },
            {'z',"— — · ·" },
            {'0',"— — — — —" },
            {'1',"· — — — —" },
            {'2',"· · — — —" },
            {'3',"· · · — —" },
            {'4',"· · · · —" },
            {'5',"· · · · ·" },
            {'6',"— · · · ·" },
            {'7',"— — · · ·" },
            {'8',"— — — · ·" },
            {'9',"— — — — ·" },
            {'.',"· — · — · —" },
            {',',"— — · · — —" },
            {'?',"· · — — · ·" },
            {'"',"· — · · — ·" },
            {'/',"— · · — ·" }
        };
    }
    public string GetMorceCode1(char Caracter)
    {
        foreach (var item in _caracter)
        {
            if (Caracter == item.Key)
                return item.Value;
        }
        return "No valido";
    }

    private readonly IDictionary<char, string> _caracter;
}

public interface IMorseSourceProvider
{
    abstract string GetMorceCode1(char Caracter);
}
