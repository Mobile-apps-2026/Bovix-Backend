using Bovix_Platform.RanchManagement.Domain.Model.Aggregates;
using Bovix_Platform.RanchManagement.Domain.Model.Commands;
using Bovix_Platform.RanchManagement.Domain.Repositories;
using Bovix_Platform.RanchManagement.Domain.Services;
using Bovix_Platform.Shared.Domain.Repositories;

namespace Bovix_Platform.RanchManagement.Application.Internal.CommandServices;

public class FeedingPlanCommandService(
    IFeedingPlanRepository repository,
    IUnitOfWork unitOfWork) : IFeedingPlanCommandService
{
    public async Task<FeedingPlan?> Handle(CreateFeedingPlanCommand command)
    {
        var plan = new FeedingPlan(command);
        await repository.AddAsync(plan);
        await unitOfWork.CompleteAsync();
        return plan;
    }

    public async Task<FeedingPlan?> Handle(UpdateFeedingPlanCommand command)
    {
        var plan = await repository.FindByIdAsync(command.Id)
            ?? throw new Exception($"FeedingPlan with ID '{command.Id}' not found.");
        plan.Update(command);
        repository.Update(plan);
        await unitOfWork.CompleteAsync();
        return plan;
    }

    public async Task<FeedingPlan?> Handle(DeleteFeedingPlanCommand command)
    {
        var plan = await repository.FindByIdAsync(command.Id)
            ?? throw new Exception($"FeedingPlan with ID '{command.Id}' not found.");
        repository.Remove(plan);
        await unitOfWork.CompleteAsync();
        return plan;
    }

    public async Task<FeedingComponent?> Handle(AddFeedingComponentCommand command)
    {
        var plan = await repository.FindByIdAsync(command.FeedingPlanId)
            ?? throw new Exception($"FeedingPlan with ID '{command.FeedingPlanId}' not found.");
        var component = new FeedingComponent(command.Name, command.Percentage, command.AmountKg, plan.Id);
        await repository.AddComponentAsync(component);
        await unitOfWork.CompleteAsync();
        return component;
    }
}
