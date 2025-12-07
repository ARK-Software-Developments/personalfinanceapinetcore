namespace PersonalFinanceApiNetCoreModel
{
#pragma warning disable CS8618

    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Clase PedidoDetalle.
    /// </summary>
    public class PedidoDetalle : AbstractModelExternder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PedidoDetalle"/> class.
        /// </summary>
        public PedidoDetalle()
        {
        }

        /// <summary>
        /// Gets or sets propiedad NumeroOrden.
        /// </summary>
        [Required]
        [JsonPropertyOrder(2)]
        public int NumeroOrden { get; set; }

        /// <summary>
        /// Gets or sets propiedad Marca.
        /// </summary>
        [JsonPropertyOrder(3)]
        public string Marca { get; set; }

        /// <summary>
        /// Gets or sets propiedad ProductoDetalle.
        /// </summary>
        [JsonPropertyOrder(4)]
        public string ProductoDetalle { get; set; }

        /// <summary>
        /// Gets or sets propiedad Descripcion.
        /// </summary>
        [JsonPropertyOrder(5)]
        public string Descripcion { get; set; }

        /// <summary>
        /// Gets or sets propiedad CodigoProducto.
        /// </summary>
        [JsonPropertyOrder(6)]
        public string? CodigoProducto { get; set; }

        /// <summary>
        /// Gets or sets propiedad CodigoProducto.
        /// </summary>
        [JsonPropertyOrder(7)]
        public int Cantidad { get; set; }

        /// <summary>
        /// Gets or sets propiedad MontoUnitario.
        /// </summary>
        [JsonPropertyOrder(8)]
        public decimal MontoUnitario { get; set; }

        /// <summary>
        /// Gets or sets propiedad SubTotal.
        /// </summary>
        [JsonPropertyOrder(9)]
        public decimal SubTotal { get; set; }

        /// <summary>
        /// Gets or sets propiedad Para.
        /// </summary>
        [JsonPropertyOrder(10)]
        public string? Para { get; set; }

        /// <summary>
        /// Gets or sets propiedad Estado.
        /// </summary>
        [JsonPropertyOrder(11)]
        public PedidoEstado? Estado { get; set; }
    }
}