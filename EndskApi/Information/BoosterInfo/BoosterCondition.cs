using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndskApi.Information.BoosterInfo
{
    public class BoosterCondition
    {
        public BoosterCondition()
        {

        }

        public string Name { get; set; }
        public string ShortName { get; set; }

        public BoosterImplants.BoosterCondition Condition { get; set; }
    }
}
