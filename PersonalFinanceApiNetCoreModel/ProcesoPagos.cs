namespace PersonalFinanceApiNetCoreModel
{
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.

    using System.Text.Json.Serialization;

    /// <summary>
    /// Clase ProcesoPagos.
    /// </summary>
    public class ProcesoPagos
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProcesoPagos"/> class.
        /// </summary>
        public ProcesoPagos()
        {
        }

        /// <summary>
        /// Gets or sets propiedad TipoGasto.
        /// </summary>
        public int TipoGasto { get; set; }

        /// <summary>
        /// Gets or sets propiedad Mes.
        /// </summary>
        public int Mes { get; set; }

        /// <summary>
        /// Gets or sets propiedad NombreMes.
        /// </summary>
        public string NombreMes { get; set; }

        /// <summary>
        /// Gets or sets propiedad Total.
        /// </summary>
        public decimal Total { get; set; }
    }
}