using Blog.Data.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Entity
{
    public class Departman : AuditEntity
    {
        [Key]
        public int Id { get; set; }

        public string Tanim { get; set; }

        public string Aciklama { get; set; }
    }
}
