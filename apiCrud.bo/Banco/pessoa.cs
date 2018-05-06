namespace apiCrud.bo.Banco
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pessoa")]
    public partial class pessoa
    {
        public Guid id { get; set; }

        [StringLength(50)]
        public string nome { get; set; }

        [StringLength(50)]
        public string telefone { get; set; }

        [StringLength(50)]
        public string Nascimento { get; set; }

        [StringLength(50)]
        public string CPF { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(50)]
        public string RG { get; set; }

        [StringLength(50)]
        public string Cep { get; set; }

        [StringLength(50)]
        public string Sexo { get; set; }

        [StringLength(50)]
        public string idade { get; set; }
    }
}
