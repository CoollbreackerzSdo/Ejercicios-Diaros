using System.Numerics;

namespace Ejercicios_Diaros.Reto_13_FACTORIAL_RECURSIVO;
/*
 * Escribe una función que calcule si un número dado es un número de Armstrong
 * (o también llamado narcisista).
 * Si no conoces qué es un número de Armstrong, debes buscar información 
 * al respecto.
 */
public class RecursiveFactorial
{
    public T FactorySearch<T>(T Factory)
        where T : INumber<T>
    {
        T result = T.One;

        for (T i = T.One; i <= Factory; i++)
        {
            result *= i;
        }

        return result;
    }
    public T FactorySearchRecursive<T>(T Factory)
        where T : INumber<T>
    {
        if (Factory == T.Zero)
            return T.One;

        return Factory * FactorySearchRecursive(Factory - T.One);
    }
}
