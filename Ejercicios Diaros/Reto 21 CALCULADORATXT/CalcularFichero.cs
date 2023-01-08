using System.Globalization;
using System.Numerics;
using System.Text;

namespace Ejercicios_Diaros.Reto_21_CALCULADORATXT;
/*
 * Lee el fichero "Challenge21.txt" incluido en el proyecto, calcula su
 * resultado e imprímelo.
 * - El .txt se corresponde con las entradas de una calculadora.
 * - Cada línea tendrá un número o una operación representada por un
 *   símbolo (alternando ambos).
 * - Soporta números enteros y decimales.
 * - Soporta las operaciones suma "+", resta "-", multiplicación "*"
 *   y división "/".
 * - El resultado se muestra al finalizar la lectura de la última
 *   línea (si el .txt es correcto).
 * - Si el formato del .txt no es correcto, se indicará que no se han
 *   podido resolver las operaciones.
 */
public class CalcularFichero
{
    /// <summary>
    /// Obten el resultado de la operacion
    /// </summary>
    /// <returns></returns>
    public async Task<T> GetResul<T>()
        where T : INumber<T>
    {
        //si ocurre algo solo lanzamos una exepcion
        try
        {
            //optenemos la collecion del fichero
            var collecion = await GetFicheroAsync();
            //convertimos el primer elemento en un numero si no lo es lanzara una exepciom
            T result = ConvertToNumber<T>(collecion[0]);

            for (int i = 0; i < collecion.Length - 1; i++)
            {
                //miramos por una regla simple si (20+21) significa que los signos estan bien pero si (++32) significa que no y lanzamos una exepcion 
                if (collecion[i] is "*" or "-" or "+" or "/" && collecion[i + 1] is "*" or "-" or "+" or "/") throw new ArgumentException();
                //un sw para hacer las operaciones de manera acumulativa
                //solo miramos los numeros de par en par ya que en la posicion impar se encuentra en signo
                switch (collecion[i])
                {
                    case "*":
                        result *= ConvertToNumber<T>(collecion[i + 1]);
                        break;
                    case "/":
                        result /= ConvertToNumber<T>(collecion[i + 1]);
                        break;
                    case "-":
                        result -= ConvertToNumber<T>(collecion[i + 1]);
                        break;
                    case "+":
                        result += ConvertToNumber<T>(collecion[i + 1]);
                        break;
                }
            }
            return result;
        }
        catch (ArgumentException)
        {
            Console.WriteLine("No se a podido resolver las operaciones");
            return T.Zero;
        }
        catch (Exception)
        {
            Console.WriteLine("Error al cargar el archivo");
            return T.Zero;
        }
    }
    /// <summary>
    /// Convierte al numero especificado
    /// </summary>
    /// <typeparam name="T">
    /// el tipo de objeto 
    /// </typeparam>
    /// <param name="text">
    /// el numero para ser convertido
    /// </param>
    /// <returns>
    /// retornamos el numero de generico en base a que implemente INumber
    /// </returns>
    private T ConvertToNumber<T>(string text)
        where T : INumber<T>
    {
        return T.Parse(text, NumberFormatInfo.CurrentInfo);
    }
    /// <summary>
    /// Obtenemos el fichero
    /// </summary>
    /// <returns>
    /// retornamos el fichero en una lista de strings
    /// </returns>
    private async Task<string[]?> GetFicheroAsync()
    {
        try
        {
            //buscamos el fichero con la ruta del mismo
            var archivo = File.ReadLinesAsync(Fichero);

            // un delay gratuito
            await Task.Delay(12);

            //retornamos el fichero en una lista
            return archivo.ToBlockingEnumerable().ToArray();
        }
        catch (Exception)
        {
            return null;
        }
    }
    public required string Fichero { internal get; set; }
}
