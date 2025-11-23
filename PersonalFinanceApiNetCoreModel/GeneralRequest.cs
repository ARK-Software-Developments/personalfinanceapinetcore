namespace PersonalFinanceApiNetCoreModel
{
    using Newtonsoft.Json;

    /// <summary>
    /// Clase GeneralRequest.
    /// </summary>
    public class GeneralRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralRequest"/> class.
        /// </summary>
        public GeneralRequest()
        { 
        }

        /// <summary>
        /// Gets or sets propiedad Metodo.
        /// </summary>
        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        /// <summary>
        /// Gets or sets propiedad Data.
        /// </summary>
        [JsonProperty("data")]
        public object Data { get; set; }
    }
}