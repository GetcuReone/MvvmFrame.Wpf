using GetcuReone.MvvmFrame.Wpf;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace MvvmFrame.Wpf.UnitTests.Common
{
    public static class TestHelper
    {
        public static void AssertCounter(int expectedCounter, int counter, string methodNane)
        {
            if (expectedCounter != 0)
                Assert.AreNotEqual(0, counter, $"There was no method call {methodNane}");
            Assert.AreEqual(expectedCounter, counter,
                $"There should have been {expectedCounter} method {methodNane} calls. Fact: {counter}");
        }

        public static TExpectedException ExpectedException<TExpectedException>(Action action)
            where TExpectedException : Exception
        {
            try
            {
                action();
                throw new Exception("Did not appear exception");
            }
            catch (TExpectedException ex)
            {
                return ex;
            }
            catch (TargetInvocationException tex)
            {
                if (tex.InnerException is TExpectedException ex)
                    return ex;
                else
                    throw;
            }
            catch
            {
                throw;
            }
        }

        public static TExpectedException ExpectedException<TExpectedException>(Action action, string expectedMessage)
            where TExpectedException : Exception
        {
            var exception = ExpectedException<TExpectedException>(action);
            Assert.AreEqual(expectedMessage, exception.Message, "Error messages different");
            return exception;
        }

        public static TObj HasTypeAndGetValue<TObj>(this object obj)
        {
            if (obj is TObj obj1)
                return obj1;

            Assert.Fail($"object has a different type. expect '{typeof(TObj).FullName}'; fact '{obj.GetType().FullName}'");
            return default;
        }

        public static void CheckBindViewModel(ViewModelBase first, ViewModelBase second)
        {
            Assert.AreEqual(first.NavigationManager, second.NavigationManager, "view-model tied to different navigation managers");
        }

        public static TViewModel NotNull<TViewModel>(this TViewModel viewModel)
            where TViewModel: ViewModelBase
        {
            Assert.IsNotNull(viewModel, "view-model cannot be null");
            return viewModel;
        }
    }
}
