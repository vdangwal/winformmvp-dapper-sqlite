using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vikas.Dangwal.Model.Gdp;

namespace Vikas.Dangwal.UI.View
{
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        public void DisplayData(IList<Country> countries)
        {
            if (countries.Any())
            {
                Countries = new BindingList<Country>(countries);
                dgCountries.DataSource = Countries;
            }
        }

        public void ShowMainView(bool modal = true)
        {
            if (modal)
                this.ShowDialog();
            else
                this.Show();
        }

        #region Properties
        public BindingList<Country> Countries { get; set; }
        #endregion
    }
}
