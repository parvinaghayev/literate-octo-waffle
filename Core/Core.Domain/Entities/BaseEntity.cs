using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public BaseEntity()
        {
        }

        public BaseEntity(int id, DateTime createDate)
        {
            Id = id;
            CreateDate = createDate;
        }
    }
}