using System;

namespace ORM_Test_Repository_FreeSQL
{
    public class FreeSqlFactory
    {

        /// <summary>
        /// 当前线程的数据库连接
        /// </summary>
        [ThreadStatic]
        private static IFreeSql _currentDb = null;

        /// <summary>
        /// 获取数据库
        /// </summary>
        /// <returns></returns>
        public static IFreeSql GetDbContext()
        {
            if (_currentDb != null) 
                return _currentDb;
            IFreeSql db = new FreeSql.FreeSqlBuilder()
                .UseConnectionString(FreeSql.DataType.MySql, "Database=orm_test;Data Source=localhost;Port=3306;User Id=root;Password=123456w.;Charset=utf8;")
                //.UseAutoSyncStructure(false)
                //.UseNoneCommandParameter(true)
                //.UseConfigEntityFromDbFirst(true)
                .Build();
            _currentDb = db;
            return db;
        }
    }
}
