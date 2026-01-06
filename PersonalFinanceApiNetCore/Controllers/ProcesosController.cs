namespace PersonalFinanceApiNetCore.Controllers
{
#pragma warning disable CS8625
#pragma warning disable SA1309
#pragma warning disable SA1009

    using Microsoft.AspNetCore.Mvc;
    using PersonalFinanceApiNetCoreBL;
    using PersonalFinanceApiNetCoreBL.Procesos;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// ProcesosController.
    /// </summary>
    [ApiController]
    [Route("api/v1/process")]
    [UserSystemTextJsonAttribute]
    public class ProcesosController(ILogger<ProcesosController> logger) : ControllerBase
    {
        private readonly ILogger<ProcesosController> _logger = logger;

        /// <summary>
        /// AddEntity.
        /// </summary>
        /// <param name="parametros">Parametro lista.</param>
        /// <returns>GeneralResponse.</returns>
        [Produces("application/json")]
        [HttpPut("paymentsrecorded")]
        public GeneralResponse IniciarProcesoPagos([FromBody] List<Parametro> parametros)
        {
            int ano = int.Parse(parametros.Find(p => p.Nombre == "pYear").Valor.ToString());

            new ProcesoBalanceBL().IniciarProcesoPagos(ano);

            var response = new GeneralResponse()
            {
                Meta = new Meta()
                {
                    Metodo = "post",
                    Operacion = "update",
                    Recurso = string.Empty,
                },
                Data = new List<object>() { true },
            };

            return response;
        }
    }
}
