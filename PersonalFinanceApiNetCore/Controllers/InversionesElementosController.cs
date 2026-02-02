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
    [Route("api/v1/investmentselements")]
    [UserSystemTextJsonAttribute]
    public class InversionesElementosController(ILogger<InversionesElementosController> logger) : ControllerBase
    {
        private readonly ILogger<InversionesElementosController> _logger = logger;

        /// <summary>
        /// GetAll.
        /// </summary>
        /// <returns>GeneralResponse.</returns>
        [HttpGet("getall")]
        public GeneralResponse GetAll()
        {
            List<InversionElemento> entidades = new InversionesElementosBL().GetAll();

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
        /// GetAll.
        /// </summary>
        /// <param name="investmentId">Id de inversion.</param>
        /// <returns>GeneralResponse.</returns>
        [HttpGet("getall/{investmentId}")]
        public GeneralResponse GetAllByInvestmentId(int investmentId)
        {
            List<InversionElemento> entidades = new InversionesElementosBL().GetAllByInvestmentId(investmentId);

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
            List<InversionElemento> entidades = new InversionesElementosBL().GetId(id);

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
           var entidades = new InversionesElementosBL().AddUpdateEntity("create", parametros);

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
            var entidades = new InversionesElementosBL().AddUpdateEntity("update", parametros);

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
