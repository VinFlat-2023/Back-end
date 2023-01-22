using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Utilities.Extensions;

/// <summary>
///     Linq Extension
/// </summary>
public static class LinqExtension
{
    /// <summary>
    ///     IncludeMany
    /// </summary>
    /// <typeparam name="TEntity">Entity</typeparam>
    /// <typeparam name="TProperty">Property</typeparam>
    /// <param name="source">source</param>
    /// <param name="navigationPropertyPath">Navigation Property Path</param>
    /// <param name="nextProperties">NextProperties</param>
    /// <returns>List of entity</returns>
    public static IQueryable<TEntity> IncludeMany<TEntity, TProperty>(
        [NotNull] this IQueryable<TEntity> source,
        [NotNull] Expression<Func<TEntity, TProperty>> navigationPropertyPath,
        [NotNull] params Expression<Func<TProperty, object>>[] nextProperties
    )
        where TEntity : class
    {
        foreach (var nextProperty in nextProperties)
            source = source.Include(navigationPropertyPath)
                .ThenInclude(nextProperty);

        return source;
    }

    /// <summary>
    ///     IncludeMany
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    /// <param name="source"></param>
    /// <param name="navigationPropertyPath"></param>
    /// <param name="nextProperties"></param>
    /// <returns></returns>
    public static IQueryable<TEntity> IncludeMany<TEntity, TProperty>(
        [NotNull] this IQueryable<TEntity> source,
        [NotNull] Expression<Func<TEntity, IEnumerable<TProperty>>> navigationPropertyPath,
        [NotNull] params Expression<Func<TProperty, object>>[] nextProperties)
        where TEntity : class
    {
        foreach (var nextProperty in nextProperties)
            source = source.Include(navigationPropertyPath)
                .ThenInclude(nextProperty);

        return source;
    }
}