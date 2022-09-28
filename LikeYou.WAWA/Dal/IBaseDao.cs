using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LikeYou.WAWA.Dal
{
    interface IBaseDao<T> where T : class, new()
    {
        /// <summary>
        /// 新增一个
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<T> Add(T model);
        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        Task<List<T>> Add(List<T> models);
        /// <summary>
        /// 删除一个
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Task<bool> Delete(T ID);
        /// <summary>
        /// 更新一个
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        Task<bool> Update(T Model);
        /// <summary>
        /// 批量更新呢
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        Task<bool> Update(List<T> models);
        /// <summary>
        /// 获取单个model
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        Task<T> GetModel(Expression<Func<T, bool>> column);

        /// <summary>
        /// 批量查询，默认查询前1000条
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        Task<List<T>> GetModels(Expression<Func<T, bool>> column, int count = 200);
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex">第n页</param>
        /// <param name="pageSize">单页数据量</param>
        /// <param name="totalCount">总数</param>
        /// <returns></returns>
        Task<List<T>> GetPageList(Expression<Func<T, bool>> column, int pageIndex, int pageSize, RefAsync<int> totalCount);
        /// <summary>
        /// 条件删除
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<bool> DeleteWhere(Expression<Func<T, bool>> where);

        /// <summary>
        /// 根据指定 列条件 更新 ，并返回操作是否成功
        /// </summary>
        /// <param name="model">实体对象</param>
        /// <param name="expression">列条件 例如： t=>t.id>5 </param>
        Task<bool> Update(T model, Expression<Func<T, object>> expression);

        /// <summary>
        /// 根据主键，更新指定列,返回操作是否成功
        /// </summary>
        /// <param name="model">实体对象</param>
        /// <param name="columns">要更新的列</param>
        /// <returns></returns>
        Task<bool> UpdateColumns(T model);
    }
}
