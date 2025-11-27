namespace PersonalFinanceApiNetCoreModel
{
#pragma warning disable CS8618

    using System.Text.Json.Serialization;

    /// <summary>
    /// Clase Ingreso.
    /// </summary>
    public class Ingreso : Meses
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ingreso"/> class.
        /// </summary>
        public Ingreso()
        {
        }

        /// <summary>
        /// Gets or sets propiedad Detalle.
        /// </summary>
        [JsonPropertyOrder(15)]
        public IngresoDetalle Detalle { get; set; }
    }
}