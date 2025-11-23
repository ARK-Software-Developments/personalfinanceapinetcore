

namespace PersonalFinanceApiNetCore.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using PersonalFinanceApiNetCoreBL;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// EntidadesController.
    /// </summary>
    [ApiController]
    [Route("api/v1/entities")]
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
        [HttpGet("getall")]
        public GeneralResponse GetAll()
        {
            List<Entidad> entidades = new EntidadesBL().GetAll();

            var response = new GeneralResponse()
            {
                Meta = new Meta()
                {
                    Metodo = "get",
                    Operacion = "GetAll",
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
            List<Entidad> entidades = new EntidadesBL().GetId(id);

            var response = new GeneralResponse()
            {
                Meta = new Meta()
                {
                    Metodo = "post",
                    Operacion = "GetId",
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
           long entidades = new EntidadesBL().AddUpdateEntity("create", parametros);

           var response = new GeneralResponse()
            {
                Meta = new Meta()
                {
                    Metodo = "post",
                    Operacion = "GetId",
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
            long entidades = new EntidadesBL().AddUpdateEntity("update", parametros);

            var response = new GeneralResponse()
            {
                Meta = new Meta()
                {
                    Metodo = "post",
                    Operacion = "GetId",
                    Recurso = string.Empty,
                },
                Data = entidades,
            };

            return response;
        }
    }
}
