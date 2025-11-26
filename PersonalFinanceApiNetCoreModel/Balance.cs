namespace PersonalFinanceApiNetCoreModel
{
#pragma warning disable CS8618

    using System.Text.Json.Serialization;

    /// <summary>
    /// Clase TipoGasto.
    /// </summary>
    public class Balance : Meses
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Balance"/> class.
        /// </summary>
        public Balance()
        {
        }

        /// <summary>
        /// Gets or sets propiedad Concepto.
        /// </summary>
        [JsonPropertyOrder(15)]
        public string? Concepto { get; set; }
    }
}