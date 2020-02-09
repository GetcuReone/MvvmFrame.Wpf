using GetcuReone.MvvmFrame.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmFrame.Wpf.UnitTests.Common;
using MvvmFrame.Wpf.UnitTests.SetProperty.Environment;

namespace MvvmFrame.Wpf.UnitTests.SetProperty
{
    [TestClass]
    public sealed class SetPropertyTests: UiTestBase<SetPropertyViewModel>
    {
        #region SetValueProperty 

        [TestMethod]
        [Timeout(Timeuots.Second.Ten)]
        [Description("[ui][model] check SetValueProperty for model")]
        public void Model_SetValuePropertyTestCase()
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
                })
                .RunWindow();
        }

        [TestMethod]
        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][view-model] check SetValueProperty for view-model")]
        public void ViewModel_SetValuePropertyTestCase()
        {
            string text = "Is model text";

            GivenInitViewModel()
                .AndAsync("navigate page", async viewModel => await NavigateAndWaitLoadPageAsync<SetPropertyPage, SetPropertyViewModel>(viewModel))
                .When("Change text", page =>
                {
                    page.tbViewModel.Text = text;
                    return page.DataContext.HasTypeAndGetValue<SetPropertyViewModel>();
                })
                .Then("Check result", model =>
                {
                    Assert.AreEqual(text, model.TextTest, "texts must match");
                })
                .RunWindow();
        }

        #endregion

        #region OnVerification method

        [TestMethod]
        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][model] check method OnVerification for model")]
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
        [Description("[ui][model] check method OnVerification for model with disable option")]
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
        [Description("[ui][model] check method OnVerification for model with error")]
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

        [TestMethod]
        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][view-model] check method OnVerification for view-model")]
        public void ViewModel_OnVerificationTestCase()
        {
            string text = "Is model text";

            GivenInitViewModel()
                .AndAsync("navigate page", async viewModel => await NavigateAndWaitLoadPageAsync<SetPropertyPage, SetPropertyViewModel>(viewModel))
                .When("Change text", page =>
                {
                    page.tbViewModel.Text = text;
                    return page.DataContext.HasTypeAndGetValue<SetPropertyViewModel>();
                })
                .Then("Check result", viewModel =>
                {
                    Assert.AreEqual(text, viewModel.TextTest, "texts must match");
                    Assert.AreEqual(1, viewModel.OnVerificationCallCounter, $"method '{nameof(SetPropertyViewModel.OnVerification)}' should be called");
                })
                .RunWindow();
        }

        [TestMethod]
        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][view-model] check method OnVerification for view-model with disable option")]
        public void ViewModel_OnVerificationDisableTestCase()
        {
            string text = "Is model text";

            GivenInitViewModel()
                .AndAsync("navigate page", async viewModel => await NavigateAndWaitLoadPageAsync<SetPropertyPage, SetPropertyViewModel>(viewModel))
                .When("Change text", page =>
                {
                    SetPropertyViewModel viewModel = page.DataContext.HasTypeAndGetValue<SetPropertyViewModel>();
                    viewModel.ModelOptions.UseOnVerification = false;
                    page.tbViewModel.Text = text;
                    return viewModel;
                })
                .Then("Check result", viewModel =>
                {
                    Assert.AreEqual(text, viewModel.TextTest, "texts must match");
                    Assert.AreEqual(0, viewModel.OnVerificationCallCounter, $"method '{nameof(SetPropertyViewModel.OnVerification)}' not should be called");
                })
                .RunWindow();
        }

        [TestMethod]
        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][view-model] check method OnVerification for view-model with error")]
        public void ViewModel_OnVerificationErrorTestCase()
        {
            string text = "error";

            GivenInitViewModel()
                .AndAsync("navigate page", async viewModel => await NavigateAndWaitLoadPageAsync<SetPropertyPage, SetPropertyViewModel>(viewModel))
                .When("Change text", page =>
                {
                    page.tbViewModel.Text = text;
                    return page.DataContext.HasTypeAndGetValue<SetPropertyViewModel>();
                })
                .Then("Check result", viewModel =>
                {
                    Assert.IsNull(viewModel.TextTest, "text must be null");
                    Assert.AreEqual(1, viewModel.OnVerificationCallCounter, $"method '{nameof(SetPropertyModel.OnVerification)}' should be called");
                    Assert.AreEqual(1, viewModel.OnErrorsCallCounter, $"method '{nameof(SetPropertyModel.OnErrors)}' should be called");
                    Assert.IsNotNull(viewModel.Details, "collection should not be empty");
                    Assert.AreEqual(1, viewModel.Details.Count, "there must be one item in the collection");
                    MvvmFrameErrorDetail detail = viewModel.Details[0];
                    Assert.AreEqual("InvalidData", detail.Code, "the error code must be different");
                })
                .RunWindow();
        }

        #endregion

        #region VerifyPropertyChange event

        [TestMethod]
        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][model] check event VerifyPropertyChange for model")]
        public void Model_VerifyPropertyChangeTestCase()
        {
            string text = "Is model text";
            int eventCallCounter = 0;

            GivenInitViewModel()
                .AndAsync("navigate page", async viewModel => await NavigateAndWaitLoadPageAsync<SetPropertyPage, SetPropertyViewModel>(viewModel))
                .And("Subscribe to event", page => 
                {
                    SetPropertyModel model = page.DataContext.HasTypeAndGetValue<SetPropertyViewModel>().Model;
                    model.VerifyPropertyChange += (sender, e) => eventCallCounter++;
                    return page;
                })
                .When("Change text", page =>
                {
                    page.tbModel.Text = text;
                    return page.DataContext.HasTypeAndGetValue<SetPropertyViewModel>().Model;
                })
                .Then("Check result", model =>
                {
                    Assert.AreEqual(text, model.TextTest, "texts must match");
                    Assert.AreEqual(1, eventCallCounter, $"event '{nameof(SetPropertyModel.VerifyPropertyChange)}' should be called");
                })
                .RunWindow();
        }

        [TestMethod]
        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][model] check event VerifyPropertyChange for model with disable option")]
        public void Model_VerifyPropertyChangeDisableTestCase()
        {
            string text = "Is model text";
            int eventCallCounter = 0;

            GivenInitViewModel()
                .AndAsync("navigate page", async viewModel => await NavigateAndWaitLoadPageAsync<SetPropertyPage, SetPropertyViewModel>(viewModel))
                .And("Subscribe to event", page =>
                {
                    SetPropertyModel model = page.DataContext.HasTypeAndGetValue<SetPropertyViewModel>().Model;
                    model.VerifyPropertyChange += (sender, e) => eventCallCounter++;
                    return page;
                })
                .When("Change text", page =>
                {
                    SetPropertyModel model = page.DataContext.HasTypeAndGetValue<SetPropertyViewModel>().Model;
                    model.ModelOptions.UseVerifyPropertyChange = false;
                    page.tbModel.Text = text;
                    return model;
                })
                .Then("Check result", model =>
                {
                    Assert.AreEqual(text, model.TextTest, "texts must match");
                    Assert.AreEqual(0, eventCallCounter, $"method '{nameof(SetPropertyModel.VerifyPropertyChange)}' not should be called");
                })
                .RunWindow();
        }

        [TestMethod]
        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][model] check event VerifyPropertyChange for model with error")]
        public void Model_VerifyPropertyChangeErrorTestCase()
        {
            string text = "error";

            GivenInitViewModel()
                .AndAsync("navigate page", async viewModel => await NavigateAndWaitLoadPageAsync<SetPropertyPage, SetPropertyViewModel>(viewModel))
                .And("Subscribe to event", page =>
                {
                    SetPropertyModel model = page.DataContext.HasTypeAndGetValue<SetPropertyViewModel>().Model;
                    model.VerifyPropertyChange += (sender, e) => e.AddError(new MvvmFrameErrorDetail { Code = "InvalidData" });
                    return page;
                })
                .When("Change text", page =>
                {
                    page.tbModel.Text = text;
                    return page.DataContext.HasTypeAndGetValue<SetPropertyViewModel>().Model;
                })
                .Then("Check result", model =>
                {
                    Assert.IsNull(model.TextTest, "text must be null");
                    Assert.AreEqual(1, model.OnErrorsCallCounter, $"method '{nameof(SetPropertyModel.OnErrors)}' should be called");
                    Assert.IsNotNull(model.Details, "collection should not be empty");
                    Assert.AreEqual(1, model.Details.Count, "there must be one item in the collection");
                    MvvmFrameErrorDetail detail = model.Details[0];
                    Assert.AreEqual("InvalidData", detail.Code, "the error code must be different");
                })
                .RunWindow();
        }

        [TestMethod]
        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][view-model] check event VerifyPropertyChange for view-model")]
        public void ViewModel_VerifyPropertyChangeTestCase()
        {
            string text = "Is model text";
            int eventCallCounter = 0;

            GivenInitViewModel()
                .AndAsync("navigate page", async viewModel => await NavigateAndWaitLoadPageAsync<SetPropertyPage, SetPropertyViewModel>(viewModel))
                .And("Subscribe to event", page =>
                {
                    var viewModel = page.DataContext.HasTypeAndGetValue<SetPropertyViewModel>();
                    viewModel.VerifyPropertyChange += (sender, e) => eventCallCounter++;
                    return page;
                })
                .When("Change text", page =>
                {
                    page.tbViewModel.Text = text;
                    return page.DataContext.HasTypeAndGetValue<SetPropertyViewModel>();
                })
                .Then("Check result", viewModel =>
                {
                    Assert.AreEqual(text, viewModel.TextTest, "texts must match");
                    Assert.AreEqual(1, eventCallCounter, $"event '{nameof(SetPropertyViewModel.VerifyPropertyChange)}' should be called");
                })
                .RunWindow();
        }

        [TestMethod]
        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][view-model] check event VerifyPropertyChange for view-model with disable option")]
        public void ViewModel_VerifyPropertyChangeDisableTestCase()
        {
            string text = "Is model text";
            int eventCallCounter = 0;

            GivenInitViewModel()
                .AndAsync("navigate page", async viewModel => await NavigateAndWaitLoadPageAsync<SetPropertyPage, SetPropertyViewModel>(viewModel))
                .And("Subscribe to event", page =>
                {
                    var viewModel = page.DataContext.HasTypeAndGetValue<SetPropertyViewModel>();
                    viewModel.VerifyPropertyChange += (sender, e) => eventCallCounter++;
                    return page;
                })
                .When("Change text", page =>
                {
                    SetPropertyViewModel viewModel = page.DataContext.HasTypeAndGetValue<SetPropertyViewModel>();
                    viewModel.ModelOptions.UseVerifyPropertyChange = false;
                    page.tbViewModel.Text = text;
                    return viewModel;
                })
                .Then("Check result", viewModel =>
                {
                    Assert.AreEqual(text, viewModel.TextTest, "texts must match");
                    Assert.AreEqual(0, eventCallCounter, $"event '{nameof(SetPropertyViewModel.VerifyPropertyChange)}' not should be called");
                })
                .RunWindow();
        }

        [TestMethod]
        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][view-model] check event VerifyPropertyChange for view-model with error")]
        public void ViewModel_VerifyPropertyChangeErrorTestCase()
        {
            string text = "error";

            GivenInitViewModel()
                .AndAsync("navigate page", async viewModel => await NavigateAndWaitLoadPageAsync<SetPropertyPage, SetPropertyViewModel>(viewModel))
                .And("Subscribe to event", page =>
                {
                    var viewModel = page.DataContext.HasTypeAndGetValue<SetPropertyViewModel>();
                    viewModel.VerifyPropertyChange += (sender, e) => e.AddError(new MvvmFrameErrorDetail { Code = "InvalidData" });
                    return page;
                })
                .When("Change text", page =>
                {
                    page.tbViewModel.Text = text;
                    return page.DataContext.HasTypeAndGetValue<SetPropertyViewModel>();
                })
                .Then("Check result", viewModel =>
                {
                    Assert.IsNull(viewModel.TextTest, "text must be null");
                    Assert.AreEqual(1, viewModel.OnErrorsCallCounter, $"method '{nameof(SetPropertyModel.OnErrors)}' should be called");
                    Assert.IsNotNull(viewModel.Details, "collection should not be empty");
                    Assert.AreEqual(1, viewModel.Details.Count, "there must be one item in the collection");
                    MvvmFrameErrorDetail detail = viewModel.Details[0];
                    Assert.AreEqual("InvalidData", detail.Code, "the error code must be different");
                })
                .RunWindow();
        }

        #endregion

        #region OnPropertyChanged

        [TestMethod]
        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][model] check OnPropertyChanged for model")]
        public void Model_OnPropertyChangedTestCase()
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
                    Assert.AreEqual(1, model.OnPropertyChangedCallCounter, $"method '{nameof(SetPropertyModel.OnPropertyChanged)}' should be called");
                })
                .RunWindow();
        }

        [TestMethod]
        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][model] check OnPropertyChanged for model with enabled option")]
        public void Model_OnPropertyChangedEnabledTestCase()
        {
            string text = "Is model text";
            int eventCallCounter = 0;

            GivenInitViewModel()
                .AndAsync("navigate page", async viewModel => await NavigateAndWaitLoadPageAsync<SetPropertyPage, SetPropertyViewModel>(viewModel))
                .When("Change text", page =>
                {
                    SetPropertyModel model = page.DataContext.HasTypeAndGetValue<SetPropertyViewModel>().Model;
                    model.VerifyPropertyChange += (sender, e) => eventCallCounter++;
                    model.ModelOptions.UseOnlyOnPropertyChanged = true;
                    page.tbModel.Text = text;
                    return model;
                })
                .Then("Check result", model =>
                {
                    Assert.AreEqual(text, model.TextTest, "texts must match");
                    Assert.AreEqual(1, model.OnPropertyChangedCallCounter, $"method '{nameof(SetPropertyModel.OnPropertyChanged)}' should be called");
                    Assert.AreEqual(0, model.OnVerificationCallCounter, $"method '{nameof(SetPropertyModel.OnVerification)}' should be called");
                    Assert.AreEqual(0, eventCallCounter, $"event '{nameof(SetPropertyModel.VerifyPropertyChange)}' should be called");
                })
                .RunWindow();
        }

        [TestMethod]
        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][view-model] check OnPropertyChanged for view-model")]
        public void ViewModel_OnPropertyChangedTestCase()
        {
            string text = "Is model text";

            GivenInitViewModel()
                .AndAsync("navigate page", async viewModel => await NavigateAndWaitLoadPageAsync<SetPropertyPage, SetPropertyViewModel>(viewModel))
                .When("Change text", page =>
                {
                    page.tbViewModel.Text = text;
                    return page.DataContext.HasTypeAndGetValue<SetPropertyViewModel>();
                })
                .Then("Check result", vewModel =>
                {
                    Assert.AreEqual(text, vewModel.TextTest, "texts must match");
                    Assert.AreEqual(1, vewModel.OnPropertyChangedCallCounter, $"method '{nameof(SetPropertyModel.OnPropertyChanged)}' should be called");
                })
                .RunWindow();
        }

        [TestMethod]
        [Timeout(Timeuots.Second.Five)]
        [Description("[ui][model] check OnPropertyChanged for model with enabled option")]
        public void ViewModel_OnPropertyChangedEnabledTestCase()
        {
            string text = "Is model text";
            int eventCallCounter = 0;

            GivenInitViewModel()
                .AndAsync("navigate page", async viewModel => await NavigateAndWaitLoadPageAsync<SetPropertyPage, SetPropertyViewModel>(viewModel))
                .When("Change text", page =>
                {
                    var viewModel = page.DataContext.HasTypeAndGetValue<SetPropertyViewModel>();
                    viewModel.VerifyPropertyChange += (sender, e) => eventCallCounter++;
                    viewModel.ModelOptions.UseOnlyOnPropertyChanged = true;
                    page.tbViewModel.Text = text;
                    return viewModel;
                })
                .Then("Check result", viewModel =>
                {
                    Assert.AreEqual(text, viewModel.TextTest, "texts must match");
                    Assert.AreEqual(1, viewModel.OnPropertyChangedCallCounter, $"method '{nameof(SetPropertyModel.OnPropertyChanged)}' should be called");
                    Assert.AreEqual(0, viewModel.OnVerificationCallCounter, $"method '{nameof(SetPropertyModel.OnVerification)}' should be called");
                    Assert.AreEqual(0, eventCallCounter, $"event '{nameof(SetPropertyModel.VerifyPropertyChange)}' should be called");
                })
                .RunWindow();
        }

        #endregion

    }
}
