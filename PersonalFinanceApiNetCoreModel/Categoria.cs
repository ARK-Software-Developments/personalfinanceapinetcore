namespace PersonalFinanceApiNetCoreModel
{
    using Newtonsoft.Json;

    /// <summary>
    /// Clase Categoria.
    /// </summary>
    public class Categoria
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Categoria"/> class.
        /// </summary>
        public Categoria()
        {
        }

        /// <summary>
        /// Gets or sets propiedad Id.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets propiedad Nombre/category.
        /// </summary>
        [JsonProperty("category")]
        public string Nombre { get; set; }
    }
}