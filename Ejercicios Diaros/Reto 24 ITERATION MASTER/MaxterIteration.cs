namespace Ejercicios_Diaros.Reto_24_ITERATION_MASTER;
/*
 * Quiero contar del 1 al 100 de uno en uno (imprimiendo cada uno).
 * ¿De cuántas maneras eres capaz de hacerlo?
 * Crea el código para cada una de ellas.
 */
public static class MaxterIteration
{
    public static void Iteraciones()
    {
        //1
        int count = 1;
        while (count <= 100)
        {
            Console.WriteLine($"**{count}**");
            count++;
        }
        count = 1;
        //2
        for (int i = 1; i <= 100; i++)
        {
            Console.WriteLine($"**{i}**");
        }
        //3
        do
        {
            Console.WriteLine($"**{count}**");
            count++;
        } while (count <= 100);
        
        var Iteracion = (int i, Action<int> action) => action(i);
        count = 1;
        //4
        Iteracion(count, (count) => {
            do
            {
                Console.WriteLine($"**{count}**");
                count++;
            } while (count <= 100);
        });
        //no se mas 
    }
}