namespace Ejercicios_Diaros.Reto_4_ÁREA_DE_UN_POLÍGONO;
/*
 * Crea una única función (importante que sólo sea una) que sea capaz
 * de calcular y retornar el área de un polígono.
 * - La función recibirá por parámetro sólo UN polígono a la vez.
 * - Los polígonos soportados serán Triángulo, Cuadrado y Rectángulo.
 * - Imprime el cálculo del área de un polígono de cada tipo.
 */
public class PoligonProvider
{
    public required string NamePoligon { get; set; }

    public double CalculateArea(double apotema, IEnumerable<double> numeros)
    {
        double result = 0;

        foreach (var item in numeros)
        {
            result += item;
        }

        return (result*apotema)/2;
    }
}