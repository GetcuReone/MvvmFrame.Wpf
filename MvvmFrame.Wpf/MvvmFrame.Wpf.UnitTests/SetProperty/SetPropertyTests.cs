using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.UnitTests.Common;
using MvvmFrame.Wpf.UnitTests.SetProperty.Environment;
using System.Threading.Tasks;

namespace MvvmFrame.Wpf.UnitTests.SetProperty
{
    [TestClass]
    public sealed class SetPropertyTests: UiTestBase<SetPropertyViewModel>
    {
        [TestMethod]
        [Timeout(Timeuots.Second.Five)]
        [Description("[model] check method OnVerification for model")]
        public void Model_OnVerificationTestCase()
        {
            string text = "Is model text";

            GivenInitViewModel()
                .AndAsync("navigate page", async viewModel => await NavigateAndWaitLoadPageAsync<SetPropertyPage, SetPropertyViewModel>(viewModel))
                .When("Change text", page =>
                {
                    page.tbModel.Text = text;
                    return page.DataContext.HasTypeAndGetValue<SetPropertyViewModel>().Model;
                })
                .Then("Check result", model =>
                {
                    Assert.AreEqual(text, model.TextTest, "texts must match");
                    Assert.AreEqual(1, model.OnVerificationCallCounter, $"method '{nameof(SetPropertyModel.OnVerification)}' should be called");
                })
                .RunWindow();
        }
    }
}
