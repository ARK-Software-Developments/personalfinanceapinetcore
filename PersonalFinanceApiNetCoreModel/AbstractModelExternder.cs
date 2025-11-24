namespace PersonalFinanceApiNetCoreModel
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Clase abstract AbstractModelExternder.
    /// </summary>
    public abstract class AbstractModelExternder
    {
        /// <summary>
        /// Gets or sets propiedad Id.
        /// </summary>
        [Required]
        [JsonPropertyOrder(1)]
        public int Id { get; set; }
    }
}