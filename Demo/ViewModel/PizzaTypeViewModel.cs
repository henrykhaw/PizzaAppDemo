using System.Collections.Generic;
using System.Web.Mvc;

namespace Demo.Models
{
    public class PizzaTypeViewModel
    {
        public string Name { get; set; }

        public IEnumerable<SelectListItem> PizzaTypesList { get; set; }
    }
}