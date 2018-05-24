using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DabaiNA.Modes
{
    public class AuthorizationMode
    {

        public string AppId { get; set; }

        public string Scope { get; set; }
        public string TokenType { get; set; }
        public Int32 ExpiresIn { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

    }
}
