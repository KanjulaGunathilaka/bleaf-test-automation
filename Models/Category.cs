﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bleaf_test_automation.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static implicit operator RestResponse(Category v)
        {
            throw new NotImplementedException();
        }
    }
}
