﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [StringLength(100)]
        public string  CategoryName { get; set; }
        [StringLength(100)]
        public string CategoryDescription { get; set; }
        [StringLength(100)]
        public string? CategoryStatus { get; set; }


        //Navigation Properties
        public virtual ICollection<Header> Headers { get; set; }   
    }
}
