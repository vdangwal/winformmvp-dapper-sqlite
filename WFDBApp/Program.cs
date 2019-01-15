using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Injection;
using Unity.Resolution;
using Vikas.Dangwal.DataLayer.Providers;
using Vikas.Dangwal.Interface;
using Vikas.Dangwal.Model.Gdp;
using Vikas.Dangwal.UI.Presenter;
using Vikas.Dangwal.UI.View;

namespace WFDBApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = new UnityContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            container.RegisterType<IMainViewPresenter, MainViewPresenter>();
            container.RegisterType<IMainView, MainView>();
            container.RegisterType<IDataProvider<Country>, SqliteDataProvider<Country>>(new InjectionConstructor(ConfigurationManager.ConnectionStrings["local"].ConnectionString));
            //IMainViewPresenter mainViewPresenter = new MainViewPresenter(new MainView());
            //mainViewPresenter.LoadData();
            var mvp = container.Resolve<IMainViewPresenter>();
            mvp.LoadData();                
            Application.Run((MainView)mvp.MainView);
        }
    }
}
