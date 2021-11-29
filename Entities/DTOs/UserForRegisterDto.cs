﻿using Core.Entities;

namespace Entities.DTOs
{
    public class UserForRegisterDto:IDto
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
