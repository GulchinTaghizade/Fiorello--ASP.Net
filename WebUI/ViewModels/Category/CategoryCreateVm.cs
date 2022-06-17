using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewModels.Categories
{
    public class CategoryCreateVm
    {
        [Required]
        public string Name { get; set; }
    }
}
