using Application.Interfaces;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class SampleService : ISampleService
    {
        private readonly ISampleRepository _sampleRepository;

        public SampleService(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public async Task<Sample> GetSampleByIdAsync(int id)
        {
            // Chama o repositório para buscar o cliente pelo ID
            return await _sampleRepository.GetByIdAsync(id);
        }

        public async Task<Sample> AddSampleAsync(Sample sample)
        {
            // Adiciona o cliente usando o repositório e salva as mudanças
            await _sampleRepository.AddAsync(sample);
            return sample;
        }

        public async Task<bool> UpdateSampleAsync(Sample sample)
        {
            // Atualiza o cliente se ele existir no repositório
            var existingSample = await _sampleRepository.GetByIdAsync(sample.Id);
            if (existingSample == null)
            {
                return false;
            }

            existingSample.Name = sample.Name;            
            // Continue atualizando outras propriedades necessárias

            await _sampleRepository.UpdateAsync(existingSample);
            return true;
        }

        public async Task<bool> DeleteSampleAsync(int id)
        {
            // Exclui o cliente pelo ID se ele existir
            var sample = await _sampleRepository.GetByIdAsync(id);
            if (sample == null)
            {
                return false;
            }

            await _sampleRepository.DeleteAsync(sample);
            return true;
        }
    }
}
