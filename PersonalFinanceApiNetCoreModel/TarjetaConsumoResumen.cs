namespace PersonalFinanceApiNetCoreModel
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Clase TarjetaConsumoResumen.
    /// </summary>
    public class TarjetaConsumoResumen : Meses
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TarjetaConsumoResumen"/> class.
        /// </summary>
        public TarjetaConsumoResumen()
        {
        }

        /// <summary>
        /// Gets or sets propiedad EntidadCompra.
        /// </summary>
        [JsonPropertyOrder(15)]
        public string EntidadCompra { get; set; }
    }
}