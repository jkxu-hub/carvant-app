using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarvantApp.Data.Data;
using CarvantApp.Data.Models;
using CarvantApp.Shared.Interfaces;
using CarvantApp.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CarvantApp.Shared.Services;

public class HomeService: IHomeService
{
    private readonly FinanceContext _context;

    public HomeService(FinanceContext context)
    {
        _context = context;
    }

    public async Task<List<LocationViewModel>> GetAllLocationsAsync()
    {
        try
        {
            return await _context.Locations
                .Select(loc => new LocationViewModel
                {
                    Zip = loc.Zip,
                    City = loc.City,
                    State = loc.State,
                    County = loc.County,
                    Latitude = loc.Latitude,
                    Longtitude = loc.Longtitude,
                    Id = loc.Id

                })
                .ToListAsync();
        }
        catch (Exception ex)
        {
            //Should log the exception
            Console.Error.WriteLine($"Error retrieving locations: {ex.Message}");
            throw;
        }
    }

    public async Task<int> AddLocationAsync(LocationViewModel locationVm)
    {
        var location = new Location
        {
            Zip = locationVm.Zip,
            City = locationVm.City,
            State = locationVm.State,
            County = locationVm.County,
            Latitude = locationVm.Latitude,
            Longtitude = locationVm.Longtitude
        };

        await _context.Locations.AddAsync(location);
        await _context.SaveChangesAsync();
        return location.Id;
    }

    public async Task EditLocationAsync(LocationViewModel locationVm)
    {
        var location = await _context.Locations.FindAsync(locationVm.Id);
        if (location != null)
        {
            location.Zip = locationVm.Zip;
            location.City = locationVm.City;
            location.State = locationVm.State;
            location.County = locationVm.County;
            location.Latitude = locationVm.Latitude;
            location.Longtitude = locationVm.Longtitude;

            _context.Locations.Update(location);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteLocationAsync(int id)
    {
        var location = await _context.Locations.FindAsync(id);
        if (location != null)
        {
            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();
        }
    }


}
