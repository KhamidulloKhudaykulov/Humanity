﻿using SharedKernel.Domain.Specifications;
using System.Linq.Expressions;

namespace LessonModule.Domain.Specifications;

public abstract class BaseSpecification<T> : ISpecification<T>
{
    public Expression<Func<T, bool>>? Criteria { get; set; }

    public List<Expression<Func<T, object>>> Includes => new();

    public Expression<Func<T, object>>? OrderBy { get; protected set; }

    public Expression<Func<T, object>>? OrderByDescending { get; protected set; }

    public bool? IsPagingEnabled => Take.HasValue && Skip.HasValue;

    public int? Take { get; protected set; }

    public int? Skip { get; protected set; }

    protected void AddInclude(Expression<Func<T, object>> includeExpression)
        => Includes.Add(includeExpression);

    protected void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
     => OrderBy = orderByExpression;

    protected void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        => OrderByDescending = orderByDescExpression;

    protected void ApplyPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
    }
}
