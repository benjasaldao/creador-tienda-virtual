﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string recoveryToken { get; set; }
        private bool admin {  get; set; }
        public bool isAdmin() { return admin; }
    }
}
