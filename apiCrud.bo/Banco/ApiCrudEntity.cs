namespace apiCrud.bo.Banco
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ApiCrudEntity : DbContext
    {
        public ApiCrudEntity()
            : base("name=ApiCrudEntity")
        {
        }

        public virtual DbSet<pessoa> pessoa { get; set; }

    }
}
