﻿using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Domain.CustomEntities;

[Serializable]
public class PagedList<T> : List<T>
{
    [JsonConstructor]
    public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
    {
        TotalCount = count;
        PageSize = pageSize;
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        AddRange(items);
    }

    [JsonConstructor]
    public PagedList()
    {
    }

    private int CurrentPage { get; }

    public int TotalPages { get; set; }

    private int PageSize { get; }

    public int TotalCount { get; set; }

    private bool HasPreviousPage => CurrentPage > 1;
    private bool HasNextPage => CurrentPage < TotalPages;
    public int? PrevPageNumber => HasPreviousPage ? CurrentPage - 1 : null;
    public int? NextPageNumber => HasNextPage ? CurrentPage + 1 : null;

    public static async Task<PagedList<T>> Create(IQueryable<T> source, int pageNumber, int pageSize,
        CancellationToken token)
    {
        var count = source.Count();
        var items = await source
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(token);
        return new PagedList<T>(items, count, pageNumber, pageSize);
    }

    public static PagedList<T> Create(IEnumerable<T> source, int pageNumber, int pageSize)
    {
        var enumerable = source as T[] ?? source.ToArray();
        var count = enumerable.Length;
        var items = enumerable.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        return new PagedList<T>(items, count, pageNumber, pageSize);
    }

    public static async Task<PagedList<T>> Create(IQueryable<T> source, int pageNumber, int pageSize)
    {
        var count = source.Count();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PagedList<T>(items, count, pageNumber, pageSize);
    }

    public class PaginationEntityStruct<TA> where TA : struct
    {
        public PaginationEntityStruct()
        {
            Items = new List<TA>();
        }

        public IEnumerable<TA> Items { get; set; }
    }
}