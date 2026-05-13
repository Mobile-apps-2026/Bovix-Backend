using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Domain.Model.Commands;
using Bovix_Platform.RanchManagement.Domain.Repositories;
using Bovix_Platform.RanchManagement.Domain.Services;
using Bovix_Platform.Shared.Domain.Repositories;

namespace Bovix_Platform.RanchManagement.Application.Internal.CommandServices;

public class ClinicalRecordCommandService(
    IClinicalRecordRepository repository,
    IUnitOfWork unitOfWork) : IClinicalRecordCommandService
{
    public async Task<ClinicalRecord?> Handle(CreateClinicalRecordCommand command)
    {
        var record = new ClinicalRecord(command);
        await repository.AddAsync(record);
        await unitOfWork.CompleteAsync();
        return record;
    }

    public async Task<ClinicalRecord?> Handle(UpdateClinicalRecordCommand command)
    {
        var record = await repository.FindByIdAsync(command.Id)
            ?? throw new Exception($"ClinicalRecord with ID '{command.Id}' not found.");
        record.Update(command);
        repository.Update(record);
        await unitOfWork.CompleteAsync();
        return record;
    }

    public async Task<ClinicalRecord?> Handle(DeleteClinicalRecordCommand command)
    {
        var record = await repository.FindByIdAsync(command.Id)
            ?? throw new Exception($"ClinicalRecord with ID '{command.Id}' not found.");
        repository.Remove(record);
        await unitOfWork.CompleteAsync();
        return record;
    }
}
