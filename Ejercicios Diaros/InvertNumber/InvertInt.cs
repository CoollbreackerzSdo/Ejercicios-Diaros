namespace Ejercicios_Diaros.InvertNumber;

public class InvertInt
{
    public int Invert(int value)
    {
        return int.Parse(InvertString(value.ToString()));
    }
    private string InvertString(string text)
    {
        var textArray = text.ToArray();

        Array.Reverse(textArray);

        return new(textArray);
    }
}