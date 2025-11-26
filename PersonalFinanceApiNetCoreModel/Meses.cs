namespace PersonalFinanceApiNetCoreModel
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Clase Meses.
    /// </summary>
    public abstract class Meses : AbstractModelExternder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Meses"/> class.
        /// </summary>
        public Meses()
        {
        }

        /// <summary>
        /// Gets or sets propiedad Categoria.
        /// </summary>
        [JsonPropertyOrder(2)]
        public decimal Enero { get; set; }

        /// <summary>
        /// Gets or sets propiedad Febrero.
        /// </summary>
        [JsonPropertyOrder(3)]
        public decimal Febrero { get; set; }

        /// <summary>
        /// Gets or sets propiedad Marzo.
        /// </summary>
        [JsonPropertyOrder(4)]
        public decimal Marzo { get; set; }

        /// <summary>
        /// Gets or sets propiedad Abril.
        /// </summary>
        [JsonPropertyOrder(5)]
        public decimal Abril { get; set; }

        /// <summary>
        /// Gets or sets propiedad Mayo.
        /// </summary>
        [JsonPropertyOrder(6)]
        public decimal Mayo { get; set; }

        /// <summary>
        /// Gets or sets propiedad Junio.
        /// </summary>
        [JsonPropertyOrder(7)]
        public decimal Junio { get; set; }

        /// <summary>
        /// Gets or sets propiedad Julio.
        /// </summary>
        [JsonPropertyOrder(8)]
        public decimal Julio { get; set; }

        /// <summary>
        /// Gets or sets propiedad Agosto.
        /// </summary>
        [JsonPropertyOrder(9)]
        public decimal Agosto { get; set; }

        /// <summary>
        /// Gets or sets propiedad Septiembre.
        /// </summary>
        [JsonPropertyOrder(10)]
        public decimal Septiembre { get; set; }

        /// <summary>
        /// Gets or sets propiedad Octubre.
        /// </summary>
        [JsonPropertyOrder(11)]
        public decimal Octubre { get; set; }

        /// <summary>
        /// Gets or sets propiedad Noviembre.
        /// </summary>
        [JsonPropertyOrder(12)]
        public decimal Noviembre { get; set; }

        /// <summary>
        /// Gets or sets propiedad Diciembre.
        /// </summary>
        [JsonPropertyOrder(13)]
        public decimal Diciembre { get; set; }

        /// <summary>
        /// Gets or sets propiedad Año.
        /// </summary>
        [JsonPropertyOrder(14)]
        public int Ano { get; set; }
    }
}