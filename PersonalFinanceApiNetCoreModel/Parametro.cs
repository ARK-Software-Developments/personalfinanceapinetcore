namespace PersonalFinanceApiNetCoreModel
{
    /// <summary>
    /// Clase Parametros.
    /// </summary>
    public class Parametro
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parametro"/> class.
        /// </summary>
        public Parametro()
        {
        }

        // <inheritdoc/>
        public string Nombre { get; set; }

        // <inheritdoc/>
        public object Valor { get; set; }
    }
}