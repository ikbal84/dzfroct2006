using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotels.Data.Model;
using Hotels.Data.Services;

namespace Hotels.Data.Services
{
    public class FeaturesDAO
    {
        public List<Features> GetAllFeatures()
        {
            var context = new HotelsDBContext();

            return context.Features.ToList();

        }
    }
}
