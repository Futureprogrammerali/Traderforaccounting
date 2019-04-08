using System;
using System.Collections.Generic;

using System.Text;
using System.Data.Common;
using System.Data;

namespace WeightsOrganizer.DAL
{
    /// <summary>
    /// توفير اجرائيات الأوامر SIUD
    /// </summary>
    public abstract class BaseData
    {
        private string _ConnectionString = "";
        protected string ConnectionString
        {
            get
            {
                return _ConnectionString;
            }
            set
            {
                _ConnectionString = value;
            }
        }
        protected int ExuteNonQuery(DbCommand cmd)
        {

       return cmd.ExecuteNonQuery();

        }
        protected IDataReader ExecuteReader(DbCommand cmd)
        {
            return ExecuteReader(cmd, CommandBehavior.Default);
        }
        protected IDataReader ExecuteReader(DbCommand cmd, CommandBehavior commandBehavior)
        {
        return cmd.ExecuteReader(commandBehavior);
        }   
        protected object ExecuteScalar(DbCommand cmd)
        {
            return cmd.ExecuteScalar();
        }
    }
}
