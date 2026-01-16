using System.Text.Json.Serialization;

namespace PersonalFinanceApiNetCoreModel
{
    /// <summary>
    /// Clase Ingreso.
    /// </summary>
    public class CalendarioVencimiento : AbstractModelExternder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CalendarioVencimiento"/> class.
        /// </summary>
        public CalendarioVencimiento()
        {
        }

        /// <summary>
        /// Gets or sets propiedad FechaVencimiento.
        /// </summary>
        [JsonPropertyOrder(2)]
        public DateTime FechaVencimiento { get; set; }

        /// <summary>
        /// Gets or sets propiedad TipoGastoId.
        /// </summary>
        [JsonPropertyOrder(3)]
        public int TipoGastoId { get; set; }

        /// <summary>
        /// Gets or sets propiedad Activo.
        /// </summary>
        [JsonPropertyOrder(4)]
        public bool Activo { get; set; }
    }
}