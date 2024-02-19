using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WSH_HomeAssignment.Domain.Repositories;

namespace WSH_HomeAssignment.Infrastructure.Data.Repositories
{
    internal class PagedResultBuilder<T>
        where T : class
    {
        private Expression<Func<T, bool>>? filter;
        private IPaginationArgs? args;
        private string[]? includes;
        public IQueryable<T> Queryable { get; }

        public PagedResultBuilder(IQueryable<T> queryable)
        {
            Queryable = queryable;
        }

        public PagedResultBuilder<T> SetFilter(Expression<Func<T, bool>>? filter)
        {
            this.filter = filter;
            return this;
        }

        public PagedResultBuilder<T> SetPaginationArgs(IPaginationArgs args)
        {
            this.args = args;
            return this;
        }

        public PagedResultBuilder<T> SetIncludes(params string[] includes)
        {
            this.includes = includes;
            return this;
        }

        public async Task<PagedResult<T>> ToPagedResultAsync(CancellationToken cancellationToken = default)
        {
            return await ToPagedResultAsync(i => i, cancellationToken);
        }

        public async Task<PagedResult<TResult>> ToPagedResultAsync<TResult>(Expression<Func<T, TResult>> transform, CancellationToken cancellationToken = default)
        {
            var queryable = Queryable;
            if (filter != null)
            {
                queryable = Queryable.Where(filter);
            }
            var totalCount = await queryable.CountAsync(cancellationToken);
            if (totalCount == 0)
            {
                return new PagedResult<TResult>(totalCount, args, new List<TResult>());
            }
            if (args != null)
            {
                if (args.Skip > 0)
                {
                    queryable = queryable.Skip(args.Skip);
                }
                if (args.Take > 0)
                {
                    queryable = queryable.Take(args.Take);
                }
            }
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    queryable = queryable.Include(item);
                }
            }
            return new PagedResult<TResult>(totalCount, args, await queryable.Select(transform).ToListAsync(cancellationToken));
        }
    }
}