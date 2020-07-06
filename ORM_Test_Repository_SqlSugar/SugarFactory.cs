using SqlSugar;
using System;

namespace ORM_Test_Repository_SqlSugar
{
    public class SugarFactory : IDisposable
    {
        /// <summary>
        /// 当前线程的数据库连接
        /// </summary>
        [ThreadStatic]
        private static SqlSugarClient _currentDb = null;
        private bool disposedValue;

        /// <summary>
        /// 获取数据库
        /// </summary>
        /// <returns></returns>
        public static SqlSugarClient GetDbContext()
        {
            if (_currentDb != null) return _currentDb;
            SqlSugarClient db = new SqlSugarClient(
            new ConnectionConfig()
            {
                ConnectionString = "Database=orm_test;Data Source=localhost;Port=3306;User Id=root;Password=123456w.;Charset=utf8;",
                DbType = DbType.MySql,//设置数据库类型
                IsAutoCloseConnection = true,//自动释放数据务，如果存在事务，在事务结束后释放
                InitKeyType = InitKeyType.Attribute //从实体特性中读取主键自增列信息
            });
            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                //Console.WriteLine(sql);
            };
            _currentDb = db;
            return db;
        }

        /// <summary>
        /// 开启事务
        /// </summary>
        public static void BeginTran()
        {
            GetDbContext().Ado.BeginTran();
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public static void CommitTran()
        {
            GetDbContext().Ado.CommitTran();
        }

        /// <summary>
        /// 事务回滚
        /// </summary>
        public static void RollbackTran()
        {
            GetDbContext().Ado.RollbackTran();
        }

        /// <summary>
        /// 关闭数据库
        /// </summary>
        public static void CloseDb()
        {
            if (_currentDb == null) return;
            try
            {
                _currentDb.Close();
                _currentDb = null;
            }
            catch { }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)
                }

                // TODO: 释放未托管的资源(未托管的对象)并替代终结器
                // TODO: 将大型字段设置为 null
                disposedValue = true;
            }
        }

        // // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
        // ~SugarFactory()
        // {
        //     // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
