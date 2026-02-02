namespace PersonalFinanceApiNetCore.Controllers
{
#pragma warning disable CS8625
#pragma warning disable SA1309
#pragma warning disable SA1009

    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using PersonalFinanceApiNetCoreBL;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// PedidosController.
    /// </summary>
    [EnableCors("CorsPolicy")]
    [ApiController]
    [Route("api/v1/investments")]
    [UserSystemTextJsonAttribute]
    public class InversionesController(ILogger<InversionesController> logger) : ControllerBase
    {
        private readonly ILogger<InversionesController> _logger = logger;

        /// <summary>
        /// GetAll.
        /// </summary>
        /// <returns>GeneralResponse.</returns>
        [HttpGet("getall")]
        public GeneralResponse GetAll()
        {
            List<Inversion> entidades = new InversionesBL().GetAll();

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
        [HttpGet("get/{id}")]
        public GeneralResponse GetId(int id)
        {
            List<Inversion> entidades = new InversionesBL().GetId(id);

            var response = new GeneralResponse()
            {
                Meta = new Meta()
                {
                    Metodo = "get",
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
        [HttpPut("create")]
        public GeneralResponse AddEntity([FromBody] List<Parametro> parametros)
        {
           var entidades = new InversionesBL().AddUpdateEntity("create", parametros);

           var response = new GeneralResponse()
            {
                Meta = new Meta()
                {
                    Metodo = "put",
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
        [HttpPost("update")]
        public GeneralResponse UpdateEntity([FromBody] List<Parametro> parametros)
        {
            var entidades = new InversionesBL().AddUpdateEntity("update", parametros);

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
