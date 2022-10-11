using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFramework.MVC.Models.Entities
{
    public class Novel
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }
    }
}