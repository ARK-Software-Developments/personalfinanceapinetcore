namespace PersonalFinanceApiNetCoreModel
{
    using Newtonsoft.Json;

    /// <summary>
    /// Clase Entidad.
    /// </summary>
    public class Entidad
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entidad"/> class.
        /// </summary>
        public Entidad()
        {
        }

        /// <summary>
        /// Gets or sets propiedad Id.
        /// </summary>
        [JsonRequired]
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets propiedad Nombre.
        /// </summary>
        [JsonRequired]
        [JsonProperty("entity")]
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets propiedad Tipo.
        /// </summary>
        [JsonRequired]
        [JsonProperty("entitytype")]
        public string Tipo { get; set; }
    }
}