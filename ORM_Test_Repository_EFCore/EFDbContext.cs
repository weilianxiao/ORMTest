using System;
using System.Linq;
using System.Threading;
using System.Reflection;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations.Schema;
using ORM_Test_Model;

namespace ORM_Test_Repository_EFCore
{
    /// <summary>
    /// EF数据库连接
    /// </summary>
    public class EFDbContext : DbContext
    {
        public DbSet<User_EFCore> User { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
          => options.UseMySQL("Database=orm_test;Data Source=localhost;Port=3306;User Id=root;Password=123456w.;Charset=utf8;");
    }
}
