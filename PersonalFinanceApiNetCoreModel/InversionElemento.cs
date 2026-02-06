namespace PersonalFinanceApiNetCoreModel
{
using System.Diagnostics.Metrics;
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.

using System.Text.Json.Serialization;

/// <summary>
/// Clase InversionInstrumento.
/// </summary>
public class InversionElemento : AbstractModelExternder
{
/// <summary>
/// Initializes a new instance of the <see cref="InversionElemento"/> class.
/// </summary>
public InversionElemento()
{
}

/// <summary>
/// Gets or sets propiedad Inversion.
/// </summary>
[JsonPropertyOrder(2)]
public Inversion Inversion { get; set; }

/// <summary>
/// Gets or sets propiedad Cantidad.
/// </summary>
[JsonPropertyOrder(3)]
public int Cantidad { get; set; }

/// <summary>
/// Gets or sets propiedad MontoUnitario.
/// </summary>
[JsonPropertyOrder(4)]
public decimal MontoUnitario { get; set; }

/// <summary>
/// Gets or sets propiedad MontoImpuestos.
/// </summary>
[JsonPropertyOrder(5)]
public decimal MontoImpuestos { get; set; }

/// <summary>
/// Gets or sets propiedad FechaOperacion.
/// </summary>
[JsonPropertyOrder(6)]
public DateTime? FechaOperacion { get; set; }

/// <summary>
/// Gets or sets propiedad NumeroOperacion.
/// </summary>
[JsonPropertyOrder(7)]
public string NumeroOperacion { get; set; }

/// <summary>
/// Gets or sets propiedad MontoImpuestos.
/// </summary>
[JsonPropertyOrder(8)]
public decimal MontoInvertido { get; set; }

/// <summary>
/// Gets or sets propiedad MontoResultado.
/// </summary>
[JsonPropertyOrder(9)]
public decimal MontoResultado { get; set; }

/// <summary>
/// Gets or sets propiedad Instrumento.
/// </summary>
[JsonPropertyOrder(10)]
public InversionInstrumento Instrumento { get; set; }

/// <summary>
/// Gets or sets propiedad Estado.
/// </summary>
[JsonPropertyOrder(11)]
public string Estado { get; set; }
}
}
