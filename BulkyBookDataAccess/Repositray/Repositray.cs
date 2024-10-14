﻿using BulkyBookDataAccess.Data;
using BulkyBookDataAccess.Repositray.IRepositray;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BulkyBookDataAccess.Repositray
{
    public class Repository<T> : IRepositray<T> where T : class
    {
        private readonly AppDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(AppDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            //_db.Categories == dbSet
            //_db.Products.Include(u => u.Category).Include(u => u.CategoryId);
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filtter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filtter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        //public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        //{
        //    IQueryable<T> query;
        //    if (tracked)
        //    {
        //        query = dbSet;

        //    }
        //    else
        //    {
        //        query = dbSet.AsNoTracking();
        //    }

        //    query = query.Where(filter);
        //    if (!string.IsNullOrEmpty(includeProperties))
        //    {
        //        foreach (var includeProp in includeProperties
        //            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            query = query.Include(includeProp);
        //        }
        //    }
        //    return query.FirstOrDefault();

        //}

        //public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter, string? includeProperties = null)
        //{
        //    IQueryable<T> query = dbSet;
        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }
        //    if (!string.IsNullOrEmpty(includeProperties))
        //    {
        //        foreach (var includeProp in includeProperties
        //            .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            query = query.Include(includeProp);
        //        }
        //    }
        //    return query.ToList();
        //}

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
