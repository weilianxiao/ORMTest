using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using ORM_Test.IWorker;
using ORM_Test_Common;
using ORM_Test_Model;
using ORM_Test_Repository_EFCore;
using ORM_Test_Repository_FreeSQL;
using ORM_Test_Repository_SqlSugar;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;

namespace ORM_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertTest();
            //QueryTest();


            TestMysql();
        }

        /// <summary>
        /// 插入测试
        /// </summary>
        static void InsertTest()
        {
            var stopwatch = new Stopwatch();

            var freeSql = FreeSqlFactory.GetDbContext();
            var sugarUserRepository = new SugarUserRepository();

            #region 非事务插入

            //#region 单条数据
            //var user = new User
            //{
            //    Username = "Test",
            //    Password = "123456",
            //    Address = "江苏省南京市雨花台区云密城I栋6F",
            //    Age = 11,
            //    BrithDay = DateTime.Now,
            //    CreateId = 1,
            //    CreateTime = DateTime.Now,
            //    Email = "385934101@qq.com",
            //    IsDelete = 0,
            //    Sex = 1,
            //    UpdateTime = DateTime.Now
            //};
            //var sugarUser = user.EmitMapperTo<User, User_Sugar>();
            //var efUser = user.EmitMapperTo<User, User_EFCore>();
            //var freeSqlUser = user.EmitMapperTo<User, User_FreeSQL>();

            //Console.WriteLine("开始插入单条数据");
            //Console.WriteLine("---------------------------------------------------------------------------------------");
            //Console.WriteLine("SqlSugar Start");
            //stopwatch.Restart();
            //sugarUserRepository.Insert(sugarUser);
            //stopwatch.Stop();
            //Console.WriteLine("SqlSugar End");
            //Console.WriteLine($"SqlSugar 插入单条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            //Console.WriteLine("---------------------------------------------------------------------------------------");
            //Console.WriteLine("EFCore 3.1.5 Start");
            //stopwatch.Restart();
            //using (var efcore = new EFDbContext())
            //{
            //    efcore.User.Add(efUser);
            //    efcore.SaveChanges();
            //}
            //stopwatch.Stop();
            //Console.WriteLine("EFCore 3.1.5 End");
            //Console.WriteLine($"EFCore 3.1.5 插入单条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            //Console.WriteLine("---------------------------------------------------------------------------------------");
            //Console.WriteLine("FreeSQL Start");
            //stopwatch.Restart();
            //freeSql.Insert(freeSqlUser).ExecuteAffrows();
            //stopwatch.Stop();
            //Console.WriteLine("FreeSQL End");
            //Console.WriteLine($"FreeSQL插入单条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            //Console.WriteLine("---------------------------------------------------------------------------------------");
            //Console.WriteLine("ADO.NET Start");
            //stopwatch.Restart();
            //using (var conn = new MySqlConnection("Database=orm_test;Data Source=localhost;Port=3306;User Id=root;Password=123456w.;Charset=utf8;"))
            //{
            //    conn.Open();
            //    var sql = $"INSERT INTO `user`(`Username`, `Password`, `Email`, `Address`, `Age`, `Sex`, `BrithDay`, `CreateTime`, `UpdateTime`, `CreateId`, `IsDelete`) " +
            //        $"VALUES ('{user.Username}', '{user.Password}', '{user.Email}', '{user.Address}',{user.Age}, {user.Sex}, '{user.BrithDay}', '{user.CreateTime}', '{user.UpdateTime}',{user.CreateId}, {user.IsDelete});";
            //    var sqlcmd = new MySqlCommand(sql, conn);
            //    sqlcmd.ExecuteNonQuery();
            //}
            //stopwatch.Stop();
            //Console.WriteLine("ADO.NET End");
            //Console.WriteLine($"ADO.NET插入单条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            //Console.WriteLine("---------------------------------------------------------------------------------------");
            //#endregion

            //#region 10条数据
            //var userList10 = new List<User>();

            //for (int i = 1; i <= 10; i++)
            //{
            //    userList10.Add(new User
            //    {
            //        Username = $"Test{i}",
            //        Password = "123456",
            //        Address = "江苏省南京市雨花台区云密城I栋6F",
            //        Age = 11,
            //        BrithDay = DateTime.Now,
            //        CreateId = i,
            //        CreateTime = DateTime.Now,
            //        Email = "385934101@qq.com",
            //        IsDelete = 0,
            //        Sex = 1,
            //        UpdateTime = DateTime.Now
            //    });
            //}

            //var sugarUserList = userList10.EmitMapperListTo<User, User_Sugar>();
            //var efUserList = userList10.EmitMapperListTo<User, User_EFCore>();
            //var freeSqlUserList = userList10.EmitMapperListTo<User, User_FreeSQL>();

            //Console.WriteLine("开始插入10条数据");
            //Console.WriteLine("---------------------------------------------------------------------------------------");
            //Console.WriteLine("SqlSugar Start");
            //stopwatch.Restart();
            //sugarUserRepository.InsertList(sugarUserList);
            //stopwatch.Stop();
            //Console.WriteLine("SqlSugar End");
            //Console.WriteLine($"SqlSugar 插入10条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            //Console.WriteLine("---------------------------------------------------------------------------------------");

            //Console.WriteLine("EFCore 3.1.5 Start");
            //stopwatch.Restart();
            //using (var efcore = new EFDbContext())
            //{
            //    efcore.User.AddRange(efUserList);
            //    efcore.SaveChanges();
            //}
            //stopwatch.Stop();
            //Console.WriteLine("EFCore 3.1.5 End");
            //Console.WriteLine($"EFCore 3.1.5 插入10条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            //Console.WriteLine("---------------------------------------------------------------------------------------");

            //Console.WriteLine("FreeSQL Start");
            //stopwatch.Restart();
            //freeSql.Insert(freeSqlUserList).ExecuteAffrows();
            //stopwatch.Stop();
            //Console.WriteLine("FreeSQL End");
            //Console.WriteLine($"FreeSQL插入10条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            //Console.WriteLine("---------------------------------------------------------------------------------------");

            //Console.WriteLine("ADO.NET Start");
            //var mutiSql = new List<string>();
            //foreach (var user10 in userList10)
            //{
            //    mutiSql.Add($"('{user10.Username}', '{user10.Password}', '{user10.Email}', '{user10.Address}',{user10.Age}, {user10.Sex}, '{user10.BrithDay}', '{user10.CreateTime}', '{user10.UpdateTime}',{user10.CreateId}, {user10.IsDelete})");
            //}
            //stopwatch.Restart();
            //using (var conn = new MySqlConnection("Database=orm_test;Data Source=localhost;Port=3306;User Id=root;Password=123456w.;Charset=utf8;"))
            //{
            //    conn.Open();
            //    var sql = $"INSERT INTO `user`(`Username`, `Password`, `Email`, `Address`, `Age`, `Sex`, `BrithDay`, `CreateTime`, `UpdateTime`, `CreateId`, `IsDelete`) VALUES" + string.Join(",", mutiSql);
            //    var sqlcmd = new MySqlCommand(sql, conn);
            //    sqlcmd.ExecuteNonQuery();
            //}
            //stopwatch.Stop();
            //Console.WriteLine("ADO.NET End");
            //Console.WriteLine($"ADO.NET插入10条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            //Console.WriteLine("---------------------------------------------------------------------------------------");
            //#endregion

            //#region 100条数据
            //var userList100 = new List<User>();

            //for (int i = 1; i <= 100; i++)
            //{
            //    userList100.Add(new User
            //    {
            //        Username = $"Test{i}",
            //        Password = "123456",
            //        Address = "江苏省南京市雨花台区云密城I栋6F",
            //        Age = 11,
            //        BrithDay = DateTime.Now,
            //        CreateId = i,
            //        CreateTime = DateTime.Now,
            //        Email = "385934101@qq.com",
            //        IsDelete = 0,
            //        Sex = 1,
            //        UpdateTime = DateTime.Now
            //    });
            //}

            //var sugar100UserList = userList100.EmitMapperListTo<User, User_Sugar>();
            //var efUser100List = userList100.EmitMapperListTo<User, User_EFCore>();
            //var freeSql100UserList = userList100.EmitMapperListTo<User, User_FreeSQL>();

            //Console.WriteLine("开始插入100条数据");
            //Console.WriteLine("---------------------------------------------------------------------------------------");
            //Console.WriteLine("SqlSugar Start");
            //stopwatch.Restart();
            //sugarUserRepository.InsertList(sugar100UserList);
            //stopwatch.Stop();
            //Console.WriteLine("SqlSugar End");
            //Console.WriteLine($"SqlSugar 插入100条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            //Console.WriteLine("---------------------------------------------------------------------------------------");

            //Console.WriteLine("EFCore 3.1.5 Start");
            //stopwatch.Restart();
            //using (var efcore = new EFDbContext())
            //{
            //    efcore.User.AddRange(efUser100List);
            //    efcore.SaveChanges();
            //}
            //stopwatch.Stop();
            //Console.WriteLine("EFCore 3.1.5 End");
            //Console.WriteLine($"EFCore 3.1.5 插入100条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            //Console.WriteLine("---------------------------------------------------------------------------------------");

            //Console.WriteLine("FreeSQL Start");
            //stopwatch.Restart();
            //freeSql.Insert(freeSql100UserList).ExecuteAffrows();
            //stopwatch.Stop();
            //Console.WriteLine("FreeSQL End");
            //Console.WriteLine($"FreeSQL插入100条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            //Console.WriteLine("---------------------------------------------------------------------------------------");

            //Console.WriteLine("ADO.NET Start");
            //var mutiSql100 = new List<string>();
            //foreach (var user100 in userList100)
            //{
            //    mutiSql100.Add($"('{user100.Username}', '{user100.Password}', '{user100.Email}', '{user100.Address}',{user100.Age}, {user100.Sex}, '{user100.BrithDay}', '{user100.CreateTime}', '{user100.UpdateTime}',{user100.CreateId}, {user100.IsDelete})");
            //}
            //stopwatch.Restart();
            //using (var conn = new MySqlConnection("Database=orm_test;Data Source=localhost;Port=3306;User Id=root;Password=123456w.;Charset=utf8;"))
            //{
            //    conn.Open();
            //    var sql = $"INSERT INTO `user`(`Username`, `Password`, `Email`, `Address`, `Age`, `Sex`, `BrithDay`, `CreateTime`, `UpdateTime`, `CreateId`, `IsDelete`) VALUES" + string.Join(",", mutiSql100);
            //    var sqlcmd = new MySqlCommand(sql, conn);
            //    sqlcmd.ExecuteNonQuery();
            //}
            //stopwatch.Stop();
            //Console.WriteLine("ADO.NET End");
            //Console.WriteLine($"ADO.NET插入100条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            //Console.WriteLine("---------------------------------------------------------------------------------------");
            //#endregion

            //#region 1000条数据
            //var userList1000 = new List<User>();

            //for (int i = 1; i <= 1000; i++)
            //{
            //    userList1000.Add(new User
            //    {
            //        Username = $"Test{i}",
            //        Password = "123456",
            //        Address = "江苏省南京市雨花台区云密城I栋6F",
            //        Age = 11,
            //        BrithDay = DateTime.Now,
            //        CreateId = i,
            //        CreateTime = DateTime.Now,
            //        Email = "385934101@qq.com",
            //        IsDelete = 0,
            //        Sex = 1,
            //        UpdateTime = DateTime.Now
            //    });
            //}

            //var sugarUser1000List = userList1000.EmitMapperListTo<User, User_Sugar>();
            //var efUser1000List = userList1000.EmitMapperListTo<User, User_EFCore>();
            //var freeSqlUser1000List = userList1000.EmitMapperListTo<User, User_FreeSQL>();

            //Console.WriteLine("开始插入1000条数据");
            //Console.WriteLine("---------------------------------------------------------------------------------------");
            //Console.WriteLine("SqlSugar Start");
            //stopwatch.Restart();
            //sugarUserRepository.InsertList(sugarUser1000List);
            //stopwatch.Stop();
            //Console.WriteLine("SqlSugar End");
            //Console.WriteLine($"SqlSugar 插入1000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            //Console.WriteLine("---------------------------------------------------------------------------------------");

            //Console.WriteLine("EFCore 3.1.5 Start");
            //stopwatch.Restart();
            //using (var efcore = new EFDbContext())
            //{
            //    efcore.User.AddRange(efUser1000List);
            //    efcore.SaveChanges();
            //}
            //stopwatch.Stop();
            //Console.WriteLine("EFCore 3.1.5 End");
            //Console.WriteLine($"EFCore 3.1.5 插入1000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            //Console.WriteLine("---------------------------------------------------------------------------------------");

            //Console.WriteLine("FreeSQL Start");
            //stopwatch.Restart();
            //freeSql.Insert(freeSqlUser1000List).ExecuteAffrows();
            //stopwatch.Stop();
            //Console.WriteLine("FreeSQL End");
            //Console.WriteLine($"FreeSQL插入1000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            //Console.WriteLine("---------------------------------------------------------------------------------------");

            //Console.WriteLine("ADO.NET Start");
            //var mutiSql1000 = new List<string>();
            //foreach (var user1000 in userList1000)
            //{
            //    mutiSql1000.Add($"('{user1000.Username}', '{user1000.Password}', '{user1000.Email}', '{user1000.Address}',{user1000.Age}, {user1000.Sex}, '{user1000.BrithDay}', '{user1000.CreateTime}', '{user1000.UpdateTime}',{user1000.CreateId}, {user1000.IsDelete})");
            //}
            //stopwatch.Restart();
            //using (var conn = new MySqlConnection("Database=orm_test;Data Source=localhost;Port=3306;User Id=root;Password=123456w.;Charset=utf8;"))
            //{
            //    conn.Open();
            //    var sql = $"INSERT INTO `user`(`Username`, `Password`, `Email`, `Address`, `Age`, `Sex`, `BrithDay`, `CreateTime`, `UpdateTime`, `CreateId`, `IsDelete`) VALUES" + string.Join(",", mutiSql1000);
            //    var sqlcmd = new MySqlCommand(sql, conn);
            //    sqlcmd.ExecuteNonQuery();
            //}
            //stopwatch.Stop();
            //Console.WriteLine("ADO.NET End");
            //Console.WriteLine($"ADO.NET插入1000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            //Console.WriteLine("---------------------------------------------------------------------------------------");
            //#endregion

            //#region 10000条数据
            //var userList10000 = new List<User>();

            //for (int i = 1; i <= 10000; i++)
            //{
            //    userList10000.Add(new User
            //    {
            //        Username = $"Test{i}",
            //        Password = "123456",
            //        Address = "江苏省南京市雨花台区云密城I栋6F",
            //        Age = 11,
            //        BrithDay = DateTime.Now,
            //        CreateId = i,
            //        CreateTime = DateTime.Now,
            //        Email = "385934101@qq.com",
            //        IsDelete = 0,
            //        Sex = 1,
            //        UpdateTime = DateTime.Now
            //    });
            //}

            //var sugarUser10000List = userList10000.EmitMapperListTo<User, User_Sugar>();
            //var efUser10000List = userList10000.EmitMapperListTo<User, User_EFCore>();
            //var freeSqlUser10000List = userList10000.EmitMapperListTo<User, User_FreeSQL>();

            //Console.WriteLine("开始插入10000条数据条数据");
            //Console.WriteLine("---------------------------------------------------------------------------------------");
            //Console.WriteLine("SqlSugar Start");
            //stopwatch.Restart();
            //sugarUserRepository.InsertList(sugarUser10000List);
            //stopwatch.Stop();
            //Console.WriteLine("SqlSugar End");
            //Console.WriteLine($"SqlSugar 插入10000条数据条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            //Console.WriteLine("---------------------------------------------------------------------------------------");

            //Console.WriteLine("EFCore 3.1.5 Start");
            //stopwatch.Restart();
            //using (var efcore = new EFDbContext())
            //{
            //    efcore.User.AddRange(efUser10000List);
            //    efcore.SaveChanges();
            //}
            //stopwatch.Stop();
            //Console.WriteLine("EFCore 3.1.5 End");
            //Console.WriteLine($"EFCore 3.1.5 插入10000条数据条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            //Console.WriteLine("---------------------------------------------------------------------------------------");

            //Console.WriteLine("FreeSQL Start");
            //stopwatch.Restart();
            //freeSql.Insert(freeSqlUser10000List).ExecuteAffrows();
            //stopwatch.Stop();
            //Console.WriteLine("FreeSQL End");
            //Console.WriteLine($"FreeSQL插入10000条数据条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            //Console.WriteLine("---------------------------------------------------------------------------------------");

            //Console.WriteLine("ADO.NET Start");
            //var mutiSql10000 = new List<string>();
            //foreach (var user10000 in userList10000)
            //{
            //    mutiSql10000.Add($"('{user10000.Username}', '{user10000.Password}', '{user10000.Email}', '{user10000.Address}',{user10000.Age}, {user10000.Sex}, '{user10000.BrithDay}', '{user10000.CreateTime}', '{user10000.UpdateTime}',{user10000.CreateId}, {user10000.IsDelete})");
            //}
            //stopwatch.Restart();
            //using (var conn = new MySqlConnection("Database=orm_test;Data Source=localhost;Port=3306;User Id=root;Password=123456w.;Charset=utf8;"))
            //{
            //    conn.Open();
            //    var sql = $"INSERT INTO `user`(`Username`, `Password`, `Email`, `Address`, `Age`, `Sex`, `BrithDay`, `CreateTime`, `UpdateTime`, `CreateId`, `IsDelete`) VALUES" + string.Join(",", mutiSql10000);
            //    var sqlcmd = new MySqlCommand(sql, conn);
            //    sqlcmd.ExecuteNonQuery();
            //}
            //stopwatch.Stop();
            //Console.WriteLine("ADO.NET End");
            //Console.WriteLine($"ADO.NET插入10000条数据条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            //Console.WriteLine("---------------------------------------------------------------------------------------");
            //#endregion

            //#region 100000条数据
            //var userList100000 = new List<User>();

            //for (int i = 1; i <= 100000; i++)
            //{
            //    userList100000.Add(new User
            //    {
            //        Username = $"Test{i}",
            //        Password = "123456",
            //        Address = "江苏省南京市雨花台区云密城I栋6F",
            //        Age = 11,
            //        BrithDay = DateTime.Now,
            //        CreateId = i,
            //        CreateTime = DateTime.Now,
            //        Email = "385934101@qq.com",
            //        IsDelete = 0,
            //        Sex = 1,
            //        UpdateTime = DateTime.Now
            //    });
            //}

            //var sugarUser100000List = userList100000.EmitMapperListTo<User, User_Sugar>();
            //var efUser100000List = userList100000.EmitMapperListTo<User, User_EFCore>();
            //var freeSqlUser100000List = userList100000.EmitMapperListTo<User, User_FreeSQL>();

            //Console.WriteLine("开始插入100000条数据条数据");
            //Console.WriteLine("---------------------------------------------------------------------------------------");
            //Console.WriteLine("SqlSugar Start");
            //stopwatch.Restart();
            //sugarUserRepository.InsertList(sugarUser100000List);
            //stopwatch.Stop();
            //Console.WriteLine("SqlSugar End");
            //Console.WriteLine($"SqlSugar 插入100000条数据条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            //Console.WriteLine("---------------------------------------------------------------------------------------");

            //Console.WriteLine("EFCore 3.1.5 Start");
            //stopwatch.Restart();
            //using (var efcore = new EFDbContext())
            //{
            //    efcore.User.AddRange(efUser100000List);
            //    efcore.SaveChanges();
            //}
            //stopwatch.Stop();
            //Console.WriteLine("EFCore 3.1.5 End");
            //Console.WriteLine($"EFCore 3.1.5 插入100000条数据条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            //Console.WriteLine("---------------------------------------------------------------------------------------");

            //Console.WriteLine("FreeSQL Start");
            //stopwatch.Restart();
            //freeSql.Insert(freeSqlUser100000List).ExecuteAffrows();
            //stopwatch.Stop();
            //Console.WriteLine("FreeSQL End");
            //Console.WriteLine($"FreeSQL插入100000条数据条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            //Console.WriteLine("---------------------------------------------------------------------------------------");

            //Console.WriteLine("ADO.NET Start");
            //var mutiSql100000 = new List<string>();
            //foreach (var user100000 in userList100000)
            //{
            //    mutiSql100000.Add($"('{user100000.Username}', '{user100000.Password}', '{user100000.Email}', '{user100000.Address}',{user100000.Age}, {user100000.Sex}, '{user100000.BrithDay}', '{user100000.CreateTime}', '{user100000.UpdateTime}',{user100000.CreateId}, {user100000.IsDelete})");
            //}
            //stopwatch.Restart();
            //using (var conn = new MySqlConnection("Database=orm_test;Data Source=localhost;Port=3306;User Id=root;Password=123456w.;Charset=utf8;"))
            //{
            //    conn.Open();
            //    var sql = $"INSERT INTO `user`(`Username`, `Password`, `Email`, `Address`, `Age`, `Sex`, `BrithDay`, `CreateTime`, `UpdateTime`, `CreateId`, `IsDelete`) VALUES" + string.Join(",", mutiSql100000);
            //    var sqlcmd = new MySqlCommand(sql, conn);
            //    sqlcmd.ExecuteNonQuery();
            //}
            //stopwatch.Stop();
            //Console.WriteLine("ADO.NET End");
            //Console.WriteLine($"ADO.NET插入100000条数据条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            //Console.WriteLine("---------------------------------------------------------------------------------------");
            //#endregion

            #endregion

            #region 事务插入

            #region 事务插入10条数据
            var userList10Tran = new List<User>();

            for (int i = 1; i <= 10; i++)
            {
                userList10Tran.Add(new User
                {
                    Username = $"Test{i}",
                    Password = "123456",
                    Address = "江苏省南京市雨花台区云密城I栋6F",
                    Age = 11,
                    BrithDay = DateTime.Now,
                    CreateId = i,
                    CreateTime = DateTime.Now,
                    Email = "385934101@qq.com",
                    IsDelete = 0,
                    Sex = 1,
                    UpdateTime = DateTime.Now
                });
            }

            var sugarTran10UserList = userList10Tran.EmitMapperListTo<User, User_Sugar>();
            var efTran10UserList = userList10Tran.EmitMapperListTo<User, User_EFCore>();
            var freeSqlTran10UserList = userList10Tran.EmitMapperListTo<User, User_FreeSQL>();

            Console.WriteLine("开始事务插入10条数据");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("SqlSugar Start");
            stopwatch.Restart();
            sugarUserRepository.InsertListByTran(sugarTran10UserList);
            stopwatch.Stop();
            Console.WriteLine("SqlSugar End");
            Console.WriteLine($"SqlSugar 事务插入10条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("EFCore 3.1.5 Start");
            stopwatch.Restart();
            using (var efcore = new EFDbContext())
            {
                var eftran10Tran = efcore.Database.BeginTransaction();
                efcore.BulkInsert(efTran10UserList);
                eftran10Tran.Commit();
            }
            stopwatch.Stop();
            Console.WriteLine("EFCore 3.1.5 End");
            Console.WriteLine($"EFCore 3.1.5 事务插入10条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("FreeSQL Start");
            stopwatch.Restart();
            freeSql.Transaction(() =>
            {
                freeSql.Insert(freeSqlTran10UserList).ExecuteAffrows();
            });
            stopwatch.Stop();
            Console.WriteLine("FreeSQL End");
            Console.WriteLine($"FreeSQL 事务插入10条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("ADO.NET Start");
            var mutiSql10Tran = new List<string>();
            foreach (var user10Tran in userList10Tran)
            {
                mutiSql10Tran.Add($"('{user10Tran.Username}', '{user10Tran.Password}', '{user10Tran.Email}', '{user10Tran.Address}',{user10Tran.Age}, {user10Tran.Sex}, '{user10Tran.BrithDay}', '{user10Tran.CreateTime}', '{user10Tran.UpdateTime}',{user10Tran.CreateId}, {user10Tran.IsDelete})");
            }
            stopwatch.Restart();
            using (var conn = new MySqlConnection("Database=orm_test;Data Source=localhost;Port=3306;User Id=root;Password=123456w.;Charset=utf8;"))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    var sql = $"INSERT INTO `user`(`Username`, `Password`, `Email`, `Address`, `Age`, `Sex`, `BrithDay`, `CreateTime`, `UpdateTime`, `CreateId`, `IsDelete`) VALUES" + string.Join(",", mutiSql10Tran);
                    var sqlcmd = new MySqlCommand(sql, conn);
                    sqlcmd.Transaction = transaction;
                    sqlcmd.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
            stopwatch.Stop();
            Console.WriteLine("ADO.NET End");
            Console.WriteLine($"ADO.NET 事务插入10条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            #endregion

            #region 事务插入100条数据
            var userList100Tran = new List<User>();

            for (int i = 1; i <= 100; i++)
            {
                userList100Tran.Add(new User
                {
                    Username = $"Test{i}",
                    Password = "123456",
                    Address = "江苏省南京市雨花台区云密城I栋6F",
                    Age = 11,
                    BrithDay = DateTime.Now,
                    CreateId = i,
                    CreateTime = DateTime.Now,
                    Email = "385934101@qq.com",
                    IsDelete = 0,
                    Sex = 1,
                    UpdateTime = DateTime.Now
                });
            }

            var sugarTran100UserList = userList100Tran.EmitMapperListTo<User, User_Sugar>();
            var efTran100UserList = userList100Tran.EmitMapperListTo<User, User_EFCore>();
            var freeSqlTran100UserList = userList100Tran.EmitMapperListTo<User, User_FreeSQL>();

            Console.WriteLine("开始事务插入100条数据");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("SqlSugar Start");
            stopwatch.Restart();
            sugarUserRepository.InsertListByTran(sugarTran100UserList);
            stopwatch.Stop();
            Console.WriteLine("SqlSugar End");
            Console.WriteLine($"SqlSugar 事务插入100条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("EFCore 3.1.5 Start");
            stopwatch.Restart();
            using (var efcore = new EFDbContext())
            {
                var eftran100Tran = efcore.Database.BeginTransaction();
                efcore.BulkInsert(efTran100UserList);
                eftran100Tran.Commit();
            }
            stopwatch.Stop();
            Console.WriteLine("EFCore 3.1.5 End");
            Console.WriteLine($"EFCore 3.1.5 事务插入100条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("FreeSQL Start");
            stopwatch.Restart();
            freeSql.Transaction(() =>
            {
                freeSql.Insert(freeSqlTran100UserList).ExecuteAffrows();
            });
            stopwatch.Stop();
            Console.WriteLine("FreeSQL End");
            Console.WriteLine($"FreeSQL 事务插入100条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("ADO.NET Start");
            var mutiSql100Tran = new List<string>();
            foreach (var user100Tran in userList100Tran)
            {
                mutiSql100Tran.Add($"('{user100Tran.Username}', '{user100Tran.Password}', '{user100Tran.Email}', '{user100Tran.Address}',{user100Tran.Age}, {user100Tran.Sex}, '{user100Tran.BrithDay}', '{user100Tran.CreateTime}', '{user100Tran.UpdateTime}',{user100Tran.CreateId}, {user100Tran.IsDelete})");
            }
            stopwatch.Restart();
            using (var conn = new MySqlConnection("Database=orm_test;Data Source=localhost;Port=3306;User Id=root;Password=123456w.;Charset=utf8;"))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    var sql = $"INSERT INTO `user`(`Username`, `Password`, `Email`, `Address`, `Age`, `Sex`, `BrithDay`, `CreateTime`, `UpdateTime`, `CreateId`, `IsDelete`) VALUES" + string.Join(",", mutiSql100Tran);
                    var sqlcmd = new MySqlCommand(sql, conn);
                    sqlcmd.Transaction = transaction;
                    sqlcmd.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
            stopwatch.Stop();
            Console.WriteLine("ADO.NET End");
            Console.WriteLine($"ADO.NET 事务插入100条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            #endregion

            #region 事务插入1000条数据
            var userList1000Tran = new List<User>();

            for (int i = 1; i <= 1000; i++)
            {
                userList1000Tran.Add(new User
                {
                    Username = $"Test{i}",
                    Password = "123456",
                    Address = "江苏省南京市雨花台区云密城I栋6F",
                    Age = 11,
                    BrithDay = DateTime.Now,
                    CreateId = i,
                    CreateTime = DateTime.Now,
                    Email = "385934101@qq.com",
                    IsDelete = 0,
                    Sex = 1,
                    UpdateTime = DateTime.Now
                });
            }

            var sugarTran1000UserList = userList1000Tran.EmitMapperListTo<User, User_Sugar>();
            var efTran1000UserList = userList1000Tran.EmitMapperListTo<User, User_EFCore>();
            var freeSqlTran1000UserList = userList1000Tran.EmitMapperListTo<User, User_FreeSQL>();

            Console.WriteLine("开始事务插入1000条数据");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("SqlSugar Start");
            stopwatch.Restart();
            sugarUserRepository.InsertListByTran(sugarTran1000UserList);
            stopwatch.Stop();
            Console.WriteLine("SqlSugar End");
            Console.WriteLine($"SqlSugar 事务插入1000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("EFCore 3.1.5 Start");
            stopwatch.Restart();
            using (var efcore = new EFDbContext())
            {
                var eftran1000Tran = efcore.Database.BeginTransaction();
                efcore.BulkInsert(efTran1000UserList);
                eftran1000Tran.Commit();
            }
            stopwatch.Stop();
            Console.WriteLine("EFCore 3.1.5 End");
            Console.WriteLine($"EFCore 3.1.5 事务插入1000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("FreeSQL Start");
            stopwatch.Restart();
            freeSql.Transaction(() =>
            {
                freeSql.Insert(freeSqlTran1000UserList).ExecuteAffrows();
            });
            stopwatch.Stop();
            Console.WriteLine("FreeSQL End");
            Console.WriteLine($"FreeSQL 事务插入1000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("ADO.NET Start");
            var mutiSql1000Tran = new List<string>();
            foreach (var user1000Tran in userList1000Tran)
            {
                mutiSql1000Tran.Add($"('{user1000Tran.Username}', '{user1000Tran.Password}', '{user1000Tran.Email}', '{user1000Tran.Address}',{user1000Tran.Age}, {user1000Tran.Sex}, '{user1000Tran.BrithDay}', '{user1000Tran.CreateTime}', '{user1000Tran.UpdateTime}',{user1000Tran.CreateId}, {user1000Tran.IsDelete})");
            }
            stopwatch.Restart();
            using (var conn = new MySqlConnection("Database=orm_test;Data Source=localhost;Port=3306;User Id=root;Password=123456w.;Charset=utf8;"))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    var sql = $"INSERT INTO `user`(`Username`, `Password`, `Email`, `Address`, `Age`, `Sex`, `BrithDay`, `CreateTime`, `UpdateTime`, `CreateId`, `IsDelete`) VALUES" + string.Join(",", mutiSql1000Tran);
                    var sqlcmd = new MySqlCommand(sql, conn);
                    sqlcmd.Transaction = transaction;
                    sqlcmd.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
            stopwatch.Stop();
            Console.WriteLine("ADO.NET End");
            Console.WriteLine($"ADO.NET 事务插入1000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            #endregion

            #region 事务插入10000条数据
            var userList10000Tran = new List<User>();

            for (int i = 1; i <= 10000; i++)
            {
                userList10000Tran.Add(new User
                {
                    Username = $"Test{i}",
                    Password = "123456",
                    Address = "江苏省南京市雨花台区云密城I栋6F",
                    Age = 11,
                    BrithDay = DateTime.Now,
                    CreateId = i,
                    CreateTime = DateTime.Now,
                    Email = "385934101@qq.com",
                    IsDelete = 0,
                    Sex = 1,
                    UpdateTime = DateTime.Now
                });
            }

            var sugarTran10000UserList = userList10000Tran.EmitMapperListTo<User, User_Sugar>();
            var efTran10000UserList = userList10000Tran.EmitMapperListTo<User, User_EFCore>();
            var freeSqlTran10000UserList = userList10000Tran.EmitMapperListTo<User, User_FreeSQL>();

            Console.WriteLine("开始事务插入10000条数据");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("SqlSugar Start");
            stopwatch.Restart();
            sugarUserRepository.InsertListByTran(sugarTran10000UserList);
            stopwatch.Stop();
            Console.WriteLine("SqlSugar End");
            Console.WriteLine($"SqlSugar 事务插入10000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("EFCore 3.1.5 Start");
            stopwatch.Restart();
            using (var efcore = new EFDbContext())
            {
                var eftran10000Tran = efcore.Database.BeginTransaction();
                efcore.BulkInsert(efTran10000UserList);
                eftran10000Tran.Commit();
            }
            stopwatch.Stop();
            Console.WriteLine("EFCore 3.1.5 End");
            Console.WriteLine($"EFCore 3.1.5 事务插入10000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("FreeSQL Start");
            stopwatch.Restart();
            freeSql.Transaction(() =>
            {
                freeSql.Insert(freeSqlTran10000UserList).ExecuteAffrows();
            });
            stopwatch.Stop();
            Console.WriteLine("FreeSQL End");
            Console.WriteLine($"FreeSQL 事务插入10000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("ADO.NET Start");
            var mutiSql10000Tran = new List<string>();
            foreach (var user10000 in userList10000Tran)
            {
                mutiSql10000Tran.Add($"('{user10000.Username}', '{user10000.Password}', '{user10000.Email}', '{user10000.Address}',{user10000.Age}, {user10000.Sex}, '{user10000.BrithDay}', '{user10000.CreateTime}', '{user10000.UpdateTime}',{user10000.CreateId}, {user10000.IsDelete})");
            }
            stopwatch.Restart();
            using (var conn = new MySqlConnection("Database=orm_test;Data Source=localhost;Port=3306;User Id=root;Password=123456w.;Charset=utf8;"))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    var sql = $"INSERT INTO `user`(`Username`, `Password`, `Email`, `Address`, `Age`, `Sex`, `BrithDay`, `CreateTime`, `UpdateTime`, `CreateId`, `IsDelete`) VALUES" + string.Join(",", mutiSql10000Tran);
                    var sqlcmd = new MySqlCommand(sql, conn);
                    sqlcmd.Transaction = transaction;
                    sqlcmd.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
            stopwatch.Stop();
            Console.WriteLine("ADO.NET End");
            Console.WriteLine($"ADO.NET 事务插入10000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            #endregion

            #region 事务插入100000条数据
            var userList100000Tran = new List<User>();

            for (int i = 1; i <= 100000; i++)
            {
                userList100000Tran.Add(new User
                {
                    Username = $"Test{i}",
                    Password = "123456",
                    Address = "江苏省南京市雨花台区云密城I栋6F",
                    Age = 11,
                    BrithDay = DateTime.Now,
                    CreateId = i,
                    CreateTime = DateTime.Now,
                    Email = "385934101@qq.com",
                    IsDelete = 0,
                    Sex = 1,
                    UpdateTime = DateTime.Now
                });
            }

            var sugarTran100000UserList = userList100000Tran.EmitMapperListTo<User, User_Sugar>();
            var efTran100000UserList = userList100000Tran.EmitMapperListTo<User, User_EFCore>();
            var freeSqlTran100000UserList = userList100000Tran.EmitMapperListTo<User, User_FreeSQL>();

            Console.WriteLine("开始事务插入100000条数据");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("SqlSugar Start");
            stopwatch.Restart();
            sugarUserRepository.InsertListByTran(sugarTran100000UserList);
            stopwatch.Stop();
            Console.WriteLine("SqlSugar End");
            Console.WriteLine($"SqlSugar 事务插入100000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("EFCore 3.1.5 Start");
            stopwatch.Restart();
            using (var efcore = new EFDbContext())
            {
                var eftran100000Tran = efcore.Database.BeginTransaction();
                efcore.BulkInsert(efTran100000UserList);
                eftran100000Tran.Commit();
            }
            stopwatch.Stop();
            Console.WriteLine("EFCore 3.1.5 End");
            Console.WriteLine($"EFCore 3.1.5 事务插入100000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("FreeSQL Start");
            stopwatch.Restart();
            freeSql.Transaction(() =>
            {
                freeSql.Insert(freeSqlTran100000UserList).ExecuteAffrows();
            });
            stopwatch.Stop();
            Console.WriteLine("FreeSQL End");
            Console.WriteLine($"FreeSQL 事务插入100000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("ADO.NET Start");
            var mutiSql100000Tran = new List<string>();
            foreach (var user100000 in userList100000Tran)
            {
                mutiSql100000Tran.Add($"('{user100000.Username}', '{user100000.Password}', '{user100000.Email}', '{user100000.Address}',{user100000.Age}, {user100000.Sex}, '{user100000.BrithDay}', '{user100000.CreateTime}', '{user100000.UpdateTime}',{user100000.CreateId}, {user100000.IsDelete})");
            }
            stopwatch.Restart();
            using (var conn = new MySqlConnection("Database=orm_test;Data Source=localhost;Port=3306;User Id=root;Password=123456w.;Charset=utf8;"))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    var sql = $"INSERT INTO `user`(`Username`, `Password`, `Email`, `Address`, `Age`, `Sex`, `BrithDay`, `CreateTime`, `UpdateTime`, `CreateId`, `IsDelete`) VALUES" + string.Join(",", mutiSql100000Tran);
                    var sqlcmd = new MySqlCommand(sql, conn);
                    sqlcmd.Transaction = transaction;
                    sqlcmd.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
            stopwatch.Stop();
            Console.WriteLine("ADO.NET End");
            Console.WriteLine($"ADO.NET 事务插入100000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            #endregion

            #endregion
        }

        static void QueryTest()
        {
            var stopwatch = new Stopwatch();

            var sqlSugar = SugarFactory.GetDbContext();
            var freeSql = FreeSqlFactory.GetDbContext();

            #region 查询单条数据
            Console.WriteLine("开始查询单条数据");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("SqlSugar Start");
            stopwatch.Restart();
            var sugar1 = sqlSugar.Queryable<User_Sugar>().Take(1).ToList();
            stopwatch.Stop();
            Console.WriteLine("SqlSugar End");
            Console.WriteLine($"SqlSugar 查询单条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("EF Core 3.1.5 Start");
            stopwatch.Restart();
            using (var efcore = new EFDbContext())
            {
                var ef1 = efcore.Set<User_EFCore>().Take(1).AsNoTracking().ToList();
            }
            stopwatch.Stop();
            Console.WriteLine("EF Core 3.1.5 End");
            Console.WriteLine($"EF Core 3.1.5 查询单条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("FreeSQL Start");
            stopwatch.Restart();
            var free1 = freeSql.Select<User_FreeSQL>().Take(1).ToList();
            stopwatch.Stop();
            Console.WriteLine("FreeSQL End");
            Console.WriteLine($"FreeSQL 查询单条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("ADO.NET Start");
            stopwatch.Restart();
            using (var conn = new MySqlConnection("Database=orm_test;Data Source=localhost;Port=3306;User Id=root;Password=123456w.;Charset=utf8;"))
            {
                conn.Open();
                var sql = $"select * from user limit 0,1";
                var sqlcmd = new MySqlCommand(sql, conn);
                sqlcmd.ExecuteNonQuery();
            }
            stopwatch.Stop();
            Console.WriteLine("ADO.NET End");
            Console.WriteLine($"ADO.NET查询单条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            #endregion

            #region 查询10条数据
            Console.WriteLine("开始查询10条数据");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("SqlSugar Start");
            stopwatch.Restart();
            var sugar10 = sqlSugar.Queryable<User_Sugar>().Take(10).ToList();
            stopwatch.Stop();
            Console.WriteLine("SqlSugar End");
            Console.WriteLine($"SqlSugar 查询10条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("EF Core 3.1.5 Start");
            stopwatch.Restart();
            using (var efcore = new EFDbContext())
            {
                var ef10 = efcore.Set<User_EFCore>().Take(10).AsNoTracking().ToList();
            }
            stopwatch.Stop();
            Console.WriteLine("EF Core 3.1.5 End");
            Console.WriteLine($"EF Core 3.1.5 查询10条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("FreeSQL Start");
            stopwatch.Restart();
            var free10 = freeSql.Select<User_FreeSQL>().Take(10).ToList();
            stopwatch.Stop();
            Console.WriteLine("FreeSQL End");
            Console.WriteLine($"FreeSQL 查询10条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("ADO.NET Start");
            stopwatch.Restart();
            using (var conn = new MySqlConnection("Database=orm_test;Data Source=localhost;Port=3306;User Id=root;Password=123456w.;Charset=utf8;"))
            {
                conn.Open();
                var sql = $"select * from user limit 0,10";
                var sqlcmd = new MySqlCommand(sql, conn);
                sqlcmd.ExecuteNonQuery();
            }
            stopwatch.Stop();
            Console.WriteLine("ADO.NET End");
            Console.WriteLine($"ADO.NET查询10条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            #endregion

            #region 查询100条数据
            Console.WriteLine("开始查询100条数据");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("SqlSugar Start");
            stopwatch.Restart();
            var sugar100 = sqlSugar.Queryable<User_Sugar>().Take(100).ToList();
            stopwatch.Stop();
            Console.WriteLine("SqlSugar End");
            Console.WriteLine($"SqlSugar 查询100条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("EF Core 3.1.5 Start");
            stopwatch.Restart();
            using (var efcore = new EFDbContext())
            {
                var ef100 = efcore.Set<User_EFCore>().Take(100).AsNoTracking().ToList();
            }
            stopwatch.Stop();
            Console.WriteLine("EF Core 3.1.5 End");
            Console.WriteLine($"EF Core 3.1.5 查询100条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("FreeSQL Start");
            stopwatch.Restart();
            var free100 = freeSql.Select<User_FreeSQL>().Take(100).ToList();
            stopwatch.Stop();
            Console.WriteLine("FreeSQL End");
            Console.WriteLine($"FreeSQL 查询100条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("ADO.NET Start");
            stopwatch.Restart();
            using (var conn = new MySqlConnection("Database=orm_test;Data Source=localhost;Port=3306;User Id=root;Password=123456w.;Charset=utf8;"))
            {
                conn.Open();
                var sql = $"select * from user limit 0,100";
                var sqlcmd = new MySqlCommand(sql, conn);
                sqlcmd.ExecuteNonQuery();
            }
            stopwatch.Stop();
            Console.WriteLine("ADO.NET End");
            Console.WriteLine($"ADO.NET查询100条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            #endregion

            #region 查询1000条数据
            Console.WriteLine("开始查询1000条数据");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("SqlSugar Start");
            stopwatch.Restart();
            var sugar1000 = sqlSugar.Queryable<User_Sugar>().Take(1000).ToList();
            stopwatch.Stop();
            Console.WriteLine("SqlSugar End");
            Console.WriteLine($"SqlSugar 查询1000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("EF Core 3.1.5 Start");
            stopwatch.Restart();
            using (var efcore = new EFDbContext())
            {
                var ef1000 = efcore.Set<User_EFCore>().Take(1000).AsNoTracking().ToList();
            }
            stopwatch.Stop();
            Console.WriteLine("EF Core 3.1.5 End");
            Console.WriteLine($"EF Core 3.1.5 查询1000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("FreeSQL Start");
            stopwatch.Restart();
            var free1000 = freeSql.Select<User_FreeSQL>().Take(1000).ToList();
            stopwatch.Stop();
            Console.WriteLine("FreeSQL End");
            Console.WriteLine($"FreeSQL 查询1000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("ADO.NET Start");
            stopwatch.Restart();
            using (var conn = new MySqlConnection("Database=orm_test;Data Source=localhost;Port=3306;User Id=root;Password=123456w.;Charset=utf8;"))
            {
                conn.Open();
                var sql = $"select * from user limit 0,1000";
                var sqlcmd = new MySqlCommand(sql, conn);
                sqlcmd.ExecuteNonQuery();
            }
            stopwatch.Stop();
            Console.WriteLine("ADO.NET End");
            Console.WriteLine($"ADO.NET查询1000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            #endregion

            #region 查询10000条数据
            Console.WriteLine("开始查询10000条数据");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("SqlSugar Start");
            stopwatch.Restart();
            var sugar10000 = sqlSugar.Queryable<User_Sugar>().Take(10000).ToList();
            stopwatch.Stop();
            Console.WriteLine("SqlSugar End");
            Console.WriteLine($"SqlSugar 查询10000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("EF Core 3.1.5 Start");
            stopwatch.Restart();
            using (var efcore = new EFDbContext())
            {
                var ef10000 = efcore.Set<User_EFCore>().Take(10000).AsNoTracking().ToList();
            }
            stopwatch.Stop();
            Console.WriteLine("EF Core 3.1.5 End");
            Console.WriteLine($"EF Core 3.1.5 查询10000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("FreeSQL Start");
            stopwatch.Restart();
            var free10000 = freeSql.Select<User_FreeSQL>().Take(10000).ToList();
            stopwatch.Stop();
            Console.WriteLine("FreeSQL End");
            Console.WriteLine($"FreeSQL 查询10000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("ADO.NET Start");
            stopwatch.Restart();
            using (var conn = new MySqlConnection("Database=orm_test;Data Source=localhost;Port=3306;User Id=root;Password=123456w.;Charset=utf8;"))
            {
                conn.Open();
                var sql = $"select * from user limit 0,10000";
                var sqlcmd = new MySqlCommand(sql, conn);
                sqlcmd.ExecuteNonQuery();
            }
            stopwatch.Stop();
            Console.WriteLine("ADO.NET End");
            Console.WriteLine($"ADO.NET查询10000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            #endregion

            #region 查询100000条数据
            Console.WriteLine("开始查询100000条数据");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("SqlSugar Start");
            stopwatch.Restart();
            var sugar100000 = sqlSugar.Queryable<User_Sugar>().Take(100000).ToList();
            stopwatch.Stop();
            Console.WriteLine("SqlSugar End");
            Console.WriteLine($"SqlSugar 查询100000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("EF Core 3.1.5 Start");
            stopwatch.Restart();
            using (var efcore = new EFDbContext())
            {
                var ef10000 = efcore.Set<User_EFCore>().Take(100000).AsNoTracking().ToList();
            }
            stopwatch.Stop();
            Console.WriteLine("EF Core 3.1.5 End");
            Console.WriteLine($"EF Core 3.1.5 查询100000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("FreeSQL Start");
            stopwatch.Restart();
            var free100000 = freeSql.Select<User_FreeSQL>().Take(100000).ToList();
            stopwatch.Stop();
            Console.WriteLine("FreeSQL End");
            Console.WriteLine($"FreeSQL 查询100000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("ADO.NET Start");
            stopwatch.Restart();
            using (var conn = new MySqlConnection("Database=orm_test;Data Source=localhost;Port=3306;User Id=root;Password=123456w.;Charset=utf8;"))
            {
                conn.Open();
                var sql = $"select * from user limit 0,100000";
                var sqlcmd = new MySqlCommand(sql, conn);
                sqlcmd.ExecuteNonQuery();
            }
            stopwatch.Stop();
            Console.WriteLine("ADO.NET End");
            Console.WriteLine($"ADO.NET查询100000条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            #endregion
        }

        static void TestMysql()
        {
            var rdmChinese = new RandomChinese();
            var idworker = new IdWorker(1);

            for (int j = 1; j <= 1000; j++)
            {
                var userList100000 = new List<User>();

                for (int i = 1; i <= 100000; i++)
                {
                    userList100000.Add(new User
                    {
                        Username = $"Test{j*i}",
                        Password = "123456",
                        Address = rdmChinese.GetRandomChinese(new Random().Next(50, 100)),
                        Age = new Random().Next(20,50),
                        BrithDay = DateTime.Now,
                        CreateId = idworker.nextId(),
                        CreateTime = DateTime.Now,
                        Email = $"{new Random().Next(11111111, 999999999)}@qq.com",
                        IsDelete = 0,
                        Sex = 1,
                        UpdateTime = DateTime.Now
                    });
                }
                var stopwatch = new Stopwatch();

                Console.WriteLine("ADO.NET Start");

                var mutiSql100000 = new List<string>();
                foreach (var user100000 in userList100000)
                {
                    mutiSql100000.Add($"('{user100000.Username}', '{user100000.Password}', '{user100000.Email}', '{user100000.Address}',{user100000.Age}, {user100000.Sex}, '{user100000.BrithDay}', '{user100000.CreateTime}', '{user100000.UpdateTime}',{user100000.CreateId}, {user100000.IsDelete})");
                }
                stopwatch.Restart();
                using (var conn = new MySqlConnection("Database=orm_test;Data Source=localhost;Port=3306;User Id=root;Password=123456w.;Charset=utf8;"))
                {
                    conn.Open();
                    var sql = $"INSERT INTO `user`(`Username`, `Password`, `Email`, `Address`, `Age`, `Sex`, `BrithDay`, `CreateTime`, `UpdateTime`, `CreateId`, `IsDelete`) VALUES" + string.Join(",", mutiSql100000);
                    var sqlcmd = new MySqlCommand(sql, conn);
                    sqlcmd.ExecuteNonQuery();
                }
                stopwatch.Stop();
                Console.WriteLine("ADO.NET End");
                Console.WriteLine($"ADO.NET插入100000条数据条数据耗时:{stopwatch.Elapsed.TotalSeconds}");
                Console.WriteLine("---------------------------------------------------------------------------------------");
            }
        }
    }
}
