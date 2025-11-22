namespace PersonalFinanceApiNetCoreModel
{
    using Newtonsoft.Json;

    /// <summary>
    /// Clase GeneralResponse.
    /// </summary>
    public class GeneralResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralResponse"/> class.
        /// </summary>
        public GeneralResponse()
        {
        }

        /// <summary>
        /// Gets or sets propiedad Metodo.
        /// </summary>
        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        /// <summary>
        /// Gets or sets propiedad Errores.
        /// </summary>
        [JsonProperty("errors")]
        public ErrorCustom Errores { get; set; }

        /// <summary>
        /// Gets or sets propiedad Data.
        /// </summary>
        [JsonProperty("data")]
        public object Data { get; set; }
    }
}