﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TasksManager.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
    }
}