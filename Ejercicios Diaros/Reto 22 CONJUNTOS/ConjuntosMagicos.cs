using System.Collections.ObjectModel;

namespace Ejercicios_Diaros.Reto_22_CONJUNTOS;
/*
 * Crea una función que reciba dos array, un booleano y retorne un array.
 * - Si el booleano es verdadero buscará y retornará los elementos comunes
 *   de los dos array.
 * - Si el booleano es falso buscará y retornará los elementos no comunes
 *   de los dos array.
 * - No se pueden utilizar operaciones del lenguaje que
 *   lo resuelvan directamente.
 */
public class ConjuntosMagicos
{
    public IEnumerable<T> SearchNoElements<T>(ReadOnlySpan<T> colleccion1, ReadOnlySpan<T> colleccion2, bool operador)
        where T : class
    {
        //Lista dondes estaran lso valores
        List<T> values = new List<T>();

        //si es true significa que la coleccion 1 es prioridad si no es la 2
        bool orientacion = colleccion1.Length > colleccion2.Length ? true : false;

        if (operador is true)
        {
            if (orientacion is true)
            {
                for (int i = 0; i < colleccion2.Length; i++)
                {
                    if (GetValueTrue(colleccion2[i], colleccion1) && !GetValueTrue(colleccion2[i], values.AsReadOnly()))
                        values.Add(colleccion2[i]);
                }
            }
            else
            {
                for (int i = 0; i < colleccion1.Length; i++)
                {
                    if (GetValueTrue(colleccion1[i], colleccion2) && !GetValueTrue(colleccion1[i], values.AsReadOnly()))
                        values.Add(colleccion1[i]);
                }
            }
        }
        else
        {
            if (orientacion is true)
            {
                for (int i = 0; i < colleccion1.Length; i++)
                {
                    if (!GetValueTrue(colleccion1[i], colleccion2) && !GetValueTrue(colleccion1[i], values.AsReadOnly()))
                        values.Add(colleccion1[i]);

                    if(i < colleccion2.Length)
                    {
                        if (!GetValueTrue(colleccion2[i], colleccion1) && !GetValueTrue(colleccion2[i], values.AsReadOnly()))
                        {
                            values.Add(colleccion2[i]);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < colleccion2.Length; i++)
                {
                    if (!GetValueTrue(colleccion2[i], colleccion1) && !GetValueTrue(colleccion2[i], values.AsReadOnly()))
                        values.Add(colleccion2[i]);
                    if (i < colleccion1.Length)
                    {
                        if (!GetValueTrue(colleccion1[i], colleccion2) && !GetValueTrue(colleccion1[i], values.AsReadOnly()))
                        {
                            values.Add(colleccion1[i]);
                        }
                    }
                }
            }
        }


        return values;
    }
    private bool GetValueTrue<T>(T obj, ReadOnlySpan<T> colleccio)
        where T : class
    {
        //Vemos si el valor existe en la el array
        for (int i = 0; i < colleccio.Length; i++)
        {
            if (colleccio[i].Equals(obj)) return true;
        }
        return false;
    }
    private bool GetValueTrue<T>(T obj, ReadOnlyCollection<T> colleccio)
        where T : class
    {
        //Vemos si el valor existe en la colleccion
        for (int i = 0; i < colleccio.Count; i++)
        {
            if (colleccio[i].Equals(obj)) return true;
        }
        return false;
    }
}
