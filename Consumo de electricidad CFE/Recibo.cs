public class Recibo
{
    public static decimal PrecioDAC = 6.98M;
    public static decimal PrecioExcedente = 3.52M;
    public static decimal PrecioIntermedio = 1.19M;
    public static decimal PrecioBasico = 0.98M;
    public static decimal IVA = 1.16M;
    public decimal ConsumoTotal { get; init; }
    decimal basico;
    decimal intermedio;
    decimal excedente;
    decimal DAC;
    public DateTime FechaInicial { get; init; }
    public int Dias { get; init; }
    public decimal PrecioFinal { get; init; }
    public decimal PromedioConsumoPorDia { get; init; }
    public Recibo(decimal consumoTotal, DateTime fechaInicial)
    {
        this.ConsumoTotal = consumoTotal;
        // Inicializando los valores de las diferentes tarifas
        if (this.ConsumoTotal >= 500)
        {
            basico = 0;
            intermedio = 0;
            excedente = 0;
            DAC = this.ConsumoTotal;
        }
        else if (this.ConsumoTotal > 280)
        {
            DAC = 0;
            excedente = this.ConsumoTotal - 280;
            intermedio = 130;
            basico = 150;
        }
        else if (this.ConsumoTotal > 150)
        {
            DAC = 0;
            excedente = 0;
            intermedio = this.ConsumoTotal - 150;
            basico = 150;
        }
        else
        {
            DAC = 0;
            excedente = 0;
            intermedio = 0;
            basico = this.ConsumoTotal;
        }
        // Calculando el precio final.
        if (DAC != 0)
        {
            PrecioFinal = (DAC * PrecioDAC) * IVA;
        }
        else
        {
            PrecioFinal = ((basico * PrecioBasico) + (intermedio * PrecioIntermedio) + (excedente * PrecioExcedente) * IVA);
        }
        // Inicializando los últimos valores.
        FechaInicial = fechaInicial;
        Dias = (DateTime.Today - FechaInicial).Days;
        PromedioConsumoPorDia = this.ConsumoTotal / (decimal)Dias;
    }
    public void ImprimirInfo()
    {
        var delimitador = new string('*', 54);
        Console.WriteLine(delimitador);
        Console.WriteLine($"Consumo de {ConsumoTotal:F2}kWh en {Dias} días. Precio final: {this.PrecioFinal:C2}");
        if (DAC != 0)
        {
            Console.WriteLine($"\tDAC: {DAC}");
        }
        else
        {
            Console.WriteLine($"");
            Console.WriteLine($"\tBásico:\t\t{basico:F2}kWh");
            Console.WriteLine($"\tIntermedio:\t{intermedio:F2}kWh");
            Console.WriteLine($"\tExcedente:\t{excedente:F2}kWh");
        }
        Console.WriteLine($"Consumo diario promedio: {PromedioConsumoPorDia:F2}kWh");
        Console.WriteLine(delimitador);
    }
    public void ImprimirInfoBasica()
    {
        var delimitador = new string('*', 54);
        Console.WriteLine(delimitador);
        Console.WriteLine($"Consumo de {ConsumoTotal:F2}kWh. Precio final: {this.PrecioFinal:C2}");
        if (DAC != 0)
        {
            Console.WriteLine($"\tDAC: {DAC}");
        }
        else
        {
            Console.WriteLine($"");
            Console.WriteLine($"\tBásico:\t\t{basico:F2}kWh");
            Console.WriteLine($"\tIntermedio:\t{intermedio:F2}kWh");
            Console.WriteLine($"\tExcedente:\t{excedente:F2}kWh");
        }
        Console.WriteLine(delimitador);
    }
}