namespace PersonalFinanceApiNetCoreModel
{
#pragma warning disable CS8618

    using Newtonsoft.Json;

    /// <summary>
    /// Clase ErrorCustom.
    /// </summary>
    public class ErrorCustom
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorCustom"/> class.
        /// </summary>
        public ErrorCustom()
        {
        }

        /// <summary>
        /// Gets or sets propiedad Estado.
        /// </summary>
        [JsonProperty("status")]
        public int Estado { get; set; }

        /// <summary>
        /// Gets or sets propiedad Codigo.
        /// </summary>
        [JsonProperty("code")]
        public string Codigo { get; set; }

        /// <summary>
        /// Gets or sets propiedad Mensaje.
        /// </summary>
        [JsonProperty("message")]
        public string Mensaje { get; set; }

        /// <summary>
        /// Gets or sets propiedad Detalle.
        /// </summary>
        [JsonProperty("details")]
        public string Detalle { get; set; }

        /// <summary>
        /// Gets or sets propiedad Recurso.
        /// </summary>
        [JsonProperty("source")]
        public string Recurso { get; set; }
    }
}
