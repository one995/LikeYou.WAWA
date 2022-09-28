using MySqlX.XDevAPI;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LikeYou.WAWA.Dal
{
    public class BaseDao<T> : DbDao, IBaseDao<T> where T : class, new()
    {
        public async Task<T> Add(T model) => await RWDb.Saveable<T>(model).ExecuteReturnEntityAsync();

        public async Task<int> AddT(T model) => await RWDb.Saveable<T>(model).ExecuteCommandAsync();
        public async Task<List<T>> Add(List<T> models) => await RWDb.Saveable<T>(models).ExecuteReturnListAsync();

        public async Task<bool> Delete(T ID) => await RWDb.Deleteable<T>().Where(ID).ExecuteCommandHasChangeAsync();

        public async Task<T> GetModel(Expression<Func<T, bool>> column) => await RWDb.Queryable<T>().Where(column).FirstAsync();

        public async Task<List<T>> GetModels(Expression<Func<T, bool>> column, int count) => await RWDb.Queryable<T>().Where(column).Take(count).ToListAsync();

        public async Task<bool> Update(T Model) => await RWDb.Updateable<T>(Model).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandHasChangeAsync();
        public async Task<bool> Update(List<T> models) => await RWDb.Updateable<T>(models).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandHasChangeAsync();

        public async Task<List<T>> GetPageList(Expression<Func<T, bool>> column, int pageIndex, int pageSize, RefAsync<int> totalCount) => await RWDb.Queryable<T>().Where(column).ToPageListAsync(pageIndex, pageSize, totalCount);

        public async Task<List<T>> GetPageListWhere(Expression<Func<T, bool>> column, int pageIndex, int pageSize, RefAsync<int> totalCount, Expression<Func<T, bool>> wherecolumn1 = null, Expression<Func<T, bool>> wherecolumn2 = null, Expression<Func<T, bool>> wherecolumn3 = null) => await RWDb.Queryable<T>()
            .WhereIF(wherecolumn1!=null, wherecolumn1)
             .WhereIF(wherecolumn2!=null, wherecolumn2)
             .WhereIF(wherecolumn3!=null, wherecolumn3)
            .Where(column)
            .ToPageListAsync(pageIndex, pageSize, totalCount);

        public async Task<List<T>> GetPageListIndex(Expression<Func<T, bool>> column, OrderByType byType, Expression<Func<T, object>> orderFilds, int pageIndex, int pageSize, RefAsync<int> totalCount) => await RWDb.Queryable<T>().Where(column).OrderBy(orderFilds, byType).ToPageListAsync(pageIndex, pageSize, totalCount);

        public async Task<bool> DeleteWhere(Expression<Func<T, bool>> where)
        {
            return await RWDb.Deleteable<T>().Where(where).ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> Update(T model, Expression<Func<T, bool>> expression)
        {
            return await RWDb.Updateable<T>(model).IgnoreColumns(ignoreAllNullColumns: true).Where(expression).ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> UpdateColumns(T model)
        {
            return await RWDb.Updateable<T>(model).IgnoreColumns(ignoreAllNullColumns: true).ExecuteCommandHasChangeAsync();
        }
        /// <summary>
        /// 根据条件 查询
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public async Task<List<T>> getByWhere(Expression<Func<T, bool>> where, bool isOrderBy = false, Expression<Func<T, object>> orderBy = null, OrderByType orderByType = OrderByType.Asc)
        {
            return await RWDb.Queryable<T>().Where(where).OrderByIF(isOrderBy, orderBy, orderByType).ToListAsync();
        }

        /// <summary>
        /// 判断是否存在这条记录
        /// </summary>
        /// <param name="where">条件</param>
        /// <returns></returns>
        public async Task<bool> getIsAny(Expression<Func<T, bool>> where)
        {
            return await RWDb.Queryable<T>().AnyAsync(where);
        }

        public async Task<bool> Update(T model, Expression<Func<T, object>> expression)
        {
            return await RWDb.Updateable<T>(model).IgnoreColumns(ignoreAllNullColumns: true).WhereColumns(expression).ExecuteCommandHasChangeAsync();
        }

        public async Task<int> Count(Expression<Func<T, bool>> expression, Expression<Func<T, object>> GRexpression = null)
        {
            if (GRexpression!=null)
            {
                return await RWDb.Queryable<T>().Where(expression).GroupBy(GRexpression).CountAsync();
            }
            return await RWDb.Queryable<T>().Where(expression).CountAsync();
        }
    }
}
