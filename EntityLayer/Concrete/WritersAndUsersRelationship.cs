﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class WritersAndUsersRelationship
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int? WritersId { get; set; }
    }
}
