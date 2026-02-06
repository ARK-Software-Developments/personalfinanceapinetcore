namespace PersonalFinanceApiNetCoreModel
{
using System.Text.Json.Serialization;

/// <summary>
/// Clase PrestamoDetalle.
/// </summary>
public class PrestamoDetalle : AbstractModelExternder
{
/// <summary>
/// Initializes a new instance of the <see cref="PrestamoDetalle"/> class.
/// </summary>
public PrestamoDetalle()
{
}

/// <summary>
/// Gets or sets propiedad PrestamoId.
/// </summary>
[JsonPropertyOrder(2)]
public int PrestamoId { get; set; }

/// <summary>
/// Gets or sets propiedad Cuota.
/// </summary>
[JsonPropertyOrder(3)]
public int Cuota { get; set; }

/// <summary>
/// Gets or sets propiedad MontoCuota.
/// </summary>
[JsonPropertyOrder(4)]
public decimal MontoCuota { get; set; }

/// <summary>
/// Gets or sets propiedad FechaPagado.
/// </summary>
[JsonPropertyOrder(5)]
public DateTime? FechaPagado { get; set; }

/// <summary>
/// Gets or sets propiedad ComprobantePago.
/// </summary>
[JsonPropertyOrder(6)]
public string? ComprobantePago { get; set; }

/// <summary>
/// Gets or sets propiedad MetodoPago.
/// </summary>
[JsonPropertyOrder(7)]
public string? MetodoPago { get; set; }

/// <summary>
/// Gets or sets propiedad Observaciones.
/// </summary>
[JsonPropertyOrder(8)]
public string? Observaciones { get; set; }

/// <summary>
/// Gets or sets propiedad Estado.
/// </summary>
[JsonPropertyOrder(9)]
public string Estado { get; set; }
}
}