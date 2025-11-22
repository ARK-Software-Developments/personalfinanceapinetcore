namespace PersonalFinanceApiNetCore.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// EntidadesController.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EntidadesController : ControllerBase
    {
        private readonly ILogger<EntidadesController> _logger;

        public EntidadesController(ILogger<EntidadesController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// GetAll.
        /// </summary>
        /// <returns>GeneralResponse.</returns>
        [HttpGet(Name = "GetEntidades")]
        public GeneralResponse GetAll()
        {
            List<Entidad> entidades =[
                new Entidad()
                {

                Id = 0,
                Nombre = "nombre entidad",
                Tipo ="et",
                }

                ];

            return new GeneralResponse()
            {
                Meta = new Meta()
                {
                    Metodo = "get",
                    Operacion = "getEntidades",
                    Recurso = string.Empty,
                },
                Errores = null,
                Data = entidades,
            };
        }
    }
}
