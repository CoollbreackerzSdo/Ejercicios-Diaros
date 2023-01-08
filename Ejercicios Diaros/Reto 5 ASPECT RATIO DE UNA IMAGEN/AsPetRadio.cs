/*
 * Crea un programa que se encargue de calcular el aspect ratio de una
 * imagen a partir de una url.
 * - Url de ejemplo: https://raw.githubusercontent.com/mouredev/mouredev/master/mouredev_github_profile.png
 * - Por ratio hacemos referencia por ejemplo a los "16:9" de una
 *   imagen de 1920*1080px.
 */
using System.Drawing;

namespace Ejercicios_Diaros.Reto_5_ASPECT_RATIO_DE_UNA_IMAGEN;

public class CalAsPetRadioImagenWeb
{
    public async Task<Imagen> GetImgUrl()
    {
        var imagen = Image.FromStream(await GetHttpImg());

        var img = new Imagen(imagen.Width,imagen.Height,CalAsPetRadio(imagen.Width,imagen.Height));

        return img;
    }
    private double CalAsPetRadio(double Ancho,double Alto)
    {
        return (Ancho / Alto);
    }  
    private async Task<Stream> GetHttpImg()
    {
        var http = new HttpClient();

        var img = await http.GetStreamAsync(Url);

        return img;
    }
    public required string Url { internal get; set; }
}
public record class Imagen(double Ancho,double Alto,double AsPetRadio);