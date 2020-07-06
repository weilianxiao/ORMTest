using SqlSugar;
using System;

namespace ORM_Test_Model
{
    [SugarTable("User")]
    public class User_Sugar
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }
        public string Username { get; set; } 
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public short Sex { get; set; }
        public DateTime BrithDay { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int CreateId { get; set; }
        public short IsDelete { get; set; }
    }
}
