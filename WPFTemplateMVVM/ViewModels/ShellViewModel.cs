using Caliburn.Micro;
using System.Windows;
namespace WPFTemplateMVVM.ViewModels;

public class ShellViewModel : PropertyChangedBase
{
    string? name;

    public string Name
    {
        get => name;
        set
        {
            name = value;
            NotifyOfPropertyChange(() => Name);
            NotifyOfPropertyChange(() => CanSayHello);
        }
    }

    public bool CanSayHello
    {
        get { return !string.IsNullOrWhiteSpace(Name); }
    }

    public void SayHello()
    {
        MessageBox.Show(string.Format("Hello {0}!", Name)); //Don't do this in real life :)
    }
}

