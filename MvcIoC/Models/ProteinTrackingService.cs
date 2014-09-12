using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcIoC.Models
{
    public class ProteinTrackingService : IProteinTrackingService
    {
        private IProteinRepository repository;

        public ProteinTrackingService()
        {

        }

        public ProteinTrackingService(IProteinRepository _iProteinRepository)
        {
            this.repository = _iProteinRepository;
        }
        //private int _iTotal = 10;
        //private int _iGoal = 10;
        public int Total
        {
            get { return repository.GetData(new DateTime().Date).Total; }
            set { repository.SetTotal(new DateTime().Date, value); }
        }
        public int Goal 
        {
            get { return repository.GetData(new DateTime().Date).Goal; }
            set { repository.SetGoal(new DateTime().Date, value); }
        }
        public void AddProtein(int iAmount)
        {
            Total += iAmount;
        }
    }
}