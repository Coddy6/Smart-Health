using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.mysql
{
        public class Usuarios
        {
            public string id { get; set; }
            public string password { get; set; }

            public Usuarios() { }
            public Usuarios(string id, string password)
            {
                this.id = id;
                this.password = password;
            }
        }
}
