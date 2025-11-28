namespace PersonalFinanceApiNetCoreModel
{
#pragma warning disable CS8618
#pragma warning disable SA1623

    using System.Text.Json.Serialization;

    /// <summary>
    /// Clase Menu.
    /// </summary>
    public class Menu : AbstractModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        public Menu()
        {
        }

        /// <summary>
        /// Gets or sets propiedad Titulo.
        /// </summary>
        [JsonPropertyOrder(3)]
        public string Titulo { get; set; }

        /// <summary>
        /// Gets or sets propiedad Accion.
        /// </summary>
        [JsonPropertyOrder(4)]
        public string Accion { get; set; }

        /// <summary>
        /// Gets or sets propiedad Nivel.
        /// </summary>
        [JsonPropertyOrder(5)]
        public int Nivel { get; set; }

        /// <summary>
        /// Gets or sets propiedad ParentId.
        /// </summary>
        [JsonPropertyOrder(6)]
        public int ParentId { get; set; }

        /// <summary>
        /// Gets or sets propiedad Pagado.
        /// </summary>
        [JsonPropertyOrder(7)]
        public List<SubMenu> SubMenu { get; set; }
    }
}