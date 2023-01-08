/*
 * Escribe un programa que imprima los 50 primeros números de la sucesión
 * de Fibonacci empezando en 0.
 * - La serie Fibonacci se compone por una sucesión de números en
 *   la que el siguiente siempre es la suma de los dos anteriores.
 *   0, 1, 1, 2, 3, 5, 8, 13...
 */
using System.Numerics;

namespace Ejercicios_Diaros.Reto_2_LA_SUCESIÓN_DE_FIBONACCI;

public static class Fibonachi
{
    public static int FibonachiSum(int exponent)
    {
        int v1 = 0;
        int v2 = 1;

        for (int i = 0; i < exponent; i++)
        {
            int temp = v1;

            v1 = v2;

            v2 = temp + v1;
        }
        return v2;
    }
}
