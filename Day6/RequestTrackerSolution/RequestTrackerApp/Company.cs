using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerApp
{
    internal class Company
    {

        public void EmployeeClientVisit(IClientInteractions clientInteractions)
        {
            clientInteractions.GetOrder();
            clientInteractions.GetPayment();
        }

    }
}
