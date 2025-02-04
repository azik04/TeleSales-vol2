﻿using TeleSales.DataProvider.Enums;

namespace TeleSales.Core.Dto.Main.User;

public class CreateUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

}
