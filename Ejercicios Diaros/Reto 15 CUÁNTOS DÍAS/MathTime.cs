/*
 * Crea una función que calcule y retorne cuántos días hay entre dos cadenas
 * de texto que representen fechas.
 * - Una cadena de texto que representa una fecha tiene el formato "dd/MM/yyyy".
 * - La función recibirá dos String y retornará un Int.
 * - La diferencia en días será absoluta (no importa el orden de las fechas).
 * - Si una de las dos cadenas de texto no representa una fecha correcta se
 *   lanzará una excepción.
 */
using System.Globalization;

namespace Ejercicios_Diaros.Reto_15_CUÁNTOS_DÍAS;

public class MathTime
{
	/// <summary>
	/// ingresa 2 cadenas de texto que representen los dias des una fecha determinada a otra
	/// </summary>
	/// <param name="Date1"></param>
	/// <param name="Date2"></param>
	/// <returns>
	/// optienes el total de dias que hay entre una fecha a la otra 
	/// </returns>
	/// <exception cref="ArgumentException"></exception>
    public static int GetDays(ReadOnlySpan<char> Date1, ReadOnlySpan<char> Date2)
    {
		try
		{
			// obtenemos la fecha mediante la resta de la fecha proxima menos la actual tomando en cuenta la cultura donde nos encontramos
			var fecha = (DateTime.ParseExact(Date2, "d", CultureInfo.CurrentCulture) - (DateTime.ParseExact(Date1, "d", CultureInfo.CurrentCulture)));
			//regresamos la fecha
			return fecha.Days;
		}
		catch (Exception)
		{
			throw new ArgumentException("Cadena no valida");
		}
    }
}