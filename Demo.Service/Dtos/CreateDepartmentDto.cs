﻿namespace Demo.Service.Dtos
{
    public class CreateDepartmentDto
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateOfCreation { get; set; }
    }
}
