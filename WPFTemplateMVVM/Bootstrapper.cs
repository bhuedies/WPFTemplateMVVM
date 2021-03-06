using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using WPFTemplateMVVM.ViewModels;

namespace WPFTemplateMVVM;

public class Bootstrapper : BootstrapperBase
{
    private SimpleContainer container;
    public Bootstrapper()
    {
        Initialize();
    }

    protected override void Configure()
    {
        container = new SimpleContainer();

        container.Singleton<IWindowManager, WindowManager>();
        container.Singleton<IEventAggregator, EventAggregator>();

        container.PerRequest<ShellViewModel>();
    }

    protected override object GetInstance(Type service, string key)
    {
        return container.GetInstance(service, key);
    }

    protected override IEnumerable<object> GetAllInstances(Type service)
    {
        return container.GetAllInstances(service);
    }

    protected override void BuildUp(object instance)
    {
        container.BuildUp(instance);
    }

    protected override void OnStartup(object sender, StartupEventArgs e)
    {
        DisplayRootViewFor<ShellViewModel>();
    }

    protected override IEnumerable<Assembly> SelectAssemblies()
    {
        return new[] { Assembly.GetExecutingAssembly() };
    }
}