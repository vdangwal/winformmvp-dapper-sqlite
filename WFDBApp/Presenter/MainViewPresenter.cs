using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vikas.Dangwal.DataLayer.Providers;
using Vikas.Dangwal.Interface;
using Vikas.Dangwal.Model.Gdp;
using Vikas.Dangwal.UI.View;

namespace Vikas.Dangwal.UI.Presenter
{
    public class MainViewPresenter : IMainViewPresenter
    {
        private readonly IDataProvider<Country> _dataProvider;
        public MainViewPresenter(IMainView mainView, IDataProvider<Country> dataProvider)
        {
            _dataProvider = dataProvider;
            MainView = mainView;
        }
        public void LoadData()
        {            
            var data = _dataProvider.Get("select * from Country order by CountryCode", System.Data.CommandType.Text, null).ConfigureAwait(false).GetAwaiter().GetResult();
            if (data != null && data.Any())
                MainView?.DisplayData(data.ToList());
        }

        public IMainView MainView { get; }
    }
}
