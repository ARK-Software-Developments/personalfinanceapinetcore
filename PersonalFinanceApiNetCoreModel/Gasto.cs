namespace PersonalFinanceApiNetCoreModel
{
#pragma warning disable CS8618
#pragma warning disable SA1623

    using System.Text.Json.Serialization;

    /// <summary>
    /// Clase Gasto.
    /// </summary>
    public class Gasto : Meses
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gasto"/> class.
        /// </summary>
        public Gasto()
        {
        }

        /// <summary>
        /// Gets or sets propiedad Resumen.
        /// </summary>
        [JsonPropertyOrder(15)]
        public string Resumen { get; set; }

        /// <summary>
        /// Gets or sets propiedad Observaciones.
        /// </summary>
        [JsonPropertyOrder(16)]
        public string Observaciones { get; set; }

        /// <summary>
        /// Gets or sets propiedad TipoGasto.
        /// </summary>
        [JsonPropertyOrder(17)]
        public TipoGasto TipoGasto { get; set; }

        /// <summary>
        /// Gets or sets propiedad Villetera.
        /// </summary>
        [JsonPropertyOrder(18)]
        public Entidad Villetera { get; set; }

        /// <summary>
        /// Gets or sets propiedad Verificado.
        /// </summary>
        [JsonPropertyOrder(19)]
        public bool Verificado { get; set; }

        /// <summary>
        /// Gets or sets propiedad Reservado.
        /// </summary>
        [JsonPropertyOrder(20)]
        public bool Reservado { get; set; }

        /// <summary>
        /// Gets or sets propiedad Pagado.
        /// </summary>
        [JsonPropertyOrder(21)]
        public bool Pagado { get; set; }

        /// <summary>
        /// Gets or sets propiedad Activo.
        /// </summary>
        [JsonPropertyOrder(22)]
        public bool Activo { get; set; }
    }
}