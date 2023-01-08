using System.Numerics;

namespace Ejercicios_Diaros.Reto_27_VECTORES_ORTOGONALES;
/*
 * Crea un programa que determine si dos vectores son ortogonales.
 * - Los dos array deben tener la misma longitud.
 * - Cada vector se podría representar como un array. Ejemplo: [1, -2]
 */
public sealed class OrtoVector<TEntity>
    where TEntity : INumber<TEntity>
{
    //Calculamos si son ortogonales sin tomar en cuenta (k) o (W) en este procedimiento
    public bool VectorsNormal(ReadOnlySpan<TEntity> colleccion1, ReadOnlySpan<TEntity> colleccion2)
    {
        //verificamos si los vectores son del mismo tamaño si no damos una exepcion
        if (colleccion1.Length != colleccion2.Length) throw new ArgumentOutOfRangeException();

        var result = TEntity.Zero;

        int count = colleccion1.Length;

        for (int i = 0; i < count; i++)
        {
            result += colleccion1[i] * colleccion2[i];
        }
        //vemos si el resulto es 0 de lo contrario decimos que no es (ortogonal) o (normal)
        return result == TEntity.Zero;
    }
}