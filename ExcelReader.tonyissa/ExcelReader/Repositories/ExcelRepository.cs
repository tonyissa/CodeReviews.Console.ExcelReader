﻿using Microsoft.EntityFrameworkCore;

namespace ExcelReader.Repositories;

public class ExcelRepository<TEntity, TContext> : IExcelRepository<TEntity, TContext>
    where TContext : DbContext
    where TEntity : class
{
    private readonly TContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public ExcelRepository(TContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task CommitEntryAsync(TEntity entry)
    {
        _dbSet.Add(entry);
        await _context.SaveChangesAsync();
    }

    public async Task<TEntity[]> RetrieveEntriesAsync()
    {
        return await _dbSet.ToArrayAsync();
    }
}