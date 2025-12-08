namespace PersonalFinanceApiNetCoreBL
{
#pragma warning disable SA1010

    using PersonalFinanceApiNetCoreDataMapper;
    using PersonalFinanceApiNetCoreModel;

    /// <summary>
    /// Clase MenuBL.
    /// </summary>
    public class MenusBL
    {
        private MenusDataMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenusBL"/> class.
        /// </summary>
        public MenusBL()
        {
            this.mapper = new ();
        }

        /// <summary>
        /// Método para obtener todos los registros de la categorias.
        /// </summary>
        /// <returns>Lista de categorias.</returns>
        public List<Menu> GetAll()
        {
            List<Menu> lstMenues = [];

            var menuPricipal = this.mapper.GetAll<Menu>();

            lstMenues = [.. menuPricipal];

            for (int i = 0; i < lstMenues.Count; i++)
            {
                var subMenues = this.mapper.GetAll<Menu>(lstMenues[i].Id);

                lstMenues[i].SubMenu = [];

                foreach (var subMenu in subMenues)
                {
                    lstMenues[i].SubMenu.Add(
                        new SubMenu()
                        {
                            Id = subMenu.Id,
                            Accion = subMenu.Accion,
                            Nivel = subMenu.Nivel,
                            Nombre = subMenu.Nombre,
                            Titulo = subMenu.Titulo,
                        });
                }
            }

            return lstMenues;
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="id">Id del registro.</param>
        /// <returns>Lista de entida.</returns>
        public List<Menu> GetId(int id)
        {
            return this.mapper.GetId<Menu>(id);
        }

        /// <summary>
        /// Método para obtener un solo registro.
        /// </summary>
        /// <param name="operacion">Operacion Create/Update.</param>
        /// <param name="parametros">Informacion a agregar/actualizar.</param>
        /// <returns>Lista de entida.</returns>
        public long AddUpdateEntity(string operacion, List<Parametro> parametros)
        {
            if (operacion == "create")
            {
                return this.mapper.AddEntity(parametros);
            }
            else
            {
                return this.mapper.UpdateEntity(parametros);
            }
        }
    }
}