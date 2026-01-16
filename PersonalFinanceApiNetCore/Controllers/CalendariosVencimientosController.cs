namespace PersonalFinanceApiNetCore.Controllers
{
#pragma warning disable CS8625
#pragma warning disable SA1309
#pragma warning disable SA1009

    using Microsoft.AspNetCore.Mvc;
    using PersonalFinanceApiNetCoreBL;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// CalendariosVencimientosController.
    /// </summary>
    [ApiController]
    [Route("api/v1/duedatesschedules")]
    [UserSystemTextJsonAttribute]
    public class CalendariosVencimientosController(ILogger<CalendariosVencimientosController> logger) : ControllerBase
    {
        private readonly ILogger<CalendariosVencimientosController> _logger = logger;

        /// <summary>
        /// GetAll.
        /// </summary>
        /// <param name="ano">Año de ejercicio.</param>
        /// <returns>GeneralResponse.</returns>
        [Produces("application/json")]
        [HttpGet("getall")]
        public GeneralResponse GetAll()
        {
            List<CalendarioVencimiento> entidades = new CalendariosVencimientosBL().GetAll();

            var response = new GeneralResponse()
            {
                Meta = new Meta()
                {
                    Metodo = "get",
                    Operacion = "getall",
                    Recurso = string.Empty,
                },
                Errores = null,
                Data = entidades,
            };

            return response;
        }

    }
}
