using DabaiNA.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DabaiNA.DAL
{
    class DeviceManageDAL
    {

        public static DataTable GetBuildInfo()
        {
            string SQLString = @"SELECT  F_BuildID,F_BuildName
                                FROM T_BD_BuildBaseInfo";

            DataTable dt = SQLHelper.GetDataTable(SQLString);
            return dt;
        }
    }
}
