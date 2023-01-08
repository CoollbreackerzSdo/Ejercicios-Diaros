/*
 * Crea un programa que dibuje un cuadrado o un triángulo con asteriscos "*".
 * - Indicaremos el tamaño del lado y si la figura a dibujar es una u otra.
 * - EXTRA: ¿Eres capaz de dibujar más figuras?
 */
using System.Text;

namespace Ejercicios_Diaros.Reto_26_CUADRADO_Y_TRIÁNGULO_2D;

internal sealed class Figure2DConsole
{
    public string ModelConsole(Figura figura, TipoFigura tipo) => tipo switch
    {
        TipoFigura.Trianguro => Generador().MapTriangulo(figura),
        TipoFigura.Rectangulo => Generador().MapRectangulo(figura),
        _ => string.Empty
    };
    //tupla de modelos de objetos
    private (Func<Figura,string> MapTriangulo,Func<Figura,string> MapRectangulo) Generador()
    {
        var GeneradorTrinagulos = (Figura figura) =>
        {
            var figuraContext = new StringBuilder();

            var count = 1;

            for (int i = 0; i < figura.Largo; i++)
            {
                for (int y = 0; y < count; y++)
                {
                    figuraContext.Append('*');
                }
                count++;
                figuraContext.AppendLine();
            }

            return figuraContext.ToString();
        };
        var GeneradorCuadrados = (Figura figura) =>
        {
            var figuraContext = new StringBuilder();

            for (int i = 0; i < figura.Largo; i++)
            {
                for (int y = 0; y < figura.Ancho; y++)
                {
                    figuraContext.Append('*');
                }
                figuraContext.AppendLine();
            }

            return figuraContext.ToString();
        };

        return (GeneradorTrinagulos, GeneradorCuadrados);
    }
    public enum TipoFigura
    {
        Rectangulo,
        Trianguro
    }
}
internal record class Figura(int Ancho = 0, int Largo = 0);