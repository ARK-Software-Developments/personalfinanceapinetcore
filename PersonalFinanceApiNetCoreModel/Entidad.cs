namespace PersonalFinanceApiNetCoreModel
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Clase Entidad.
    /// </summary>
    public class Entidad : AbstractModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entidad"/> class.
        /// </summary>
        public Entidad()
        {
        }

        /// <summary>
        /// Gets or sets propiedad Tipo.
        /// </summary>
        [JsonPropertyOrder(3)]
        public string? Tipo { get; set; }
    }
}