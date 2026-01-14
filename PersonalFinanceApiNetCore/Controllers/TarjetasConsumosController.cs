namespace PersonalFinanceApiNetCore.Controllers
{
#pragma warning disable CS8625
#pragma warning disable SA1309
#pragma warning disable SA1009

    using Microsoft.AspNetCore.Mvc;
    using PersonalFinanceApiNetCoreBL;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// TarjetasConsumosController.
    /// </summary>
    [ApiController]
    [Route("api/v1/creditcardspending")]
    [UserSystemTextJsonAttribute]
    public class TarjetasConsumosController(ILogger<TarjetasConsumosController> logger) : ControllerBase
    {
        private readonly ILogger<TarjetasConsumosController> _logger = logger;

        /// <summary>
        /// GetAll.
        /// </summary>
        /// <param name="ano">Año de ejercicio.</param>
        /// <returns>GeneralResponse.</returns>
        [Produces("application/json")]
        [HttpGet("getall/{ano}")]
        public GeneralResponse GetAll(int ano)
        {
            List<TarjetaConsumo> entidades = new TarjetasConsumosBL().GetAllByYear(ano);

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
            List<TarjetaConsumo> entidades = new TarjetasConsumosBL().GetId(id);

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
        /// GetId.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>GeneralResponse.</returns>
        [Produces("application/json")]
        [HttpPost("resumenbycard/")]
        public GeneralResponse ResumenByCard([FromBody] List<Parametro> parametros)
        {
            List<TarjetaConsumoResumen> lstTarjetaConsumoResumen = new TarjetasConsumosBL().GetResumenByCardId(parametros);

            var response = new GeneralResponse()
            {
                Meta = new Meta()
                {
                    Metodo = "post",
                    Operacion = "resumenbycard/",
                    Recurso = string.Empty,
                },
                Data = lstTarjetaConsumoResumen,
            };

            return response;
        }

        /// <summary>
        /// GetId.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>GeneralResponse.</returns>
        [Produces("application/json")]
        [HttpPost("resumenbyyear/")]
        public GeneralResponse ResumenByYear([FromBody] List<Parametro> parametros)
        {
            List<TarjetaConsumoResumen> lstTarjetaConsumoResumen = new TarjetasConsumosBL().GetResumenByYear(parametros);

            var response = new GeneralResponse()
            {
                Meta = new Meta()
                {
                    Metodo = "post",
                    Operacion = "resumenbyyear/",
                    Recurso = string.Empty,
                },
                Data = lstTarjetaConsumoResumen,
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
           var entidades = new TarjetasConsumosBL().AddUpdateEntity("create", parametros);

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
            var entidades = new TarjetasConsumosBL().AddUpdateEntity("update", parametros);

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
