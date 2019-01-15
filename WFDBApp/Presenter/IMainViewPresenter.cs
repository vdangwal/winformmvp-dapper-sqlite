using Vikas.Dangwal.UI.View;

namespace Vikas.Dangwal.UI.Presenter
{
    public interface IMainViewPresenter
    {
        IMainView MainView { get; }

        void LoadData();
    }
}