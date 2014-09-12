using System;
namespace MvcIoC.Models
{
    public interface IProteinTrackingService
    {
        void AddProtein(int iAmount);
        int Goal { get; set; }
        int Total { get; set; }
    }
}
