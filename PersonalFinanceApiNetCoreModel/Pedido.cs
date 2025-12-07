namespace PersonalFinanceApiNetCoreModel
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Clase Servicio.
    /// </summary>
    public class Pedido : AbstractModelExternder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pedido"/> class.
        /// </summary>
        public Pedido()
        {
        }

        /// <summary>
        /// Gets or sets propiedad Numero.
        /// </summary>
        [Required]
        [JsonPropertyOrder(2)]
        public int Numero { get; set; }

        /// <summary>
        /// Gets or sets propiedad FechaPedido.
        /// </summary>
        [JsonPropertyOrder(3)]
        public DateTime FechaPedido { get; set; }

        /// <summary>
        /// Gets or sets propiedad FechaRecibido.
        /// </summary>
        [JsonPropertyOrder(4)]
        public DateTime? FechaRecibido { get; set; }

        /// <summary>
        /// Gets or sets propiedad MontoTotal.
        /// </summary>
        [JsonPropertyOrder(5)]
        public decimal MontoTotal { get; set; }

        /// <summary>
        /// Gets or sets propiedad TipoRecurso.
        /// </summary>
        [JsonPropertyOrder(6)]
        public string? TipoRecurso { get; set; }

        /// <summary>
        /// Gets or sets propiedad Estado.
        /// </summary>
        [JsonPropertyOrder(7)]
        public PedidoEstado? Estado { get; set; }
    }
}