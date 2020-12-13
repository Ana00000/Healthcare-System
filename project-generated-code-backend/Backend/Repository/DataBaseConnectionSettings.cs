﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinicBackend.Backend.Repository
{
    public class DataBaseConnectionSettings
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Database { get; set; }
        public int RetryCount { get; set; }
        public int RetryWaitInSeconds { get; set; }

        public string ConnectionString
        {
            get => $"server={Host} ;userid={User}; pwd={Password};"
                   + $"port={Port}; database={Database}";
        }
    }
}
