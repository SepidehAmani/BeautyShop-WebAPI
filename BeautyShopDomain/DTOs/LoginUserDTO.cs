﻿using System.ComponentModel.DataAnnotations;

namespace BeautyShopDomain.DTOs;

public class LoginUserDTO
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
