using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Bovix_Platform.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using Bovix_Platform.RanchManagement.Domain.Model.Commands;
using Bovix_Platform.RanchManagement.Domain.Model.Queries;
using Bovix_Platform.RanchManagement.Domain.Services;
using Bovix_Platform.RanchManagement.Interfaces.REST.Resources;
using Bovix_Platform.RanchManagement.Interfaces.REST.Transform;

namespace Bovix_Platform.RanchManagement.Interfaces.REST;

/// <summary>
/// API controller for managing bovines
/// </summary>
[Authorize]
[ApiController]
[Route("/api/v1/bovines")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Bovines")]
public class BovineController(IBovineCommandService commandService,
    IBovineQueryService queryService) : ControllerBase
{
    /// <summary>
    /// Posts a new bovine to the system.
    /// </summary>
    /// <param name="resource"></param>
    /// <returns></returns>
    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> CreateBovines([FromForm] CreateBovineResource resource)
    {
        var command = CreateBovineCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await commandService.Handle(command);
        if (result is null) return BadRequest();

        return CreatedAtAction(nameof(GetBovineById), new { id = result.Id },
            BovineResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    /// <summary>
    /// Gets all bovines in the system.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all bovines",
        Description = "Get all bovines",
        OperationId = "GetAllBovine")]
    [SwaggerResponse(StatusCodes.Status200OK, "The list of bovines were found", typeof(IEnumerable<BovineResource>))]
    public async Task<IActionResult> GetAllBovine()
    {
        var bovines = await queryService.Handle(new GetAllBovinesQuery());
        var bovineResources = bovines.Select(BovineResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(bovineResources);
    }

    /// <summary>
    /// Gets a bovine by its ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult> GetBovineById(int id)
    {
        var getBovineById = new GetBovinesByIdQuery(id);
        var result = await queryService.Handle(getBovineById);
        if (result is null) return NotFound();
        var resources = BovineResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resources);
    }

    /// <summary>
    /// Gets all bovines by stable ID.
    /// </summary>
    /// <param name="stableId"></param>
    /// <returns></returns>
    [HttpGet("stable/{stableId}")]
    [SwaggerOperation(
        Summary = "Get all bovines by stable ID",
        Description = "Get all bovines by stable ID",
        OperationId = "GetBovinesByStableId")]
    public async Task<ActionResult> GetBovinesByStableId(int? stableId)
    {
        var getBovinesByStableIdQuery = new GetBovinesByStableIdQuery(stableId);
        var bovines = await queryService.Handle(getBovinesByStableIdQuery);

        if (bovines == null || !bovines.Any())
            return NotFound();

        var bovineResources = bovines.Select(BovineResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(bovineResources);
    }

    /// <summary>
    /// Updates a bovine by its ID.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="resource"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UpdateBovine(int id, [FromForm] UpdateBovineResource resource)
    {
        var command = UpdateBovineCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var result = await commandService.Handle(command);
        if (result is null) return BadRequest();

        return Ok(BovineResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    /// <summary>
    /// Deletes a bovine by its ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBovine(int id)
    {
        var command = new DeleteBovineCommand(id);
        var result = await commandService.Handle(command);
        if (result is null) return NotFound();

        return NoContent();
    }
}

/// <summary>
/// API controller for managing vaccines
/// </summary>
[Authorize]
[ApiController]
[Route("/api/v1/vaccines")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Vaccines")]
public class VaccineController(
   IVaccineCommandService commandService,
   IVaccineQueryService queryService) : ControllerBase
{
    /// <summary>
    /// Posts a new vaccine to the system.
    /// </summary>
    /// <param name="resource"></param>
    /// <returns></returns>
    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> CreateVaccines([FromForm] CreateVaccineResource resource)
    {
        var command = CreateVaccineCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await commandService.Handle(command);
        if (result is null) return BadRequest();

        return CreatedAtAction(nameof(GetVaccineById), new { id = result.Id },
            VaccineResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    /// <summary>
    /// Gets all vaccines in the system.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all vaccines",
        Description = "Get all vaccines",
        OperationId = "GetAllVaccine")]
    [SwaggerResponse(StatusCodes.Status200OK, "The list of vaccines were found", typeof(IEnumerable<VaccineResource>))]
    public async Task<IActionResult> GetAllVaccine()
    {
        var vaccines = await queryService.Handle(new GetAllVaccinesQuery());
        var vaccineResources = vaccines.Select(VaccineResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(vaccineResources);
    }

    /// <summary>
    /// Gets a vaccine by its ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult> GetVaccineById(int id)
    {
        var getVaccineById = new GetVaccinesByIdQuery(id);
        var result = await queryService.Handle(getVaccineById);
        if (result is null) return NotFound();
        var resources = VaccineResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resources);
    }

    /// <summary>
    /// Gets all vaccines by bovine ID.
    /// </summary>
    /// <param name="bovineId"></param>
    /// <returns></returns>
    [HttpGet("bovine/{bovineId}")]
    [SwaggerOperation(
        Summary = "Get all vaccines by bovine ID",
        Description = "Get all vaccines by bovine ID",
        OperationId = "GetVaccinesByBovineId")]
    public async Task<ActionResult> GetVaccinesByBovineId(int? bovineId)
    {
        var getVaccinesByBovineIdQuery = new GetVaccinesByBovineIdQuery(bovineId);
        var vaccines = await queryService.Handle(getVaccinesByBovineIdQuery);

        if (vaccines == null || !vaccines.Any())
            return NotFound();

        var vaccineResources = vaccines.Select(VaccineResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(vaccineResources);
    }

    /// <summary>
    /// Updates a vaccine by its ID.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="resource"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UpdateVaccine(int id, [FromForm] UpdateVaccineResource resource)
    {
        var command = UpdateVaccineCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var result = await commandService.Handle(command);
        if (result is null) return BadRequest();

        return Ok(VaccineResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    /// <summary>
    /// Deletes a vaccine by its ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVaccine(int id)
    {
        var command = new DeleteVaccineCommand(id);
        var result = await commandService.Handle(command);
        if (result is null) return NotFound();

        return NoContent();
    }

}

/// <summary>
/// API controller for managing stables
/// </summary>
[Authorize]
[ApiController]
[Route("/api/v1/stables")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Stables")]
public class StableController(
   IStableCommandService commandService,
   IStableQueryService queryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateStables([FromBody] CreateStableResource resource)
    {
        var command = CreateStableCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await commandService.Handle(command);
        if (result is null) return BadRequest();

        return CreatedAtAction(nameof(GetStableById), new { id = result.Id },
            StableResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all stables",
        Description = "Get all stables",
        OperationId = "GetAllStable")]
    [SwaggerResponse(StatusCodes.Status200OK, "The list of stables were found", typeof(IEnumerable<StableResource>))]
    public async Task<IActionResult> GetAllStable()
    {
        var stables = await queryService.Handle(new GetAllStablesQuery());
        var stableResources = stables.Select(StableResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(stableResources);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetStableById(int id)
    {
        var getStableById = new GetStablesByIdQuery(id);
        var result = await queryService.Handle(getStableById);
        if (result is null) return NotFound();
        var resources = StableResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resources);
    }

    /// <summary>
    /// Updates a stable by its ID.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="resource"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStable(int id, [FromBody] UpdateStableResource resource)
    {
        var command = UpdateStableCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var result = await commandService.Handle(command);
        if (result is null) return BadRequest();

        return Ok(StableResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    /// <summary>
    /// Deletes a stable by its ID.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStable(int id)
    {
        var command = new DeleteStableCommand(id);
        var result = await commandService.Handle(command);
        if (result is null) return NotFound();

        return NoContent();
    }
}

/// <summary>
/// API controller for managing appointments
/// </summary>
[Authorize]
[ApiController]
[Route("/api/v1/appointments")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Appointments")]
public class AppointmentController(
    IAppointmentCommandService commandService,
    IAppointmentQueryService queryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentResource resource)
    {
        var command = CreateAppointmentCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await commandService.Handle(command);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetAppointmentById), new { id = result.Id },
            AppointmentResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Get all appointments", OperationId = "GetAllAppointments")]
    public async Task<IActionResult> GetAllAppointments()
    {
        var items = await queryService.Handle(new GetAllAppointmentsQuery());
        return Ok(items.Select(AppointmentResourceFromEntityAssembler.ToResourceFromEntity));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetAppointmentById(int id)
    {
        var result = await queryService.Handle(new GetAppointmentByIdQuery(id));
        if (result is null) return NotFound();
        return Ok(AppointmentResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("next")]
    [SwaggerOperation(Summary = "Get next upcoming appointment", OperationId = "GetNextAppointment")]
    public async Task<ActionResult> GetNextAppointment()
    {
        var result = await queryService.Handle(new GetNextAppointmentQuery());
        if (result is null) return NotFound();
        return Ok(AppointmentResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAppointment(int id, [FromBody] UpdateAppointmentResource resource)
    {
        var command = UpdateAppointmentCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var result = await commandService.Handle(command);
        if (result is null) return BadRequest();
        return Ok(AppointmentResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAppointment(int id)
    {
        var result = await commandService.Handle(new DeleteAppointmentCommand(id));
        if (result is null) return NotFound();
        return NoContent();
    }
}

/// <summary>
/// API controller for managing clinical records
/// </summary>
[Authorize]
[ApiController]
[Route("/api/v1/clinical-records")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("ClinicalRecords")]
public class ClinicalRecordController(
    IClinicalRecordCommandService commandService,
    IClinicalRecordQueryService queryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateClinicalRecord([FromBody] CreateClinicalRecordResource resource)
    {
        var command = CreateClinicalRecordCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await commandService.Handle(command);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetClinicalRecordById), new { id = result.Id },
            ClinicalRecordResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Get all clinical records", OperationId = "GetAllClinicalRecords")]
    public async Task<IActionResult> GetAllClinicalRecords()
    {
        var items = await queryService.Handle(new GetAllClinicalRecordsQuery());
        return Ok(items.Select(ClinicalRecordResourceFromEntityAssembler.ToResourceFromEntity));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetClinicalRecordById(int id)
    {
        var result = await queryService.Handle(new GetClinicalRecordByIdQuery(id));
        if (result is null) return NotFound();
        return Ok(ClinicalRecordResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("bovine/{bovineId}")]
    [SwaggerOperation(Summary = "Get clinical records by bovine ID", OperationId = "GetClinicalRecordsByBovineId")]
    public async Task<ActionResult> GetClinicalRecordsByBovineId(int bovineId)
    {
        var items = await queryService.Handle(new GetClinicalRecordsByBovineIdQuery(bovineId));
        if (!items.Any()) return NotFound();
        return Ok(items.Select(ClinicalRecordResourceFromEntityAssembler.ToResourceFromEntity));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClinicalRecord(int id, [FromBody] UpdateClinicalRecordResource resource)
    {
        var command = UpdateClinicalRecordCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var result = await commandService.Handle(command);
        if (result is null) return BadRequest();
        return Ok(ClinicalRecordResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClinicalRecord(int id)
    {
        var result = await commandService.Handle(new DeleteClinicalRecordCommand(id));
        if (result is null) return NotFound();
        return NoContent();
    }
}

/// <summary>
/// API controller for managing feeding plans
/// </summary>
[Authorize]
[ApiController]
[Route("/api/v1/feeding-plans")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("FeedingPlans")]
public class FeedingPlanController(
    IFeedingPlanCommandService commandService,
    IFeedingPlanQueryService queryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateFeedingPlan([FromBody] CreateFeedingPlanResource resource)
    {
        var command = CreateFeedingPlanCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await commandService.Handle(command);
        if (result is null) return BadRequest();
        return CreatedAtAction(nameof(GetFeedingPlanById), new { id = result.Id },
            FeedingPlanResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Get all feeding plans", OperationId = "GetAllFeedingPlans")]
    public async Task<IActionResult> GetAllFeedingPlans()
    {
        var items = await queryService.Handle(new GetAllFeedingPlansQuery());
        return Ok(items.Select(FeedingPlanResourceFromEntityAssembler.ToResourceFromEntity));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetFeedingPlanById(int id)
    {
        var result = await queryService.Handle(new GetFeedingPlanByIdQuery(id));
        if (result is null) return NotFound();
        return Ok(FeedingPlanResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("lot/{lot}")]
    [SwaggerOperation(Summary = "Get feeding plan by lot", OperationId = "GetFeedingPlanByLot")]
    public async Task<ActionResult> GetFeedingPlanByLot(string lot)
    {
        var result = await queryService.Handle(new GetFeedingPlanByLotQuery(lot));
        if (result is null) return NotFound();
        return Ok(FeedingPlanResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFeedingPlan(int id, [FromBody] UpdateFeedingPlanResource resource)
    {
        var command = UpdateFeedingPlanCommandFromResourceAssembler.ToCommandFromResource(id, resource);
        var result = await commandService.Handle(command);
        if (result is null) return BadRequest();
        return Ok(FeedingPlanResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFeedingPlan(int id)
    {
        var result = await commandService.Handle(new DeleteFeedingPlanCommand(id));
        if (result is null) return NotFound();
        return NoContent();
    }

    [HttpPost("{id}/components")]
    [SwaggerOperation(Summary = "Add component to feeding plan", OperationId = "AddFeedingComponent")]
    public async Task<IActionResult> AddFeedingComponent(int id, [FromBody] AddFeedingComponentResource resource)
    {
        var command = new AddFeedingComponentCommand(id, resource.Name, resource.Percentage, resource.AmountKg);
        var result = await commandService.Handle(command);
        if (result is null) return BadRequest();
        return Ok(new FeedingComponentResource(result.Id, result.Name, result.Percentage, result.AmountKg));
    }
}