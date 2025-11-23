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
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets propiedad Nombre.
        /// </summary>
        [JsonProperty("entity")]
        public string Nombre { get; set; }

        /// <summary>
        /// Gets or sets propiedad Tipo.
        /// </summary>
        [JsonProperty("entitytype")]
        public string Tipo { get; set; }
    }
}