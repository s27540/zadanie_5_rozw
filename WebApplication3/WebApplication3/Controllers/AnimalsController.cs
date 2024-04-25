using Microsoft.AspNetCore.Mvc;
using WebApplication3.Model;
using WebApplication3.Services;

namespace WebApplication3.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private IAnimalsService _animalsService;

    public AnimalsController(IAnimalsService animalsService)
    {
        _animalsService = animalsService;
    }

    [HttpGet]
    public IActionResult GetAnimals(string orderBy)
    {
        var animals = _animalsService.GetAnimals(orderBy);
        return Ok(animals);
    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        var affectedCount = _animalsService.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(Animal animal)
    {
        var affectedCount = _animalsService.UpdateAnimal(animal);
        return StatusCode(StatusCodes.Status202Accepted);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int idAnimal)
    {
        var affectedCount = _animalsService.DeleteAnimal(idAnimal);
        return StatusCode(StatusCodes.Status204NoContent);
    }

}