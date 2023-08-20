using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp.Models.Contexts;

namespace WebApp.Repositories
{
	// Base repository class for data operations on TEntity
	public abstract class DataRepository<TEntity> where TEntity : class
	{
		private readonly DataContext _context; // Data context for accessing the database

		protected DataRepository(DataContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		// Adds a new entity to the database
		public virtual async Task<TEntity> AddAsync(TEntity entity)
		{
			_context.Set<TEntity>().Add(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		// Retrieves a single entity based on the provided expression
		public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
		{
			return await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
		}

		// Retrieves all entities of type TEntity from the database
		public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			return await _context.Set<TEntity>().ToListAsync();
		}

		// Updates an existing entity in the database
		public virtual async Task<TEntity> UpdateAsync(TEntity entity)
		{
			_context.Set<TEntity>().Update(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		// Deletes an existing entity from the database
		public virtual async Task<bool> DeleteAsync(TEntity entity)
		{
			try
			{
				_context.Set<TEntity>().Remove(entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
