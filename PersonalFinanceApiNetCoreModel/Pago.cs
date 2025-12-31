namespace PersonalFinanceApiNetCoreModel
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Clase Servicio.
    /// </summary>
    public class Pago : AbstractModelExternder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pago"/> class.
        /// </summary>
        public Pago()
        {
        }

        /// <summary>
        /// Gets or sets propiedad FechaRegistro.
        /// </summary>
        [JsonPropertyOrder(2)]
        public DateTime? FechaRegistro { get; set; }

        /// <summary>
        /// Gets or sets propiedad FechaPago.
        /// </summary>
        [JsonPropertyOrder(3)]
        public DateTime? FechaPago { get; set; }

        /// <summary>
        /// Gets or sets propiedad CodigoRegistro.
        /// </summary>
        [JsonPropertyOrder(4)]
        public string? CodigoRegistro { get; set; }

        /// <summary>
        /// Gets or sets propiedad RecursoDelPago.
        /// </summary>
        [JsonPropertyOrder(5)]
        public Entidad? RecursoDelPago { get; set; }

        /// <summary>
        /// Gets or sets propiedad TipoDePago.
        /// </summary>
        [JsonPropertyOrder(6)]
        public string? TipoDePago { get; set; }

        /// <summary>
        /// Gets or sets propiedad MontoPresupuestado.
        /// </summary>
        [JsonPropertyOrder(7)]
        public decimal MontoPresupuestado { get; set; }

        /// <summary>
        /// Gets or sets propiedad MontoPagado.
        /// </summary>
        [JsonPropertyOrder(8)]
        public decimal MontoPagado { get; set; }

        /// <summary>
        /// Gets or sets propiedad EsTipoDeGastotado.
        /// </summary>
        [JsonPropertyOrder(9)]
        public TipoGasto TipoDeGasto { get; set; }
    }
}