/*
 * Escribe una función que calcule si un número dado es un número de Armstrong
 * (o también llamado narcisista).
 * Si no conoces qué es un número de Armstrong, debes buscar información 
 * al respecto.
 */
using System.Linq;

namespace Ejercicios_Diaros.Reto_14_ES_UN_NUMERO_DE_ARMSTRONG;

public static class AsTrom
{
    public static bool IsNumbreAsTrom(this int number)
    {
        var elements = number.ToString().ToCharArray().Select(Convert.ToInt32).ToList();

        var result = elements.Sum();

        return number.Equals(result);
    }
}