

using DemoSession3.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.module.Department
{
    
    public class Department : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public int LastModifiedBy { get; set; };
        public object createdBy { get; internal set; }
    }
}