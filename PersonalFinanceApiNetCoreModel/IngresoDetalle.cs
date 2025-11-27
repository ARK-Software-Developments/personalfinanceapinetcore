namespace PersonalFinanceApiNetCoreModel
{
#pragma warning disable CS8618
#pragma warning disable SA1623

    using System.Text.Json.Serialization;

    /// <summary>
    /// Clase IngresoDetalle.
    /// </summary>
    public class IngresoDetalle : AbstractModelExternder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IngresoDetalle"/> class.
        /// </summary>
        public IngresoDetalle()
        {
        }

        /// <summary>
        /// Gets or sets propiedad Codigo.
        /// </summary>
        [JsonPropertyOrder(2)]
        public int Codigo { get; set; }

        /// <summary>
        /// Gets or sets propiedad Detalle.
        /// </summary>
        [JsonPropertyOrder(20)]
        public string Detalle { get; set; }
    }
}