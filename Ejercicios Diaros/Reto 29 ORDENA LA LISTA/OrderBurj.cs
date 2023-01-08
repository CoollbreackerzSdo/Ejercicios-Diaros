using System.Numerics;

namespace Ejercicios_Diaros.Reto_29_ORDENA_LA_LISTA;

public static class OrderBurj
{
    public static void OrderBurBuja<T>(this T[] numeros)
        where T : INumber<T>
    {
        var leng = numeros.Count();

        bool vandera = true; 

        for (int i = 0; i < leng && vandera; i++)
        {
            vandera = false;
            for (int t = 0; t < leng - i - 1; t++)
            {
                vandera = true;
                if (numeros[t] > numeros[t + i])
                {
                    T aux = numeros[t];
                    numeros[t] = numeros[t + 1];
                    numeros[t + 1] = aux;
                }
            }
        }
    }
}
