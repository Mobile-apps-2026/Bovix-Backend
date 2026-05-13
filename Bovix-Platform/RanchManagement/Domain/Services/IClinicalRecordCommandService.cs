using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Domain.Model.Commands;

namespace Bovix_Platform.RanchManagement.Domain.Services;

public interface IClinicalRecordCommandService
{
    Task<ClinicalRecord?> Handle(CreateClinicalRecordCommand command);
    Task<ClinicalRecord?> Handle(UpdateClinicalRecordCommand command);
    Task<ClinicalRecord?> Handle(DeleteClinicalRecordCommand command);
}
