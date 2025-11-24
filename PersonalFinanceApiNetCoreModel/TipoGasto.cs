namespace PersonalFinanceApiNetCoreModel
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Clase TipoGasto.
    /// </summary>
    public class TipoGasto : AbstractModelExternder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TipoGasto"/> class.
        /// </summary>
        public TipoGasto()
        {
        }

        /// <summary>
        /// Gets or sets propiedad Tipo.
        /// </summary>
        [JsonPropertyOrder(2)]
        public string? Tipo { get; set; }

        /// <summary>
        /// Gets or sets propiedad Categoria.
        /// </summary>
        [JsonPropertyOrder(3)]
        public Categoria Categoria { get; set; }
    }
}