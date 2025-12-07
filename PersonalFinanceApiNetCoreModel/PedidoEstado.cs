namespace PersonalFinanceApiNetCoreModel
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Clase PedidoEstado.
    /// </summary>
    public class PedidoEstado : AbstractModelExternder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PedidoEstado"/> class.
        /// </summary>
        public PedidoEstado()
        {
        }

        /// <summary>
        /// Gets or sets propiedad Orden.
        /// </summary>
        [JsonPropertyOrder(2)]
        public int Orden { get; set; }

        /// <summary>
        /// Gets or sets propiedad Nombre.
        /// </summary>
        [JsonPropertyOrder(3)]
        public string? Nombre { get; set; }

        /// <summary>
        /// Gets or sets propiedad Nombre.
        /// </summary>
        [JsonPropertyOrder(4)]
        public string? Tabla { get; set; }
    }
}
