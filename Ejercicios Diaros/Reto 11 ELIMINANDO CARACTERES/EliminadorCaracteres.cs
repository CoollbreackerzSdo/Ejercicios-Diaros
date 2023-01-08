using System.Linq;
using Ejercicios_Diaros.Reto_7_CONTANDO_PALABRAS;
namespace Ejercicios_Diaros.Reto_11_ELIMINANDO_CARACTERES;
/*
 * Crea una función que reciba dos cadenas como parámetro (str1, str2)
 * e imprima otras dos cadenas como salida (out1, out2).
 * - out1 contendrá todos los caracteres presentes en la str1 pero NO
 *   estén presentes en str2.
 * - out2 contendrá todos los caracteres presentes en la str2 pero NO
 *   estén presentes en str1.
 */
public static class EliminadorCaracteres
{
    public static IEnumerable<string?> GetEliminacionDiferencial(this string obj,string obj2)
    {
        var ast = obj;

        obj = new string (CountStrings.RemoverCaracteresEnTextos(obj,obj2));
        obj2 = new string (CountStrings.RemoverCaracteresEnTextos(obj2,ast));


        return new string?[]
        {
            obj,obj2
        };
    }
}
