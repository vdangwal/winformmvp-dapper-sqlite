using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vikas.Dangwal.Model.Gdp;

namespace Vikas.Dangwal.UI.View
{
    public interface IMainView
    {
        void DisplayData(IList<Country> countries);
        void ShowMainView(bool modal = true);
    }
}
