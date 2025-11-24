namespace PersonalFinanceApiNetCoreModel
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Clase Servicio.
    /// </summary>
    public class Servicio : AbstractModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Servicio"/> class.
        /// </summary>
        public Servicio()
        {
        }

        /// <summary>
        /// Gets or sets propiedad Monto.
        /// </summary>
        [JsonPropertyOrder(3)]
        public int Monto { get; set; }

        /// <summary>
        /// Gets or sets propiedad MontoUnitario.
        /// </summary>
        [JsonPropertyOrder(4)]
        public decimal MontoUnitario { get; set; }

        /// <summary>
        /// Gets or sets propiedad ValidoDesde.
        /// </summary>
        [JsonPropertyOrder(5)]
        public DateTime ValidoDesde { get; set; }
    }
}