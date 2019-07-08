using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReport.Models.Util
{
	//CSV Reader Interface.
    public interface ICSVReader
    {
        void Reader(string value);
    }
}
