﻿using System.ComponentModel.DataAnnotations;

namespace MVC04.ViewModels.RoleViewModels
{
    public class RoleViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Role Name is required")]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }

}
