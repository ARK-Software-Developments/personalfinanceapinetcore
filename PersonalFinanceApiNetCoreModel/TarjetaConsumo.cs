namespace PersonalFinanceApiNetCoreModel
{
#pragma warning disable CS8618
#pragma warning disable SA1623

    using System.Text.Json.Serialization;

    /// <summary>
    /// Clase TarjetaConsumo.
    /// </summary>
    public class TarjetaConsumo : Meses
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TarjetaConsumo"/> class.
        /// </summary>
        public TarjetaConsumo()
        {
        }

        /// <summary>
        /// Gets or sets propiedad Tarjeta.
        /// </summary>
        [JsonPropertyOrder(15)]
        public Tarjeta Tarjeta { get; set; }

        /// <summary>
        /// Gets or sets propiedad EntidadCompra.
        /// </summary>
        [JsonPropertyOrder(16)]
        public string EntidadCompra { get; set; }

        /// <summary>
        /// Gets or sets propiedad Detalle.
        /// </summary>
        [JsonPropertyOrder(17)]
        public string Detalle { get; set; }

        /// <summary>
        /// Gets or sets propiedad Cuotas.
        /// </summary>
        [JsonPropertyOrder(18)]
        public int Cuotas { get; set; }

        /// <summary>
        /// Gets or sets propiedad Verificado.
        /// </summary>
        [JsonPropertyOrder(19)]
        public bool Verificado { get; set; }

        /// <summary>
        /// Gets or sets propiedad Pagado.
        /// </summary>
        [JsonPropertyOrder(20)]
        public bool Pagado { get; set; }

        /// <summary>
        /// Gets or sets propiedad Cuotas.
        /// </summary>
        [JsonPropertyOrder(21)]
        public int TransaccionesAsociadas { get; set; }
    }
}