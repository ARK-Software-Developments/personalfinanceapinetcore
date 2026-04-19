namespace PersonalFinanceApiNetCoreModel
{
#pragma warning disable CS8618
#pragma warning disable SA1623

    using System.Text.Json.Serialization;

    /// <summary>
    /// Clase GastoResumenCategoria.
    /// </summary>
    public class GastoResumenCategoria : Meses
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GastoResumenCategoria"/> class.
        /// </summary>
        public GastoResumenCategoria()
        {
        }

        /// <summary>
        /// Gets or sets propiedad Resumen.
        /// </summary>
        [JsonPropertyOrder(15)]
        public string Categoria { get; set; }
    }
}