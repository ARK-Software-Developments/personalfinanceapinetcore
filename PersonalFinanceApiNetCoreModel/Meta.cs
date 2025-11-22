namespace PersonalFinanceApiNetCoreModel
{
    using Newtonsoft.Json;

    /// <summary>
    /// clase Meta.
    /// </summary>
    public class Meta
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Meta"/> class.
        /// </summary>
        public Meta()
        {
        }

        /// <summary>
        /// Gets or sets propiedad Metodo.
        /// </summary>
        [JsonProperty("method")]
        public string Metodo { get; set; }

        /// <summary>
        /// Gets or sets propiedad Operacion.
        /// </summary>
        [JsonProperty("operation")]
        public string Operacion { get; set; }

        /// <summary>
        /// Gets or sets propiedad Recurso.
        /// </summary>
        [JsonProperty("source")]
        public string Recurso { get; set; }
    }
}
