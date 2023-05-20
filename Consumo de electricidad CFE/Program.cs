using System.Globalization;

var mensajeValorInicial = "Introduce el valor inicial de kWH consumidos en el mes: ";
var mensajeValorFinal = "Introduce el valor de kWh consumidos hasta hoy: ";
var mensajeFecha = "Intrudoce la fecha inicial de conteo en formato DD/MM/AA: ";

decimal ObtenerNumeroValido(string mensaje, decimal valorAComprarar)
{
    decimal numeroValido;
    string? input;
    while (true)
    {
        Console.Write(mensaje);
        input = Console.ReadLine();
        var exitoEnConversion = decimal.TryParse(input, out numeroValido);
        if (exitoEnConversion)
        {
            if (numeroValido >= valorAComprarar)
            {
                return numeroValido;
            }
            else
            {
                Console.WriteLine($"'{numeroValido}' no es un consumo válido. Debe ser mayor a '{valorAComprarar}'. Intente de nuevo.\n");
            }
        }
        else
        {
            Console.WriteLine($"'{input}' no es un valor válido. Intente de nuevo.\n");
        }
    }
}

DateTime ObtenerFechaValida(string mensaje)
{
    DateTime fechaHoraValida;
    string? input;
    while (true)
    {
        Console.Write(mensaje);
        input = Console.ReadLine();
        var exitoEnConversion = DateTime.TryParse(input, new CultureInfo("es-MX"), out fechaHoraValida);
        if (exitoEnConversion)
        {
            return fechaHoraValida;
        }
        else
        {
            Console.WriteLine($"'{input}' no es un formato válido de fecha. Intente de nuevo.\n");
        }
    }
}

Console.Clear();

var valorConsumoInicial = ObtenerNumeroValido(mensajeValorInicial, 0);
var valorConsumoFinal = ObtenerNumeroValido(mensajeValorFinal, valorConsumoInicial);
var fechaInicial = ObtenerFechaValida(mensajeFecha);

var miRecibo = new Recibo(valorConsumoFinal - valorConsumoInicial, fechaInicial);

Console.WriteLine();
miRecibo.ImprimirInfo();

var futuroRecibo = new Recibo(miRecibo.PromedioConsumoPorDia * 61, fechaInicial);
Console.WriteLine($"\nPosible futuro recibo: \n");
futuroRecibo.ImprimirInfoBasica();
