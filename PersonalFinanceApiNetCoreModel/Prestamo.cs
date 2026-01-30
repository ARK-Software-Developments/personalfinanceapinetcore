using System.Text.Json.Serialization;

namespace PersonalFinanceApiNetCoreModel
{
    /// <summary>
    /// Clase Prestamo.
    /// </summary>
    public class Prestamo : AbstractModelExternder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Prestamo"/> class.
        /// </summary>
        public Prestamo()
        {
        }

        /// <summary>
        /// Gets or sets propiedad Beneficiario.
        /// </summary>
        [JsonPropertyOrder(2)]
        public string? Beneficiario { get; set; }

        /// <summary>
        /// Gets or sets propiedad FechaDeposito.
        /// </summary>
        [JsonPropertyOrder(3)]
        public DateTime? FechaDeposito { get; set; }

        /// <summary>
        /// Gets or sets propiedad Resumen.
        /// </summary>
        [JsonPropertyOrder(4)]
        public string? Resumen { get; set; }

        /// <summary>
        /// Gets or sets propiedad Razon.
        /// </summary>
        [JsonPropertyOrder(5)]
        public string? Razon { get; set; }

        /// <summary>
        /// Gets or sets propiedad TotalCapital.
        /// </summary>
        [JsonPropertyOrder(6)]
        public decimal TotalCapital { get; set; }

        /// <summary>
        /// Gets or sets propiedad TotalDeuda.
        /// </summary>
        [JsonPropertyOrder(7)]
        public decimal TotalDeuda { get; set; }

        /// <summary>
        /// Gets or sets propiedad Cuotas.
        /// </summary>
        [JsonPropertyOrder(8)]
        public int Cuotas { get; set; }

        /// <summary>
        /// Gets or sets propiedad Estado.
        /// </summary>
        [JsonPropertyOrder(9)]
        public string Estado { get; set; }
    }
}