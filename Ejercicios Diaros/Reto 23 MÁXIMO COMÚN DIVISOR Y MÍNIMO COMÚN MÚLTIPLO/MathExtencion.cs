/*
 * Crea dos funciones, una que calcule el máximo común divisor (MCD) y otra
 * que calcule el mínimo común múltiplo (mcm) de dos números enteros.
 * - No se pueden utilizar operaciones del lenguaje que 
 *   lo resuelvan directamente.
 */
namespace Ejercicios_Diaros.Reto_23_MÁXIMO_COMÚN_DIVISOR_Y_MÍNIMO_COMÚN_MÚLTIPLO;

public static class MathExtencion
{
    public static int Mcd(this int num1, int num2)
    {
        while (num2 is not 0)
        {
            int aux = num2;

            num2 = num1 % num2;

            num1 = aux;
        }
        return num1;
    }
    public static int Mcm(this int num1, int num2) => (num1 * num2) / Mcd(num1, num2);
}
