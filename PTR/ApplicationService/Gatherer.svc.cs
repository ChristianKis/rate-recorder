using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ApplicationService
{
    public class Gatherer : IGatherer
    {
        public void GatherCurrentRates()
        {
            throw new NotImplementedException();
        }
    }
}
