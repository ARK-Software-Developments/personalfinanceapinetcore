namespace PersonalFinanceApiNetCoreModel
{
    using Newtonsoft.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Clase Notificacion.
    /// </summary>
    public class Notificacion : AbstractModelExternder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Notificacion"/> class.
        /// </summary>
        public Notificacion()
        {
        }

        /// <summary>
        /// Gets or sets propiedad notificationdate.
        /// </summary>
        [JsonPropertyOrder(2)]
        [JsonProperty("notificationdate")]
        public DateTime FechaNotificacion { get; set; }

        /// <summary>
        /// Gets or sets propiedad title.
        /// </summary>
        [JsonPropertyOrder(3)]
        [JsonProperty("title")]
        public string Titulo { get; set; }

        /// <summary>
        /// Gets or sets propiedad type.
        /// </summary>
        [JsonPropertyOrder(3)]
        [JsonProperty("type")]
        public string Tipo { get; set; }

        /// <summary>
        /// Gets or sets propiedad messaje.
        /// </summary>
        [JsonPropertyOrder(3)]
        [JsonProperty("messaje")]
        public string Mensaje { get; set; }

        /// <summary>
        /// Gets or sets propiedad to.
        /// </summary>
        [JsonPropertyOrder(3)]
        [JsonProperty("to")]
        public string Para { get; set; }

        /// <summary>
        /// Gets or sets propiedad app.
        /// </summary>
        [JsonPropertyOrder(3)]
        [JsonProperty("app")]
        public string Aplicacion { get; set; }
    }
}