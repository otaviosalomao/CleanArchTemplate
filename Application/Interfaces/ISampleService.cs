using Domain.Entities;

namespace Application.Interfaces
{
    public interface ISampleService
    {
        Task<Sample> GetSampleByIdAsync(int id);
        Task<Sample> AddSampleAsync(Sample customer);
        Task<bool> UpdateSampleAsync(Sample customer);
        Task<bool> DeleteSampleAsync(int id);
    }
}
