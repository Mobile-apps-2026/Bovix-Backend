using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Domain.Model.Commands;
using Bovix_Platform.RanchManagement.Domain.Repositories;
using Bovix_Platform.RanchManagement.Domain.Services;
using Bovix_Platform.Shared.Domain.Repositories;

namespace Bovix_Platform.RanchManagement.Application.Internal.CommandServices;

public class AppointmentCommandService(
    IAppointmentRepository repository,
    IUnitOfWork unitOfWork) : IAppointmentCommandService
{
    public async Task<Appointment?> Handle(CreateAppointmentCommand command)
    {
        var appointment = new Appointment(command);
        await repository.AddAsync(appointment);
        await unitOfWork.CompleteAsync();
        return appointment;
    }

    public async Task<Appointment?> Handle(UpdateAppointmentCommand command)
    {
        var appointment = await repository.FindByIdAsync(command.Id)
            ?? throw new Exception($"Appointment with ID '{command.Id}' not found.");
        appointment.Update(command);
        repository.Update(appointment);
        await unitOfWork.CompleteAsync();
        return appointment;
    }

    public async Task<Appointment?> Handle(DeleteAppointmentCommand command)
    {
        var appointment = await repository.FindByIdAsync(command.Id)
            ?? throw new Exception($"Appointment with ID '{command.Id}' not found.");
        repository.Remove(appointment);
        await unitOfWork.CompleteAsync();
        return appointment;
    }
}
