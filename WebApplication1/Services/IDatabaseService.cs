using WebApplication1.Dto;

namespace WebApplication1.Services;

public interface IDatabaseService
{
    Task<NurseryBatchDto> GetNurseryBatchAsync(int id);
    Task PostNurseryAsync(BatchPostDto batchPostDto);
}