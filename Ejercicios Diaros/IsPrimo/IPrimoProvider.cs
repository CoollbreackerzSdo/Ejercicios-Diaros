using System.Numerics;

namespace Ejercicios_Diaros.IsPrimo;

public interface IPrimoProvider
{
    IEnumerable<string> GetPrimos(int num);
}
public class PrimoProvider : IPrimoProvider
{
    public IEnumerable<string> GetPrimos(int num)
    {
        for(int i = 1; i < num; i++)
        {
            if(i % 2 == 0)
            yield return $"{i}";
        }
    }
}
