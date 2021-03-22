using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSnack.Models
{
    public class SnackTypeViewModel
    {
        public List<Snack> Snacks { get; set; }
        public SelectList Types { get; set; }
        public string SnackType { get; set; }
        public string SearchString { get; set; }
    }
}
