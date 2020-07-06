using ORM_Test_Common;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ORM_Test_Repository_SqlSugar
{
    public class SugarBaseRepository<T, TKey> where T : class, new()
    {
        /// <summary>
        /// 数据库连接对象
        /// </summary>
        public SqlSugarClient MyDb
        {
            get
            {
                return SugarFactory.GetDbContext();
            }
        }

        /// <summary>
        /// 通过主键获取实体
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns></returns>
        public T GetById(TKey key)
        {
            try
            {
                return MyDb.Queryable<T>().InSingle(key);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 通过Lambda表达式获取符合条件的第一个实体
        /// </summary>
        /// <param name="lambda"></param>
        /// <returns></returns>
        public T GetEntity(Expression<Func<T, bool>> lambda)
        {
            try
            {
                return MyDb.Queryable<T>().Where(lambda).First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 按id集合获取List
        /// </summary>
        /// <param name="idList">主键集合</param>
        /// <returns></returns>
        public List<T> GetByIdList(List<TKey> idList)
        {
            try
            {
                return MyDb.Queryable<T>().In(idList).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 通过指定列集合获取List
        /// </summary>
        /// <param name="idList">主键集合</param>
        /// <returns></returns>
        public List<T> GetByIdList(Expression<Func<T, object>> lambda, List<TKey> idList)
        {
            try
            {
                return MyDb.Queryable<T>().In(lambda, idList).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 获取所有 不建议使用
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            try
            {
                return MyDb.Queryable<T>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 通过sql语句获取List
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public List<T> GetList(string sql)
        {
            try
            {
                return MyDb.Queryable<T>(sql).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 通过Lambda表达式获取List
        /// </summary>
        /// <param name="lambda"></param>
        /// <returns></returns>
        public List<T> GetList(Expression<Func<T, bool>> lambda)
        {
            try
            {
                return MyDb.Queryable<T>().Where(lambda).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        //public PageList<TDestination> GetPageList<TSource, TDestination>(int pageIndex, int pageSize) where TDestination : class
        //{
        //    try
        //    {
        //        var totalCount = 0;
        //        var list = MyDb.Queryable<TSource>().ToPageList(pageIndex, pageSize, ref totalCount).EmitMapListTo<TSource, TDestination>();
        //        var pageList = new PageList<TDestination>();
        //        pageList.RecordList = list;
        //        pageList.TotalCount = totalCount;
        //        if (totalCount == 0)
        //        {
        //            pageList.Status = false;
        //            pageList.Message = "无数据";
        //        }
        //        pageList.CurrentIndex = pageIndex;
        //        if (pageIndex > pageList.TotalPageCount)
        //        {
        //            pageList.Status = false;
        //            pageList.Message = "分页查询溢出";
        //        }
        //        return pageList;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}


        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Insert(T entity)
        {
            try
            {
                return MyDb.Insertable(entity).ExecuteCommand();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 批量插入实体
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public virtual int InsertList(List<T> list)
        {
            try
            {
                var count = MyDb.Insertable(list ?? new List<T>()).ExecuteCommand();
                return count;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 批量事务插入实体
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public virtual int InsertListByTran(List<T> list)
        {
            try
            {
                MyDb.BeginTran();
                var count = MyDb.Insertable(list ?? new List<T>()).ExecuteCommand();
                MyDb.CommitTran();
                return count;
            }
            catch (Exception ex)
            {
                MyDb.RollbackTran();
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update(T entity)
        {
            try
            {
                return MyDb.Updateable(entity).ExecuteCommand();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 批量更新实体
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public virtual int UpdateList(List<T> list)
        {
            try
            {
                MyDb.BeginTran();
                var count= MyDb.Updateable(list ?? new List<T>()).ExecuteCommand();
                MyDb.CommitTran();
                return count;
            }
            catch (Exception ex)
            {
                MyDb.RollbackTran();
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 按主键删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Delele(TKey key)
        {
            try
            {
                return MyDb.Deleteable<T>().In(key).ExecuteCommand();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 通过Lambda表达式删除对应主键集合
        /// </summary>
        /// <param name="lambda"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public virtual int DeleleByIdList(Expression<Func<T, object>> lambda, List<TKey> idList)
        {
            try
            {
                MyDb.BeginTran();
                var count = MyDb.Deleteable<T>().In(lambda, idList).ExecuteCommand();
                MyDb.CommitTran();
                return count;
            }
            catch (Exception ex)
            {
                MyDb.RollbackTran();
                throw new Exception(ex.Message);
            }
        }
    }
}
