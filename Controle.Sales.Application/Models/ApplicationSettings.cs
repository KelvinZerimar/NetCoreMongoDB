using System;
using System.Collections.Generic;
using System.Text;

namespace Application.App.Models
{
    public class ApplicationSettings
    {
        public string JwtSecret { get; set; }
        public string ClientUrl { get; set; }
    }
}
