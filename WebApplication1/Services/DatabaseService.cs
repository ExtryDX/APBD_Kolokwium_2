using System.Globalization;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Dal;
using WebApplication1.Dto;
using WebApplication1.Exceptions;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class DatabaseService : IDatabaseService
{
    private readonly DatabaseContext _context;

    public DatabaseService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<NurseryBatchDto> GetNurseryBatchAsync(int id)
    {
        var nurseryBatch = await _context.Nurseries.Select(e => new NurseryBatchDto()
            {
                NurseryId = e.NurseryId,
                Name = e.Name,
                EstablishDate = e.EstablishedDate,
                Batches = e.SeedlingBatches.Select(e2 => new BatchDto()
                {
                    BatchId = e2.BatchId,
                    Quantity = e2.Quantity,
                    SownDate = e2.SownDate,
                    ReadyDate = e2.ReadyDate,
                    Species = new SpeciesDto()
                    {
                        LatinName = e2.TreeSpecies.LatinName,
                        GrowthTimeInYears = e2.TreeSpecies.GrowthTimeInYears
                    },
                    Responsibles = e2.Responsibles.Select(e3 => new ResponsibleDto()
                    {
                        FirstName = e3.Employee.FirstName,
                        LastName = e3.Employee.LastName,
                        Role = e3.Role
                    }).ToList()
                    
                }).ToList()
            }
        ).FirstOrDefaultAsync(e => e.NurseryId == id);

        if (nurseryBatch == null)
        {
            throw new CultureNotFoundException("Nursery not found");
        }
        
        return nurseryBatch;
    }

    public async Task PostNurseryAsync(BatchPostDto batchPostDto)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var speciesExist = await _context.TreeSpecies.Where(e => e.LatinName == batchPostDto.Species).FirstOrDefaultAsync();

            if (speciesExist == null)
            {
                throw new NotFoundException("Species not found");
            }

            var nurseryExisst =
                await _context.Nurseries.Where(e => e.Name == batchPostDto.Nursery).FirstOrDefaultAsync();
            if (nurseryExisst == null)
            {
                throw new NotFoundException("Nursery not found");
            }

            var batch = new SeedlingBatch()
            {
                NurseryId = nurseryExisst.NurseryId,
                SpeciesId = speciesExist.SpeciesId,
                Quantity = batchPostDto.Quantity,
                SownDate = DateTime.Now
            };
            
            await  _context.SeedlingBatches.AddAsync(batch);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

        }
        catch (NotFoundException e)
        {
            await transaction.RollbackAsync();
            Console.WriteLine(e.Message);
            throw;
        }
        
    }
}