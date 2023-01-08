/*
 * Dado un listado de números, encuentra el SEGUNDO más grande.
 */
using System.Numerics;

namespace Ejercicios_Diaros.Reto_32_EL_SEGUNDO
{
    public static class Bucador
    {
        /// <summary>
        /// Busca el segundo numero maximo dentro ddel listado de numeros , si el listado es nulo retornara 0 de lo contrario el numero 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static T MaxDos<T>(this IEnumerable<T> values)
            where T : INumber<T>
        {
            if (values is null) return T.Zero;

            var collecion = values.OrderDescending().ToList();

            return collecion.Count <= 1 ? collecion[0] : collecion[1];
        }
    }
}