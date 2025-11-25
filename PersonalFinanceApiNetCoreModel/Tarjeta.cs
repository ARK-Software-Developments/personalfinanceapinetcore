namespace PersonalFinanceApiNetCoreModel
{
#pragma warning disable CS8618
#pragma warning disable SA1623

    using System.Text.Json.Serialization;

    /// <summary>
    /// Clase Tarjeta.
    /// </summary>
    public class Tarjeta : AbstractModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tarjeta"/> class.
        /// </summary>
        public Tarjeta()
        {
        }

        /// <summary>
        /// Gets or sets propiedad FechaCierre.
        /// </summary>
        [JsonPropertyOrder(3)]
        public DateTime FechaCierre { get; set; }

        /// <summary>
        /// Gets or sets propiedad FechaVencimiento.
        /// </summary>
        [JsonPropertyOrder(4)]
        public DateTime FechaVencimiento { get; set; }

        /// <summary>
        /// Gets or sets propiedad Entidad.
        /// </summary>
        [JsonPropertyOrder(5)]
        public Entidad Entidad { get; set; }

        /// <summary>
        /// Gets or sets propiedad Activo.
        /// </summary>
        [JsonPropertyOrder(6)]
        public bool Activo { get; set; }
    }
}