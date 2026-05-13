using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Domain.Model.Commands;

namespace Bovix_Platform.RanchManagement.Domain.Services;

public interface IVaccineCommandService
{
    Task<Vaccine?> Handle(CreateVaccineCommand command);
    
    Task<Vaccine?> Handle(UpdateVaccineCommand command);
    
    Task<Vaccine?> Handle(DeleteVaccineCommand command);
}