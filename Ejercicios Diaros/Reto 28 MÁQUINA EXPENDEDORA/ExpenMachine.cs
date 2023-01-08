using System.CodeDom;

namespace Ejercicios_Diaros.Reto_28_MÁQUINA_EXPENDEDORA;
/*
 * Simula el funcionamiento de una máquina expendedora creando una operación
 * que reciba dinero (array de monedas) y un número que indique la selección
 * del producto.
 * - El programa retornará el nombre del producto y un array con el dinero
 *   de vuelta (con el menor número de monedas).
 * - Si el dinero es insuficiente o el número de producto no existe,
 *   deberá indicarse con un mensaje y retornar todas las monedas.
 * - Si no hay dinero de vuelta, el array se retornará vacío.
 * - Para que resulte más simple, trabajaremos en céntimos con monedas
 *   de 5, 10, 50, 100 y 200.
 * - Debemos controlar que las monedas enviadas estén dentro de las soportadas.
 */

//mencionar que en este ejercicio no se tomara en cuenta es espacio lleno de monedas para el cambio que se encuentra en las maquinas
//y el decremento de los productos al comprar
//solo parte de su funcionamiento
public sealed class ConsoleExpenMachine
{
    public ConsoleExpenMachine(Producto[] productos) => _expenMachine = new(productos);
     

    public ExpenMachineDevuelta Run(in IEnumerable<int> monedas)
    {
        var productos = _expenMachine.GetProductosStrings();

        var codigo = "";
        Console.WriteLine("""
                        Bienvenido

                Que quisiras pedir hoy?
                """);
        foreach (var item in productos)
        {
            Console.WriteLine(item);
        }
        do
        {
            Console.Write("Ingresa un codigo:");
            codigo = Console.ReadLine();
        } while (!_expenMachine.ExisteElProducto(codigo));

        if (!_expenMachine.HayStockDelProducto(codigo))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return new("No hay Stock", monedas);
        }
        if (!_expenMachine.SonMonedasSoportadas(monedas))
        {
            return new("Monedas no soportadas", monedas);
        }
        return _expenMachine.Devuelta(new(codigo, monedas));
    }

    private readonly ExpenMachine _expenMachine;
}
public sealed class ExpenMachine
{
    public ExpenMachine(params Producto[] productos)
    {
        _monedasSoportadas = new[]
        {
            5 , 10, 50, 100,200
        };
        _productos = productos;
    }

    public IEnumerable<string> GetProductosStrings()
    {
        foreach (var item in _productos)
        {
            yield return $"Nombre:{item.Nombre}, Codido :{item.Codigo}, Precio :{item.Precio}, Cantidad :{item.Cantidad}";
        }
    }
    public IEnumerable<Producto> GetProductos() => _productos;
    private int GetPrecioDelProducto(string codigoProducto) => _productos.First(t => t.Codigo == codigoProducto).Precio;
    public bool ExisteElProducto(string codigoProducto) => _productos.Any(t => t.Codigo == codigoProducto);
    public bool HayStockDelProducto(string codigoProducto) => _productos.First(t => t.Codigo == codigoProducto).Cantidad is not 0 and > 0;
    public ExpenMachineDevuelta Devuelta(ExpenMachinePedido pedido)
    {
        var producto = _productos.First(t => t.Codigo == pedido.CodigoPedido);

        var devuelta = Cobrar(producto.Precio, pedido.Monedas.Sum());

        return new(producto.Nombre, devuelta);
    }
    private IEnumerable<int> Cobrar(int precioDelProducto, int totalDeDinero)
    {
        var cambio = totalDeDinero - precioDelProducto;

        //var listaDeNonedas = new List<int>();

        var totalDeCambio = 0;

        while (totalDeCambio != cambio)
        {
            if ((totalDeCambio + 200) < cambio)
            {
                totalDeCambio += 200;
                yield return 200;
            }
            else if ((totalDeCambio + 100) < cambio)
            {
                totalDeCambio += 100;
                yield return 100;
            }
            else if ((totalDeCambio + 50) < cambio)
            {
                totalDeCambio += 50;
                yield return 50;
            }
            else if ((totalDeCambio + 10) < cambio)
            {
                totalDeCambio += 10;
                yield return 10;
            }
            else if ((totalDeCambio + 5) < cambio)
            {
                totalDeCambio += 5;
                yield return 5;
            }
        }

        //return listaDeNonedas;
    }
    public bool SonMonedasSoportadas(IEnumerable<int> monedas)
    {
        using (var colleccion = monedas.GetEnumerator())
        {
            if (!colleccion.MoveNext()) return false;

            while (colleccion.MoveNext())
            {
                if (!_monedasSoportadas.Any(x => x == colleccion.Current)) return false;
            }
            return true;
        }
    }
    private readonly int[] _monedasSoportadas;
    private readonly Producto[] _productos = null!;
}
public record class ExpenMachineDevuelta(string NombreDelProducto, IEnumerable<int> Devulta);
public record class Producto(string Codigo, string Nombre, int Precio, int Cantidad);
public record class ExpenMachinePedido(string CodigoPedido, IEnumerable<int> Monedas);
