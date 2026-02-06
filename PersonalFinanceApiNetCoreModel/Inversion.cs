namespace PersonalFinanceApiNetCoreModel
{
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

/// <summary>
/// Clase Inversion.
/// </summary>
public class Inversion : AbstractModelExternder
{
/// <summary>
/// Initializes a new instance of the <see cref="Inversion"/> class.
/// </summary>
public Inversion()
{
}

/// <summary>
/// Gets or sets propiedad FechaOperacion.
/// </summary>
[JsonPropertyOrder(2)]
public DateTime? FechaOperacion { get; set; }

/// <summary>
/// Gets or sets propiedad FechaActualizacion.
/// </summary>
[JsonPropertyOrder(3)]
public DateTime? FechaActualizacion { get; set; }

/// <summary>
/// Gets or sets propiedad MontoInvertido.
/// </summary>
[JsonPropertyOrder(4)]
public decimal MontoInvertido { get; set; }

/// <summary>
/// Gets or sets propiedad MontoGanado.
/// </summary>
[JsonPropertyOrder(5)]
public decimal MontoGanado { get; set; }

/// <summary>
/// Gets or sets propiedad Entidad.
/// </summary>
[JsonPropertyOrder(6)]
public Entidad Entidad { get; set; }

/// <summary>
/// Gets or sets propiedad Tipo.
/// </summary>
[JsonPropertyOrder(7)]
public InversionTipo Tipo { get; set; }

/// <summary>
/// Gets or sets propiedad Estado.
/// </summary>
[JsonPropertyOrder(8)]
public string Estado { get; set; }
}
}