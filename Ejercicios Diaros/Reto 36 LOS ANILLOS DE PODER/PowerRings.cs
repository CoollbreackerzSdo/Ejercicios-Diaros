/*
 * Enunciado: ¡La Tierra Media está en guerra! En ella lucharán razas leales
 * a Sauron contra otras bondadosas que no quieren que el mal reine
 * sobre sus tierras.
 * Cada raza tiene asociado un "valor" entre 1 y 5:
 * - Razas bondadosas: Pelosos (1), Sureños buenos (2), Enanos (3),
 *   Númenóreanos (4), Elfos (5)
 * - Razas malvadas: Sureños malos (2), Orcos (2), Goblins (2),
 *   Huargos (3), Trolls (5)
 * Crea un programa que calcule el resultado de la batalla entre
 * los 2 tipos de ejércitos:
 * - El resultado puede ser que gane el bien, el mal, o exista un empate.
 *   Dependiendo de la suma del valor del ejército y el número de integrantes.
 * - Cada ejército puede estar compuesto por un número de integrantes variable
 *   de cada raza.
 * - Tienes total libertad para modelar los datos del ejercicio.
 * Ej: 1 Peloso pierde contra 1 Orco
 *     2 Pelosos empatan contra 1 Orco
 *     3 Pelosos ganan a 1 Orco
 */

using System.ComponentModel.DataAnnotations;

namespace Ejercicios_Diaros.Reto_36_LOS_ANILLOS_DE_PODER
{
    public class PowerRings
    {
        public PowerRings(IEnumerable<Personaje> Vando1,IEnumerable<Personaje> Vando2)
        {
            _Vando1 = Vando1;
            _Vando2 = Vando2;
        }
        public bool IniciarLaBattala()
        {
            if (_Vando1 is null || _Vando2 is null) throw new ArgumentNullException();

            bool ganaror = true;

            int resultado = Random.Shared.Next(1, 100);

            if(resultado < 50)
            {
                ganaror = false;
            }

            return ganaror;
        }
        private readonly IEnumerable<Personaje> _Vando1;
        private readonly IEnumerable<Personaje> _Vando2;
    }
}
public record class Personaje([MaxLength(5),MinLength(1)]int Raza,bool Vando)
{
    public string RazaNombre() => (Raza,Vando) switch
    {
        (1,true) => "Pelosos",
        (2,true) => "Sureños Buenos",
        (4,true) => "Numenoreanos",
        (3,true) => "Enanos",
        (5,true) => "Elfos",
        (1, false) => "Orcos",
        (2, false) => "Sureños Buenos",
        (4, false) => "Goblins",
        (3, false) => "Huargos",
        (5, false) => "Trolls",
        _ => ""
    };
};