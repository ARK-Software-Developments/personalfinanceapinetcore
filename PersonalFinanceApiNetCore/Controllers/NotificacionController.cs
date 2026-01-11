namespace PersonalFinanceApiNetCore.Controllers
{
#pragma warning disable CS8625
#pragma warning disable SA1309
#pragma warning disable SA1009

    using Microsoft.AspNetCore.Mvc;
    using PersonalFinanceApiNetCoreBL;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// NotificacionController.
    /// </summary>
    [ApiController]
    [Route("api/v1/notifications")]
    [UserSystemTextJsonAttribute]
    public class NotificacionController(ILogger<NotificacionController> logger) : ControllerBase
    {
        private readonly ILogger<NotificacionController> _logger = logger;

        /// <summary>
        /// GetAll.
        /// </summary>
        /// <param name="ano">Año de ejercicio.</param>
        /// <returns>GeneralResponse.</returns>
        [Produces("application/json")]
        [HttpGet("getall")]
        public GeneralResponse GetAll(int ano)
        {
            List<Notificacion> entidades = new NotificacionesBL().GetAll();

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
