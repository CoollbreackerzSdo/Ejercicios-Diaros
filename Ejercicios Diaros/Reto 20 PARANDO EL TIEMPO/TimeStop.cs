/*
 * Crea una función que sume 2 números y retorne su resultado pasados
 * unos segundos.
 * - Recibirá por parámetros los 2 números a sumar y los segundos que
 *   debe tardar en finalizar su ejecución.
 * - Si el lenguaje lo soporta, deberá retornar el resultado de forma
 *   asíncrona, es decir, sin detener la ejecución del programa principal.
 *   Se podría ejecutar varias veces al mismo tiempo.
 */
using System.Numerics;

namespace Ejercicios_Diaros.Reto_20_PARANDO_EL_TIEMPO
{
    public class TimeStop
    {
        public async Task<T> SumaLop<T>(T num1,T num2)
            where T : INumber<T>
        {
            await Task.Delay(2000);
            return num1 + num2; 
        }
    }
}
