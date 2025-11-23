namespace PersonalFinanceApiNetCore.Controllers
{
    using System.Net.Mime;
    using Microsoft.AspNetCore.Mvc;
    using PersonalFinanceApiNetCoreBL;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// EntidadesController.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [UserSystemTextJsonAttribute]
    public class EntidadesController : ControllerBase
    {
        private readonly ILogger<EntidadesController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntidadesController"/> class.
        /// </summary>
        /// <param name="logger">ILogger.</param>
        public EntidadesController(ILogger<EntidadesController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// GetAll.
        /// </summary>
        /// <returns>GeneralResponse.</returns>
        [Produces("application/json")]
        [HttpGet(Name = "entidades")]
        public GeneralResponse GetAll()
        {
            List<Entidad> entidades = new EntidadesBL().GetAll();

            var response = new GeneralResponse()
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

            return response;
        }
    }
}
