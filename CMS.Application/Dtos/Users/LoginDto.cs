﻿namespace CMS.Application.Dtos.Users;

public class LoginDto
{
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
}
