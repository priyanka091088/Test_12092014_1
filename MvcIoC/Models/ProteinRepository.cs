using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcIoC.Models
{
    public class ProteinRepository : IProteinRepository
    {
        private readonly string dataSource;
        public ProteinRepository(string dataSource)
        {
            this.dataSource = dataSource;

        }
        private static ProteinData data = new ProteinData();
        
        //public int GetData(DateTime dt,int itotal)
        //{
        //    return itotal;
        //}
        public ProteinData GetData(DateTime dt)
        {
            return data;
        }

        public void SetTotal(DateTime dt, int itotal)
        {
            data.Total = itotal;
        }

        public void SetGoal (DateTime dt, int iGoal)
        {
            data.Goal = iGoal;
        }
    }
}