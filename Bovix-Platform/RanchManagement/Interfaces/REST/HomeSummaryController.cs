using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Bovix_Platform.IAM.Domain.Model.Aggregates;
using Bovix_Platform.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Bovix_Platform.RanchManagement.Domain.Model.Queries;
using Bovix_Platform.RanchManagement.Domain.Services;

namespace Bovix_Platform.RanchManagement.Interfaces.REST;

[Authorize]
[ApiController]
[Route("/api/v1/home")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Home")]
public class HomeSummaryController(
    IBovineQueryService bovineQueryService,
    IAppointmentQueryService appointmentQueryService,
    IVaccineQueryService vaccineQueryService) : ControllerBase
{
    /// <summary>
    /// Returns an aggregated summary for the home screen.
    /// </summary>
    [HttpGet("summary")]
    [SwaggerOperation(Summary = "Get home summary", OperationId = "GetHomeSummary")]
    public async Task<IActionResult> GetHomeSummary()
    {
        var currentUser = HttpContext.Items["User"] as User;
        var userName = currentUser?.Username ?? "Usuario";

        var bovines = (await bovineQueryService.Handle(new GetAllBovinesQuery())).ToList();
        var appointments = (await appointmentQueryService.Handle(new GetAllAppointmentsQuery())).ToList();
        var vaccines = (await vaccineQueryService.Handle(new GetAllVaccinesQuery())).ToList();

        var totalAnimals = bovines.Count;
        var activeLots = bovines.Select(b => b.Lot).Where(l => !string.IsNullOrEmpty(l)).Distinct().Count();
        var today = DateTime.UtcNow.Date;
        var appointmentsToday = appointments.Count(a => a.ScheduledAt.Date == today);
        var alertCount = vaccines.Count;

        var firstVaccine = vaccines.FirstOrDefault();
        object? alert = firstVaccine is not null
            ? new
            {
                title = "Vacuna pendiente",
                description = $"Vacuna: {firstVaccine.Name}"
            }
            : null;

        var response = new
        {
            userName,
            stats = new
            {
                totalAnimals,
                activeLots,
                appointmentsToday,
                alerts = alertCount
            },
            alert,
            activities = Array.Empty<object>()
        };

        return Ok(response);
    }
}
