using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models
{   
    public partial class M_RESTAURANT
    {
        public int Id { get; set; }
        public string Restaurant_Name { get; set; }
        public string Location { get; set; }
        public Nullable<int> Category_Id { get; set; }
        public string City { get; set; }
        public string Cuisine { get; set; }
    }
}