namespace PersonalFinanceApiNetCore.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PersonalFinanceApiNetCoreBL;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// ServiciosController.
    /// </summary>
    [ApiController]
    [Route("api/v1/servicios")]
    [UserSystemTextJsonAttribute]
    public class ServiciosController : ControllerBase
    {
        private readonly ILogger<ServiciosController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiciosController"/> class.
        /// </summary>
        /// <param name="logger">ILogger.</param>
        public ServiciosController(ILogger<ServiciosController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// GetAll.
        /// </summary>
        /// <returns>GeneralResponse.</returns>
        [Produces("application/json")]
        [HttpGet("getall")]
        public GeneralResponse GetAll()
        {
            List<Servicio> entidades = new ServiciosBL().GetAll();

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

        /// <summary>
        /// GetId.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>GeneralResponse.</returns>
        [Produces("application/json")]
        [HttpGet("get/{id}")]
        public GeneralResponse GetId(int id)
        {
            List<Servicio> entidades = new ServiciosBL().GetId(id);

            var response = new GeneralResponse()
            {
                Meta = new Meta()
                {
                    Metodo = "post",
                    Operacion = "get/{id}",
                    Recurso = string.Empty,
                },
                Data = entidades,
            };

            return response;
        }

        /// <summary>
        /// AddEntity.
        /// </summary>
        /// <param name="parametros">Parametro lista.</param>
        /// <returns>GeneralResponse.</returns>
        [Produces("application/json")]
        [HttpPut("create")]
        public GeneralResponse AddEntity([FromBody] List<Parametro> parametros)
        {
           long entidades = new ServiciosBL().AddUpdateEntity("create", parametros);

           var response = new GeneralResponse()
            {
                Meta = new Meta()
                {
                    Metodo = "post",
                    Operacion = "create",
                    Recurso = string.Empty,
                },
                Data = entidades,
            };

           return response;
        }

        /// <summary>
        /// AddEntity.
        /// </summary>
        /// <param name="parametros">Parametro lista.</param>
        /// <returns>GeneralResponse.</returns>
        [Produces("application/json")]
        [HttpPut("update")]
        public GeneralResponse UpdateEntity([FromBody] List<Parametro> parametros)
        {
            long entidades = new ServiciosBL().AddUpdateEntity("update", parametros);

            var response = new GeneralResponse()
            {
                Meta = new Meta()
                {
                    Metodo = "post",
                    Operacion = "update",
                    Recurso = string.Empty,
                },
                Data = entidades,
            };

            return response;
        }
    }
}
