using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_regisztraciosLap
{
     class adat
    {
        

        public string Nev { get; set; }
        public string Email { get; set; }
        public string Jelszo { get; set; }

        public adat(string nev, string email, string jelszo)
        {
            Nev = nev;
            Email = email;
            Jelszo = jelszo;
        }

    }
}
