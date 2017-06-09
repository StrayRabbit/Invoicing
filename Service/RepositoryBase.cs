using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Domain;
using System.Linq.Expressions;
using System.Collections;

namespace Service
{
    /// <summary>
    /// 数据操作基本实现类，公用实现方法
    /// add yuangang by 2016-05-10
    /// </summary>
    /// <typeparam name="T">具体操作的实体模型</typeparam>
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        #region 固定公用帮助，含事务

        private DbContext context = new MyConfig().db;
        /// <summary>
        /// 数据上下文--->根据Domain实体模型名称进行更改
        /// </summary>
        public DbContext Context
        {
            get
            {
                context.Configuration.ValidateOnSaveEnabled = false;
                return context;
            }
        }
        /// <summary>
        /// 数据上下文--->拓展属性
        /// </summary>
        public MyConfig Config
        {
            get
            {
                return new MyConfig();
            }
        }
        /// <summary>
        /// 公用泛型处理属性
        /// 注:所有泛型操作的基础
        /// </summary>
        public DbSet<T> dbSet
        {
            get { return this.Context.Set<T>(); }
        }
        /// <summary>
        /// 事务
        /// </summary>
        private DbContextTransaction _transaction = null;
        /// <summary>
        /// 开始事务
        /// </summary>
        public DbContextTransaction Transaction
        {
            get
            {
                if (this._transaction == null)
                {
                    this._transaction = this.Context.Database.BeginTransaction();
                }
                return this._transaction;
            }
            set { this._transaction = value; }
        }
        /// <summary>
        /// 事务状态
        /// </summary>
        public bool Committed { get; set; }
        /// <summary>
        /// 异步锁定
        /// </summary>
        private readonly object sync = new object();
        /// <summary>
        /// 提交事务
        /// </summary>
        public void Commit()
        {
            if (!Committed)
            {
                lock (sync)
                {
                    if (this._transaction != null)
                        _transaction.Commit();
                }
                Committed = true;
            }
        }
        /// <summary>
        /// 回滚事务
        /// </summary>
        public void Rollback()
        {
            Committed = false;
            if (this._transaction != null)
                this._transaction.Rollback();
        }
        #endregion

