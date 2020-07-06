using EmitMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORM_Test_Common
{
    public static class EmitMapperHelper
    {
        /// <summary>
        /// 单实体映射
        /// </summary>
        public static TTo EmitMapperTo<TFrom, TTo>(this TFrom obj)
        {
            if (obj == null)
                return default;
            return ObjectMapperManager.DefaultInstance.GetMapper<TFrom, TTo>().Map(obj);
        }

        /// <summary>
        /// 对象列表映射
        /// </summary>
        /// <typeparam name="TFrom"></typeparam>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="sources"></param>
        /// <returns></returns>
        public static List<TTo> EmitMapperListTo<TFrom, TTo>(this List<TFrom> sources)
        {
            ObjectsMapper<TFrom, TTo> mapper = ObjectMapperManager.DefaultInstance.GetMapper<TFrom, TTo>();
            var list = mapper.MapEnum((IList<TFrom>)sources).ToList();
            return list;
        }
    }
}
