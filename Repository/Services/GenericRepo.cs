using CQRS_and_MediatR.Core.DTOs.General;
using CQRS_and_MediatR.DataContext;
using CQRS_and_MediatR.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CQRS_and_MediatR.Repository.Services
{
    public class GenericRepo<T, TKey> : IGenericRepo<T, TKey> where T : class
    {
        private readonly TaskMangementDbContext _context;
        public GenericRepo(TaskMangementDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "This Entity is not found");
            }
            entity.GetType().GetProperty("IsDeleted").SetValue(entity, false);
            entity.GetType().GetProperty("CreatedDate").SetValue(entity, DateTime.Now);
            entity.GetType().GetProperty("Status").SetValue(entity, true);

            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            
        }

        public async Task<GeneralResponseDto> DeleteByIdAsync(TKey id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
            entity.GetType().GetProperty("Status").SetValue(entity, false);
            entity.GetType().GetProperty("UpdatedDate").SetValue(entity, DateTime.Now);

            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return new GeneralResponseDto 
            {
                IsSucceed=true,
                StatusCode = StatusCodes.Status200OK,
                Message = "Data Delete Successfully"
            };

        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(TKey id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            var checkIsDeleted = (bool)entity.GetType().GetProperty("IsDeleted").GetValue(entity);
            var checkStatus = (bool)entity.GetType().GetProperty("Status").GetValue(entity);
            if (checkIsDeleted && !checkStatus)
            {
                throw new ArgumentNullException(nameof(entity), "This Entity is not found");
            }
            return entity;
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
