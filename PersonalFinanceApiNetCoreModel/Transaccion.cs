namespace PersonalFinanceApiNetCoreModel
{
    using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

    using System.Text.Json.Serialization;

    /// <summary>
    /// Clase Transaccion.
    /// </summary>
    public class Transaccion : AbstractModelExternder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Transaccion"/> class.
        /// </summary>
        public Transaccion()
        {
        }

        /// <summary>
        /// Gets or sets propiedad CodigoTransaccion.
        /// </summary>
        [JsonPropertyOrder(2)]
        public string CodigoTransaccion { get; set; }

        /// <summary>
        /// Gets or sets propiedad OrdenCompra.
        /// </summary>
        [JsonPropertyOrder(3)]
        public string OrdenCompra { get; set; }

        /// <summary>
        /// Gets or sets propiedad EntidadAsociada.
        /// </summary>
        [JsonPropertyOrder(4)]
        public string EntidadAsociada { get; set; }

        /// <summary>
        /// Gets or sets propiedad FechaTransaccion.
        /// </summary>
        [JsonPropertyOrder(5)]
        public DateTime FechaTransaccion { get; set; }

        /// <summary>
        /// Gets or sets propiedad Resumen.
        /// </summary>
        [JsonPropertyOrder(6)]
        public string Resumen { get; set; }

        /// <summary>
        /// Gets or sets propiedad Observaciones.
        /// </summary>
        [JsonPropertyOrder(7)]
        public string Observaciones { get; set; }

        /// <summary>
        /// Gets or sets propiedad Tarjeta.
        /// </summary>
        [JsonPropertyOrder(8)]
        public Tarjeta Tarjeta { get; set; }

        /// <summary>
        /// Gets or sets propiedad Id.
        /// </summary>
        [JsonPropertyOrder(9)]
        public int TarjetaConsumoId { get; set; }
    }
}