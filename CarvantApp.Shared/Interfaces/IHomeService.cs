using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarvantApp.Data.Models;
using CarvantApp.Shared.ViewModels;

namespace CarvantApp.Shared.Interfaces
{
    public interface IHomeService
    {
        Task<List<LocationViewModel>> GetAllLocationsAsync();
        Task<int> AddLocationAsync(LocationViewModel locationVm);
        Task EditLocationAsync(LocationViewModel locationVm);
        Task DeleteLocationAsync(int id);
    }
}
