using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fresh.Data
{
    internal interface IAnalyse
    {
        void VPR();
        void Buffer();
    }

    public class Analyse : IAnalyse
    {
        public void Buffer()
        {
            throw new NotImplementedException();
        }

        public void VPR()
        {
            throw new NotImplementedException();
        }
    }


}
