using Microsoft.AspNetCore.Mvc;
using CarvantApp.Shared.ViewModels;
using CarvantApp.Shared.Services;
using CarvantApp.Data.Models;

namespace CarvantApp.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : Controller
{

    private readonly HomeService _homeService;
    public HomeController(HomeService homeService)
    {
        _homeService = homeService;
    }

    [HttpGet("GetLocations")]
    public async Task<IActionResult> GetLocations()
    {
        try
        {
            var locations = await _homeService.GetAllLocationsAsync();
            return Ok(locations);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in GetLocations: {ex.Message}");
            return StatusCode(500, "An error occurred while retrieving locations.");
        }
    }

    [HttpPost("AddLocation")]
    public async Task<IActionResult> AddLocation(LocationViewModel location)
    {
        try
        {
            var id = await _homeService.AddLocationAsync(location);
            return Ok(id);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in GetLocations: {ex.Message}");
            return StatusCode(500, "An error occurred while adding the location.");
        }
    }

    [HttpPut("EditLocation")]
    public async Task<IActionResult> EditLocation(LocationViewModel location)
    {
        try
        {
            await _homeService.EditLocationAsync(location);
            return Ok("Location updated successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error in GetLocations: {ex.Message}");
            return StatusCode(500, "An error occurred while editing the location.");
        }
    }

    [HttpDelete("DeleteLocation/{id}")]
    public async Task<IActionResult> DeleteLocation(int id)
    {
        try
        {
            await _homeService.DeleteLocationAsync(id); // You should implement this method in your service
            return NoContent();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error deleting location: {ex.Message}");
            return StatusCode(500, "An error occurred while deleting the location.");
        }
    }
}
