using BuberBreakfast.Contracts.BuberBreakfast;
using Microsoft.AspNetCore.Mvc;
using BuberBreakfast.Models;
using BuberBreakfast.Services.Breakfasts;
using ErrorOr;
using BuberBreakfast.Services;

namespace BuberBreakfast.Controllers;

public class BreakfastsController : ApiController
{
    private readonly IBreakfastService _breakfastService;

    
    public BreakfastsController(IBreakfastService breakfastService){
        _breakfastService = breakfastService;
    }

    [HttpPost]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {
        var breakfast = Breakfast.Create(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet
        );
        
        ErrorOr<Created> creatBreakfastResult =_breakfastService.CreateBreakfast(breakfast);

        return creatBreakfastResult.Match(
            Created => CreatedAtGetBreakfast(breakfast),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id:guid}")]

    public IActionResult GetBreakfast(Guid id)
    {
        ErrorOr<Breakfast> getBreakfastResult = _breakfastService.GetBreakfast(id);

        return getBreakfastResult.Match(
            breakfast => Ok(MapBreakfastResponse(breakfast)),
            errors => Problem(errors)
        );

    }

    private BreakfastResponse MapBreakfastResponse(Breakfast breakfast)
    {
        return new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet
        );
    }

    [HttpPut("{id:guid}")]

    public IActionResult UpsertBreakfast(Guid id,UpsertBreakfastRequest request)
    {
        var breakfast = Breakfast.Create(
            id,
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet
        );
        ErrorOr<UpsertBreakfast> upsertBreakfastResult =_breakfastService.UpsertBreakfast(breakfast);

        return upsertBreakfastResult.Match(
            upserted => upserted.IsNewlyCreated? CreatedAtGetBreakfast(breakfast) :NoContent(),
            errors => Problem(errors)
        );
        
    }

    [HttpDelete("{id:guid}")]

    public IActionResult DeleteBreakfast(Guid id)
    {
        ErrorOr<Deleted> deleteBreakfastResult = _breakfastService.DeleteBreakfast(id);

        return deleteBreakfastResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }

    private CreatedAtActionResult CreatedAtGetBreakfast(Breakfast breakfast)
    {
        return CreatedAtAction(
            actionName: nameof(GetBreakfast),
            routeValues: new { id = breakfast.Id },
            value: MapBreakfastResponse(breakfast));
    }

}