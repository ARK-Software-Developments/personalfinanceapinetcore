namespace PersonalFinanceApiNetCoreModel
{
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.

    using System.Text.Json.Serialization;

    /// <summary>
    /// Clase InversionInstrumento.
    /// </summary>
    public class InversionInstrumento : AbstractModelExternder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InversionInstrumento"/> class.
        /// </summary>
        public InversionInstrumento()
        {
        }

        /// <summary>
        /// Gets or sets propiedad Detalle.
        /// </summary>
        [JsonPropertyOrder(2)]
        public string? Detalle { get; set; }

        /// <summary>
        /// Gets or sets propiedad Codigo.
        /// </summary>
        [JsonPropertyOrder(3)]
        public string? Codigo { get; set; }

        /// <summary>
        /// Gets or sets propiedad Tipo.
        /// </summary>
        [JsonPropertyOrder(4)]
        public InversionTipo Tipo { get; set; }
    }
}
