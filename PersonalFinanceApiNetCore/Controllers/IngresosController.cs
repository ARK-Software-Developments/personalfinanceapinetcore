namespace PersonalFinanceApiNetCore.Controllers
{
#pragma warning disable CS8625
#pragma warning disable SA1309
#pragma warning disable SA1009

    using Microsoft.AspNetCore.Mvc;
    using PersonalFinanceApiNetCoreBL;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// IngresosController.
    /// </summary>
    [ApiController]
    [Route("api/v1/income")]
    [UserSystemTextJsonAttribute]
    public class IngresosController(ILogger<IngresosController> logger) : ControllerBase
    {
        private readonly ILogger<IngresosController> _logger = logger;

        /// <summary>
        /// GetAll.
        /// </summary>
        /// <param name="ano">Año de ejercicio.</param>
        /// <returns>GeneralResponse.</returns>
        [Produces("application/json")]
        [HttpGet("getall/{ano}")]
        public GeneralResponse GetAll(int ano)
        {
            List<Ingreso> entidades = new IngresosBL().GetAllByYear(ano);

            var response = new GeneralResponse()
            {
                Meta = new Meta()
                {
                    Metodo = "get",
                    Operacion = "getallbyyear",
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
            List<Ingreso> entidades = new IngresosBL().GetId(id);

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
           var entidades = new IngresosBL().AddUpdateEntity("create", parametros);

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
            var entidades = new IngresosBL().AddUpdateEntity("update", parametros);

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
        [HttpPut("copymonthlyincome")]
        public GeneralResponse CopiarIngresoMensual([FromBody] List<Parametro> parametros)
        {
            var entidades = new IngresosBL().CopyMonthIncome(parametros);

            var response = new GeneralResponse()
            {
                Meta = new Meta()
                {
                    Metodo = "put",
                    Operacion = "copymonthlyincome",
                    Recurso = string.Empty,
                },
                Data = entidades,
            };

            return response;
        }
    }
}
