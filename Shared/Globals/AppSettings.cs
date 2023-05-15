using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using Microsoft.Extensions.Configuration;
using Nest;
using SharedModels;
using Microsoft.EntityFrameworkCore;

namespace Globals
{
    public class AppSettings
    {
        public static string db_connection_string;
        public static ServerVersion db_version;
    }
}
