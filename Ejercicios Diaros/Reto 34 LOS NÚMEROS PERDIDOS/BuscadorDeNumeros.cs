namespace Ejercicios_Diaros.Reto_34_LOS_NÚMEROS_PERDIDOS;
/*
 * Enunciado: Dado un array de enteros ordenado y sin repetidos, 
 * crea una función que calcule y retorne todos los que faltan entre
 * el mayor y el menor.
 * - Lanza un error si el array de entrada no es correcto.
 */
public class BuscadorDeNumeros
{
    public IEnumerable<int> NoEnumerados(IEnumerable<int> collecion)
    {
        if (collecion is null) throw new ArgumentNullException();

        else if(collecion.Count() is 0) throw new IndexOutOfRangeException();

        else if (!collecion.SequenceEqual(collecion.Order())) throw new ArgumentException();

        else if (collecion.GroupBy(t => t).Any(x => x.Count() > 1)) throw new ArgumentOutOfRangeException();

        var numeroMaximo = collecion.Max();

        var elementosFaltantes = new List<int>();

        for (int i = 0; i < numeroMaximo; i++)
        {
            if (!collecion.Any(t => t == i)) elementosFaltantes.Add(i);
        }

        return elementosFaltantes;
    }
}