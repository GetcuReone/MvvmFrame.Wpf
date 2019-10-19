using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Entities;
using MvvmFrame.Wpf.UnitTests.Common;
using MvvmFrame.Wpf.UnitTests.SetProperty.Environment;

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

        [TestMethod]
        [Timeout(Timeuots.Second.Five)]
        [Description("[model] check method OnVerification for model with disable option")]
        public void Model_OnVerificationDisableTestCase()
        {
            string text = "Is model text";

            GivenInitViewModel()
                .AndAsync("navigate page", async viewModel => await NavigateAndWaitLoadPageAsync<SetPropertyPage, SetPropertyViewModel>(viewModel))
                .When("Change text", page =>
                {
                    SetPropertyModel model = page.DataContext.HasTypeAndGetValue<SetPropertyViewModel>().Model;
                    model.ModelOptions.UseOnVerification = false;
                    page.tbModel.Text = text;
                    return model;
                })
                .Then("Check result", model =>
                {
                    Assert.AreEqual(text, model.TextTest, "texts must match");
                    Assert.AreEqual(0, model.OnVerificationCallCounter, $"method '{nameof(SetPropertyModel.OnVerification)}' not should be called");
                })
                .RunWindow();
        }

        [TestMethod]
        [Timeout(Timeuots.Second.Five)]
        [Description("[model] check method OnVerification for model with error")]
        public void Model_OnVerificationErrorTestCase()
        {
            string text = "error";

            GivenInitViewModel()
                .AndAsync("navigate page", async viewModel => await NavigateAndWaitLoadPageAsync<SetPropertyPage, SetPropertyViewModel>(viewModel))
                .When("Change text", page =>
                {
                    page.tbModel.Text = text;
                    return page.DataContext.HasTypeAndGetValue<SetPropertyViewModel>().Model;
                })
                .Then("Check result", model =>
                {
                    Assert.IsNull(model.TextTest, "text must be null");
                    Assert.AreEqual(1, model.OnVerificationCallCounter, $"method '{nameof(SetPropertyModel.OnVerification)}' should be called");
                    Assert.AreEqual(1, model.OnErrorsCallCounter, $"method '{nameof(SetPropertyModel.OnErrors)}' should be called");
                    Assert.IsNotNull(model.Details, "collection should not be empty");
                    Assert.AreEqual(1, model.Details.Count, "there must be one item in the collection");
                    MvvmFrameErrorDetail detail = model.Details[0];
                    Assert.AreEqual("InvalidData", detail.Code, "the error code must be different");
                })
                .RunWindow();
        }
    }
}
