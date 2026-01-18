namespace PersonalFinanceApiNetCore.Controllers
{
#pragma warning disable CS8625
#pragma warning disable SA1309
#pragma warning disable SA1009

    using Microsoft.AspNetCore.Mvc;
    using PersonalFinanceApiNetCoreBL;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// GastosController.
    /// </summary>
    [ApiController]
    [Route("api/v1/bills")]
    [UserSystemTextJsonAttribute]
    public class GastosController(ILogger<GastosController> logger) : ControllerBase
    {
        private readonly ILogger<GastosController> _logger = logger;

        /// <summary>
        /// GetAll.
        /// </summary>
        /// <param name="ano">Año de ejercicio.</param>
        /// <returns>GeneralResponse.</returns>
        [Produces("application/json")]
        [HttpGet("getall/{ano}")]
        public GeneralResponse GetAll(int ano)
        {
            List<Gasto> entidades = new GastosBL().GetAllByYear(ano);

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
            List<Gasto> entidades = new GastosBL().GetId(id);

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
           var entidades = new GastosBL().AddUpdateEntity("create", parametros);

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
        [HttpPost("update")]
        public GeneralResponse UpdateEntity([FromBody] List<Parametro> parametros)
        {
            var entidades = new GastosBL().AddUpdateEntity("update", parametros);

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

        /// <summary>
        /// AddEntity.
        /// </summary>
        /// <param name="parametros">Parametro lista.</param>
        /// <returns>GeneralResponse.</returns>
        [Produces("application/json")]
        [HttpPut("copymonthlyexpense")]
        public GeneralResponse CopiarPresupuestoMensual([FromBody] List<Parametro> parametros)
        {
            var entidades = new GastosBL().BillsCopyMonth(parametros);

            var response = new GeneralResponse()
            {
                Meta = new Meta()
                {
                    Metodo = "put",
                    Operacion = "copymonthlyexpense",
                    Recurso = string.Empty,
                },
                Data = entidades,
            };

            return response;
        }
    }
}
