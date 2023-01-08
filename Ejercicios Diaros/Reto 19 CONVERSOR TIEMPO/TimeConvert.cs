namespace Ejercicios_Diaros.Reto_19_CONVERSOR_TIEMPO;
/*
 * Crea una función que reciba días, horas, minutos y segundos (como enteros)
 * y retorne su resultado en milisegundos.
 */
public class TimeConvert
{
    public double GetMilisegundos(Tiempo tiempo1)
    {
        var host1 = new TimeSpan(tiempo1.dias, tiempo1.horas, tiempo1.minutos, tiempo1.segundos);

        return host1.TotalMilliseconds;
    }
}
public record class Tiempo(int dias,int horas,int minutos,int segundos);
