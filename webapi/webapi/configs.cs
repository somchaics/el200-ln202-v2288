using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi
{
    public class configs
    {
        public static string connectString
        {
            get
            {
                return "Data Source = wnl; Initial Catalog = ELDB;User ID=sa;Password=Sa12345@";
            }
        }

    }
}