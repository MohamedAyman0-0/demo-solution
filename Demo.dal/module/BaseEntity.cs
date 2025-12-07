using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.dal.module
{
    public class BaseEntity
    {
            public int Id { get; set; } //pk
        

        public int createdBy { get; set; }    
        public  DateTime CreatedOn { get; set; } 
        public int LastModifyBy { get; set; }   
        public DateTime LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }

    }
}