        #region 获取单条记录
        /// <summary>
        /// 通过lambda表达式获取一条记录p=>p.id==id
        /// </summary>
        public virtual T Get(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return dbSet.AsNoTracking().SingleOrDefault(predicate);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region 增删改操作

        /// <summary>
        /// 添加一条模型记录，自动提交更改
        /// </summary>
        public virtual bool Save(T entity)
        {
            try
            {
                int row = 0;
                var entry = this.Context.Entry<T>(entity);
                entry.State = System.Data.Entity.EntityState.Added;
                row = Context.SaveChanges();
                entry.State = System.Data.Entity.EntityState.Detached;
                return row > 0;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        /// <summary>
        /// 更新一条模型记录，自动提交更改
        /// </summary>
        public virtual bool Update(T entity)
        {
            try
            {
                int rows = 0;
                var entry = this.Context.Entry(entity);
                entry.State = System.Data.Entity.EntityState.Modified;
                rows = this.Context.SaveChanges();
                entry.State = System.Data.Entity.EntityState.Detached;
                return rows > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 更新模型记录，如不存在进行添加操作
        /// </summary>
        public virtual bool SaveOrUpdate(T entity, bool isEdit)
        {
            try
            {
                return isEdit ? Update(entity) : Save(entity);
            }
            catch (Exception e) { throw e; }
        }

        /// <summary>
        /// 删除一条或多条模型记录，含事务
        /// </summary>
        public virtual int Delete(Expression<Func<T, bool>> predicate = null)
        {
            try
            {
                int rows = 0;
                IQueryable<T> entry = (predicate == null) ? this.dbSet.AsQueryable() : this.dbSet.Where(predicate);
                List<T> list = entry.ToList();
                if (list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        this.dbSet.Remove(list[i]);
                    }
                    rows = this.Context.SaveChanges();
                }
                return rows;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 使用原始SQL语句,含事务处理
        /// </summary>
        public virtual int DeleteBySql(string sql, params DbParameter[] para)
        {
            try
            {
                return this.Context.Database.ExecuteSqlCommand(sql, para);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region 多模型操作

        /// <summary>
        /// 增加多模型数据，指定独立模型集合
        /// </summary>
        public virtual int SaveList<T1>(List<T1> t) where T1 : class
        {
            try
            {
                if (t == null || t.Count == 0) return 0;
                this.Context.Set<T1>().Local.Clear();
                foreach (var item in t)
                {
                    this.Context.Set<T1>().Add(item);
                }
                return this.Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 增加多模型数据，与当前模型一致
        /// </summary>
        public virtual int SaveList(List<T> t)
        {
            try
            {
                this.dbSet.Local.Clear();
                foreach (var item in t)
                {
                    this.dbSet.Add(item);
                }
                return this.Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 更新多模型，指定独立模型集合
        /// </summary>
        public virtual int UpdateList<T1>(List<T1> t) where T1 : class
        {
            if (t.Count <= 0) return 0;
            try
            {
                foreach (var item in t)
                {
                    this.Context.Entry<T1>(item).State = System.Data.Entity.EntityState.Modified;
                }
                return this.Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 更新多模型，与当前模型一致
        /// </summary>
        public virtual int UpdateList(List<T> t)
        {
            if (t.Count <= 0) return 0;
            try
            {
                foreach (var item in t)
                {
                    this.Context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }
                return this.Context.SaveChanges();
            }
            catch (Exception e) { throw e; }
        }
        /// <summary>
        /// 批量删除数据，当前模型
        /// </summary>
        public virtual int DeleteList(List<T> t)
        {
            if (t == null || t.Count == 0) return 0;
            foreach (var item in t)
            {
                this.dbSet.Remove(item);
            }
            return this.Context.SaveChanges();
        }
        /// <summary>
        /// 批量删除数据，自定义模型
        /// </summary>
        public virtual int DeleteList<T1>(List<T1> t) where T1 : class
        {
            try
            {
                if (t == null || t.Count == 0) return 0;
                foreach (var item in t)
                {
                    this.Context.Set<T1>().Remove(item);
                }
                return this.Context.SaveChanges();
            }
            catch (Exception e) { throw e; }
        }
        #endregion

        #region 存储过程操作
        /// <summary>
        /// 执行返回影响行数的存储过程
        /// </summary>
        /// <param name="procname">过程名称</param>
        /// <param name="parameter">参数对象</param>
        /// <returns></returns>
        public virtual object ExecuteProc(string procname, params DbParameter[] parameter)
        {
            try
            {
                return ExecuteSqlCommand(procname, parameter);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 执行返回结果集的存储过程
        /// </summary>
        /// <param name="procname">过程名称</param>
        /// <param name="parameter">参数对象</param>
        /// <returns></returns>
        public virtual object ExecuteQueryProc(string procname, params DbParameter[] parameter)
        {
            try
            {
                return this.Context.Database.SqlFunctionForDynamic(procname, parameter);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region 存在验证操作
        /// <summary>
        /// 验证当前条件是否存在相同项
        /// </summary>
        public virtual bool IsExist(Expression<Func<T, bool>> predicate)
        {
            var entry = this.dbSet.Where(predicate);
            return (entry.Any());
        }

        /// <summary>
        /// 根据SQL验证实体对象是否存在
        /// </summary>
        public virtual bool IsExist(string sql, params DbParameter[] para)
        {
            IEnumerable result = this.Context.Database.SqlQuery(typeof(int), sql, para);

            if (result.GetEnumerator().Current == null || result.GetEnumerator().Current.ToString() == "0")
                return false;
            return true;
        }
        #endregion

        #region 获取多条数据操作
        /// <summary>
        /// 返回IQueryable集合，延时加载数据
        /// </summary>
        public virtual IQueryable<T> LoadAll(Expression<Func<T, bool>> predicate)
        {
            try
            {
                if (predicate != null)
                {
                    return this.dbSet.Where(predicate).AsNoTracking<T>();
                }
                return this.dbSet.AsQueryable<T>().AsNoTracking<T>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 返回DbQuery集合，延时加载数据
        /// </summary>
        public virtual DbQuery<T> LoadQueryAll(Expression<Func<T, bool>> predicate)
        {
            try
            {
                if (predicate != null)
                {
                    return this.dbSet.Where(predicate) as DbQuery<T>;
                }
                return this.dbSet;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 返回List集合,不采用延时加载
        /// </summary>
        public virtual List<T> LoadListAll(Expression<Func<T, bool>> predicate)
        {
            try
            {
                if (predicate != null)
                {
                    return this.dbSet.Where(predicate).AsNoTracking().ToList();
                }
                return this.dbSet.AsQueryable<T>().AsNoTracking().ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 返回IEnumerable集合，采用原始T-Sql方式
        /// </summary>
        public virtual IEnumerable<T> LoadEnumerableAll(string sql, params DbParameter[] para)
        {
            try
            {
                return this.Context.Database.SqlQuery<T>(sql, para);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 返回IEnumerable动态集合，采用原始T-Sql方式
        /// </summary>
        public virtual System.Collections.IEnumerable LoadEnumerable(string sql, params DbParameter[] para)
        {
            try
            {
                return this.Context.Database.SqlQueryForDynamic(sql, para);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 返回IList集合，采用原始T-Sql方式
        /// </summary>
        public virtual List<T> SelectBySql(string sql, params DbParameter[] para)
        {
            try
            {
                return this.Context.Database.SqlQuery(typeof(T), sql, para).Cast<T>().ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 指定泛型，返回IList集合，采用原始T-Sql方式
        /// </summary>
        public virtual List<T1> SelectBySql<T1>(string sql, params DbParameter[] para)
        {
            try
            {
                return this.Context.Database.SqlQuery<T1>(sql, para).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 可指定返回结果、排序、查询条件的通用查询方法，返回实体对象
        /// </summary>
        /// <typeparam name="TEntity">实体对象</typeparam>
        /// <typeparam name="TOrderBy">排序字段类型</typeparam>
        /// <typeparam name="TResult">数据结果，与TEntity一致</typeparam>
        /// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="selector">返回结果（必须是模型中存在的字段）</param>
        /// <param name="IsAsc">排序方向，true为正序false为倒序</param>
        /// <returns>实体集合</returns>
        public virtual List<TResult> QueryEntity<TEntity, TOrderBy, TResult>
            (Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TOrderBy>> orderby,
            Expression<Func<TEntity, TResult>> selector,
            bool IsAsc)
            where TEntity : class
            where TResult : class
        {
            IQueryable<TEntity> query = this.Context.Set<TEntity>();
            if (where != null)
            {
                query = query.Where(where);
            }

            if (orderby != null)
            {
                query = IsAsc ? query.OrderBy(orderby) : query.OrderByDescending(orderby);
            }
            if (selector == null)
            {
                return query.Cast<TResult>().AsNoTracking().ToList();
            }
            return query.Select(selector).AsNoTracking().ToList();
        }

        /// <summary>
        /// 可指定返回结果、排序、查询条件的通用查询方法，返回Object对象
        /// </summary>
        /// <typeparam name="TEntity">实体对象</typeparam>
        /// <typeparam name="TOrderBy">排序字段类型</typeparam>
        /// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="selector">返回结果（必须是模型中存在的字段）</param>
        /// <param name="IsAsc">排序方向，true为正序false为倒序</param>
        /// <returns>自定义实体集合</returns>
        public virtual List<object> QueryObject<TEntity, TOrderBy>
            (Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TOrderBy>> orderby,
            Func<IQueryable<TEntity>,
            List<object>> selector,
            bool IsAsc)
            where TEntity : class
        {
            IQueryable<TEntity> query = this.Context.Set<TEntity>();
            if (where != null)
            {
                query = query.Where(where);
            }

            if (orderby != null)
            {
                query = IsAsc ? query.OrderBy(orderby) : query.OrderByDescending(orderby);
            }
            if (selector == null)
            {
                return query.AsNoTracking().ToList<object>();
            }
            return selector(query);
        }

        /// <summary>
        /// 可指定返回结果、排序、查询条件的通用查询方法，返回动态类对象
        /// </summary>
        /// <typeparam name="TEntity">实体对象</typeparam>
        /// <typeparam name="TOrderBy">排序字段类型</typeparam>
        /// <param name="where">过滤条件，需要用到类型转换的需要提前处理与数据表一致的</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="selector">返回结果（必须是模型中存在的字段）</param>
        /// <param name="IsAsc">排序方向，true为正序false为倒序</param>
        /// <returns>动态类</returns>
        public virtual dynamic QueryDynamic<TEntity, TOrderBy>
            (Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TOrderBy>> orderby,
            Func<IQueryable<TEntity>,
            List<object>> selector,
            bool IsAsc)
            where TEntity : class
        {
            List<object> list = QueryObject<TEntity, TOrderBy>
                 (where, orderby, selector, IsAsc);
            return Common.JsonConverter.JsonClass(list);
        }
        #endregion

        #region 分页操作
        /// <summary>
        /// 待自定义分页函数，使用必须重写，指定数据模型
        /// </summary>
        public virtual IList<T1> PageByListSql<T1>(string sql, IList<DbParameter> parameters, Common.PageCollection page)
        {
            return null;
        }
        /// <summary>
        /// 待自定义分页函数，使用必须重写，
        /// </summary>
        public virtual IList<T> PageByListSql(string sql, IList<DbParameter> parameters, Common.PageCollection page)
        {
            return null;
        }

        /// <summary>
        /// 对IQueryable对象进行分页逻辑处理，过滤、查询项、排序对IQueryable操作
        /// </summary>
        /// <param name="t">Iqueryable</param>
        /// <param name="index">当前页</param>
        /// <param name="PageSize">每页显示多少条</param>
        /// <returns>当前IQueryable to List的对象</returns>
        public virtual Common.PageInfo<T> Query(IQueryable<T> query, int index, int PageSize)
        {
            if (index < 1)
            {
                index = 1;
            }
            if (PageSize <= 0)
            {
                PageSize = 20;
            }
            int count = query.Count();

            int maxpage = count / PageSize;

            if (count % PageSize > 0)
            {
                maxpage++;
            }
            if (index > maxpage)
            {
                index = maxpage;
            }
            if (count > 0)
                query = query.Skip((index - 1) * PageSize).Take(PageSize);
            return new Common.PageInfo<T>(index, PageSize, count, query.ToList());
        }
        /// <summary>
        /// 通用EF分页，默认显示20条记录
        /// </summary>
        /// <typeparam name="TEntity">实体模型</typeparam>
        /// <typeparam name="TOrderBy">排序类型</typeparam>
        /// <param name="index">当前页</param>
        /// <param name="pageSize">显示条数</param>
        /// <param name="where">过滤条件</param>
        /// <param name="orderby">排序字段</param>
        /// <param name="selector">结果集合</param>
        /// <param name="isAsc">排序方向true正序 false倒序</param>
        /// <returns>自定义实体集合</returns>
        public virtual Common.PageInfo<object> Query<TEntity, TOrderBy>
            (int index, int pageSize,
            Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TOrderBy>> orderby,
            Func<IQueryable<TEntity>,
            List<object>> selector,
            bool isAsc)
            where TEntity : class
        {
            if (index < 1)
            {
                index = 1;
            }

            if (pageSize <= 0)
            {
                pageSize = 20;
            }

            IQueryable<TEntity> query = this.Context.Set<TEntity>();
            if (where != null)
            {
                query = query.Where(where);
            }
            int count = query.Count();

            int maxpage = count / pageSize;

            if (count % pageSize > 0)
            {
                maxpage++;
            }
            if (index > maxpage)
            {
                index = maxpage;
            }

            if (orderby != null)
            {
                query = isAsc ? query.OrderBy(orderby) : query.OrderByDescending(orderby);
            }
            if (count > 0)
                query = query.Skip((index - 1) * pageSize).Take(pageSize);
            //返回结果为null，返回所有字段
            if (selector == null)
                return new Common.PageInfo<object>(index, pageSize, count, query.ToList<object>());
            return new Common.PageInfo<object>(index, pageSize, count, selector(query).ToList());
        }
        /// <summary>
        /// 普通SQL查询分页方法
        /// </summary>
        /// <param name="index">当前页</param>
        /// <param name="pageSize">显示行数</param>
        /// <param name="tableName">表名/视图</param>
        /// <param name="field">获取项</param>
        /// <param name="filter">过滤条件</param>
        /// <param name="orderby">排序字段+排序方向</param>
        /// <param name="group">分组字段</param>
        /// <returns>结果集</returns>
        public virtual Common.PageInfo Query(int index, int pageSize, string tableName, string field, string filter, string orderby, string group, params DbParameter[] para)
        {
            //执行分页算法
            if (index <= 0)
                index = 1;
            int start = (index - 1) * pageSize;
            if (start > 0)
                start -= 1;
            else
                start = 0;
            int end = index * pageSize;

            #region 查询逻辑
            string logicSql = "SELECT";
            //查询项
            if (!string.IsNullOrEmpty(field))
            {
                logicSql += " " + field;
            }
            else
            {
                logicSql += " *";
            }
            logicSql += " FROM (" + tableName + " ) where";
            //过滤条件
            if (!string.IsNullOrEmpty(filter))
            {
                logicSql += " " + filter;
            }
            else
            {
                filter = " 1=1";
                logicSql += "  1=1";
            }
            //分组
            if (!string.IsNullOrEmpty(group))
            {
                logicSql += " group by " + group;
            }

            #endregion

            //获取当前条件下数据总条数
            int count = this.Context.Database.SqlQuery(typeof(int), "select count(*) from (" + tableName + ") where " + filter, para).Cast<int>().FirstOrDefault();
            string sql = "SELECT T.* FROM ( SELECT B.* FROM ( SELECT A.*,ROW_NUMBER() OVER(ORDER BY getdate()) as RN" +
                         logicSql + ") A ) B WHERE B.RN<=" + end + ") T WHERE T.RN>" + start;
            //排序
            if (!string.IsNullOrEmpty(orderby))
            {
                sql += " order by " + orderby;
            }
            var list = ExecuteSqlQuery(sql, para) as IEnumerable;
            if (list != null)
                return new Common.PageInfo(index, pageSize, count, list.Cast<object>().ToList());
            return new Common.PageInfo(index, pageSize, count, new { });
        }

        /// <summary>
        /// 最简单的SQL分页
        /// </summary>
        /// <param name="index">页码</param>
        /// <param name="pageSize">显示行数</param>
        /// <param name="sql">纯SQL语句</param>
        /// <param name="orderby">排序字段与方向</param>
        /// <returns></returns>
        public virtual Common.PageInfo Query(int index, int pageSize, string sql, string orderby, params DbParameter[] para)
        {
            return this.Query(index, pageSize, sql, null, null, orderby, null, para);
        }
        /// <summary>
        /// 多表联合分页算法
        /// </summary>
        public virtual Common.PageInfo Query(IQueryable query, int index, int PageSize)
        {
            var enumerable = (query as System.Collections.IEnumerable).Cast<object>();
            if (index < 1)
            {
                index = 1;
            }
            if (PageSize <= 0)
            {
                PageSize = 20;
            }

            int count = enumerable.Count();

            int maxpage = count / PageSize;

            if (count % PageSize > 0)
            {
                maxpage++;
            }
            if (index > maxpage)
            {
                index = maxpage;
            }
            if (count > 0)
                enumerable = enumerable.Skip((index - 1) * PageSize).Take(PageSize);
            return new Common.PageInfo(index, PageSize, count, enumerable.ToList());
        }
        #endregion

        #region ADO.NET增删改查方法
        /// <summary>
        /// 执行增删改方法,含事务处理
        /// </summary>
        public virtual object ExecuteSqlCommand(string sql, params DbParameter[] para)
        {
            try
            {
                return this.Context.Database.ExecuteSqlCommand(sql, para);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        /// <summary>
        /// 执行多条SQL，增删改方法,含事务处理
        /// </summary>
        public virtual object ExecuteSqlCommand(Dictionary<string, object> sqllist)
        {
            try
            {
                int rows = 0;
                IEnumerator<KeyValuePair<string, object>> enumerator = sqllist.GetEnumerator();
                using (Transaction)
                {
                    while (enumerator.MoveNext())
                    {
                        rows += this.Context.Database.ExecuteSqlCommand(enumerator.Current.Key, enumerator.Current.Value);
                    }
                    Commit();
                }
                return rows;
            }
            catch (Exception e)
            {
                Rollback();
                throw e;
            }

        }
        /// <summary>
        /// 执行查询方法,返回动态类，接收使用var，遍历时使用dynamic类型
        /// </summary>
        public virtual object ExecuteSqlQuery(string sql, params DbParameter[] para)
        {
            try
            {
                return this.Context.Database.SqlQueryForDynamic(sql, para);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}