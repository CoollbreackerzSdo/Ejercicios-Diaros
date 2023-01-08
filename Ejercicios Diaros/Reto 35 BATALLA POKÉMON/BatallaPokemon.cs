namespace Ejercicios_Diaros.Reto_35_BATALLA_POKÉMON;
/*
 * Enunciado: Crea un programa que calcule el daño de un ataque durante
 * una batalla Pokémon.
 * - La fórmula será la siguiente: daño = 50 * (ataque / defensa) * efectividad
 * - Efectividad: x2 (súper efectivo), x1 (neutral), x0.5 (no es muy efectivo)
 * - Sólo hay 4 tipos de Pokémon: Agua, Fuego, Planta y Eléctrico 
 *   (buscar su efectividad)
 * - El programa recibe los siguientes parámetros:
 *  - Tipo del Pokémon atacante.
 *  - Tipo del Pokémon defensor.
 *  - Ataque: Entre 1 y 100.
 *  - Defensa: Entre 1 y 100.
 */
public class BatallaPokemon
{
    public double Atakar(Pokemon atacante, Daño TypoDaño) => TypoDaño switch
    {
        Daño.Super => 50 * (atacante.Atk / atacante.Defenza) * 2,
        Daño.Neutral => 50 * (atacante.Atk / atacante.Defenza) * 1,
        _ => 50 * (atacante.Atk / atacante.Defenza) * 0.5
    };
    public enum Daño
    {
        Super,
        Neutral,
        Devil
    }
}
public class Pokemon
{
    public Pokemon(TypoPomekom typo)
    {
        TipoPokemon = typo switch
        {
            TypoPomekom.Agua => 1,
            TypoPomekom.Fuego => 2,
            TypoPomekom.Planta => 3,
            _ => 4
        };
    }
    public required double Atk { get; set; }
    public required double Defenza { get; set; }
    public required double Vida { get; set; }
    public readonly int TipoPokemon;
    public enum TypoPomekom
    {
        Agua = 1,
        Fuego = 2,
        Planta = 3,
        Electrico = 4
    }
}