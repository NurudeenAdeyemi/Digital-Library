using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class UserUpdateDTO
    {
        public AccountStatus Status { get; set; }

        public UserType UserType { get; set; }
    }
}
