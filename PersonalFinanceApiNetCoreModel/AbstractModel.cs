namespace PersonalFinanceApiNetCoreModel
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Clase abstract AbstractModel.
    /// </summary>
    public abstract class AbstractModel
    {
        /// <summary>
        /// Gets or sets propiedad Id.
        /// </summary>
        [JsonPropertyOrder(1)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets propiedad Nombre/category.
        /// </summary>
        [JsonPropertyOrder(2)]
        public string Nombre { get; set; }
    }
}