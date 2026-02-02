namespace PersonalFinanceApiNetCoreModel
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Clase InversionTipo.
    /// </summary>
    public class InversionTipo : AbstractModelExternder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InversionTipo"/> class.
        /// </summary>
        public InversionTipo()
        {
        }

        /// <summary>
        /// Gets or sets propiedad Nombre.
        /// </summary>
        [JsonPropertyOrder(2)]
        public string? Nombre { get; set; }

        /// <summary>
        /// Gets or sets propiedad Tipo.
        /// </summary>
        [JsonPropertyOrder(3)]
        public string? Tipo { get; set; }
    }
}
