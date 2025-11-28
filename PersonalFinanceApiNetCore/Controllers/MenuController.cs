namespace PersonalFinanceApiNetCore.Controllers
{
#pragma warning disable CS8625
#pragma warning disable SA1309
#pragma warning disable SA1009

    using Microsoft.AspNetCore.Mvc;
    using PersonalFinanceApiNetCoreBL;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// MenuController.
    /// </summary>
    [ApiController]
    [Route("api/v1/menus")]
    [UserSystemTextJsonAttribute]
    public class MenuController(ILogger<MenuController> logger) : ControllerBase
    {
        private readonly ILogger<MenuController> _logger = logger;

        /// <summary>
        /// GetAll.
        /// </summary>
        /// <returns>GeneralResponse.</returns>
        [Produces("application/json")]
        [HttpGet("getall")]
        public GeneralResponse GetAll()
        {
            List<Menu> entidades = new MenusBL().GetAll();

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
            List<Menu> entidades = new MenusBL().GetId(id);

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
           long entidades = new MenusBL().AddUpdateEntity("create", parametros);

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
            long entidades = new MenusBL().AddUpdateEntity("update", parametros);

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
