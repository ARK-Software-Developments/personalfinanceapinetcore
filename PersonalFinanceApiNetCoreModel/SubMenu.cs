namespace PersonalFinanceApiNetCoreModel
{
#pragma warning disable CS8618
#pragma warning disable SA1623

    using System.Text.Json.Serialization;

    /// <summary>
    /// Clase SubMenu.
    /// </summary>
    public class SubMenu : AbstractModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubMenu"/> class.
        /// </summary>
        public SubMenu()
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
    }
}