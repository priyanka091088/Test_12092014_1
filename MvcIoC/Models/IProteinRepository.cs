using System;
namespace MvcIoC.Models
{
    public interface IProteinRepository
    {
        ProteinData GetData(DateTime dt);
        void SetGoal(DateTime dt, int iGoal);
        void SetTotal(DateTime dt, int itotal);
    }
}
