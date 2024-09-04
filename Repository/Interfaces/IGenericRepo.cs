using CQRS_and_MediatR.Core.DTOs.General;

namespace CQRS_and_MediatR.Repository.Interfaces
{
    public interface IGenericRepo<T, TKey> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(TKey id);
        Task CreateAsync(T entity);
        Task Update(T entity);
        Task<GeneralResponseDto> DeleteByIdAsync(TKey id);
    }
}
