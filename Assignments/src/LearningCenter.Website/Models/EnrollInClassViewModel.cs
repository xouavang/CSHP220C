using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningCenter.Website.Models
{
    public class EnrollInClassViewModel
    {
        [Required(ErrorMessage ="Please select a course")]
        public int SelectedClassId { get; set; }
        public IEnumerable<SelectListItem> AvailableClasses { get; set; }
    }
}