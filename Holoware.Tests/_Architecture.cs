using ArchitectureModule.Infrastructure;
using ArchitectureModule.UI.Views;
using ArchitectureModule.ViewModels;
using Bizmonger.Patterns;
using CommandModule.Infrastructure;
using Holoware.TestAPI;
using MessageModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Holoware.Tests
{
    [TestClass]
    public class _Architecture
    {
        #region Testware
        [TestCleanup]
        public void Cleanup()
        {
            ServiceLocator.Instance.Clear();
        }
        #endregion

        [TestMethod]
        public void load_architecture()
        {
            // Setup
            var viewModel = new LoadArchitectureViewModel();
            var dependencies = new ArchitectureDependencies() { Services = MockArchitectureServices.Instance };
            viewModel.Initialize(dependencies);

            // Test
            var architecture = viewModel.LoadArchitecture();

            // Verify
            Assert.IsTrue(architecture != null);
        }

        [TestMethod]
        public void add_layer()
        {
            // Setup
            var dependenciesModule = new DependenciesModule.Infrastructure.DependenciesModule();
            dependenciesModule.LoadModules();
            MessageBus.Instance.Publish(SystemMessage.REQUEST_BOOTSTRAP);

            var view = ServiceLocator.Instance[typeof(ArchitectureView)] as ArchitectureView;
            var viewModel = view.DataContext as ArchitectureViewModel;

            viewModel.ConsoleLine.Content = "AddLayer UX";

            // Test
            viewModel.ExecuteCommand.Execute(null);

            // Verify
            var expectedCount = viewModel.ConsoleLines.Count() == 2;
            var expectedStatus = viewModel.ConsoleLines.First().Status == CommandStatus.Succeeded;

            Assert.IsTrue(expectedCount && expectedStatus);
        }

        [TestMethod]
        public void add_layer_fails_with_invalid_parameters()
        {
            // Setup
            var dependenciesModule = new DependenciesModule.Infrastructure.DependenciesModule();
            dependenciesModule.LoadModules();
            MessageBus.Instance.Publish(SystemMessage.REQUEST_BOOTSTRAP);

            var view = ServiceLocator.Instance[typeof(ArchitectureView)] as ArchitectureView;
            var viewModel = view.DataContext as ArchitectureViewModel;

            viewModel.ConsoleLine.Content = "AddLayer UX Layer";

            // Test
            viewModel.ExecuteCommand.Execute(null);

            // Verify
            var expectedCount = viewModel.ConsoleLines.Count() == 2;
            var expectedLayerName = viewModel.Layers.Single().Id == "UX Layer";
            var expectedStatus = viewModel.ConsoleLines.First().Status == CommandStatus.Succeeded;

            Assert.IsTrue(expectedCount && expectedStatus && expectedLayerName);
        }
    }
}