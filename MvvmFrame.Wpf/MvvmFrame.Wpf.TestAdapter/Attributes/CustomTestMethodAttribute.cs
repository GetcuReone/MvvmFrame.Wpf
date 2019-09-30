using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace MvvmFrame.Wpf.TestAdapter.Attributes
{
    /// <summary>
    /// Custom <see cref="TestMethodAttribute"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class CustomTestMethodAttribute : TestMethodAttribute
    {
        /// <summary>
        /// Override method name using class name
        /// </summary>
        public bool UseClassNameForMethodName { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public CustomTestMethodAttribute():this(true) { }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="useClassNameForMethodName">Override method name using class name</param>
        public CustomTestMethodAttribute(bool useClassNameForMethodName)
        {
            UseClassNameForMethodName = useClassNameForMethodName;
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="testMethod"></param>
        /// <returns></returns>
        public override TestResult[] Execute(ITestMethod testMethod)
        {
            ITestMethod arg = UseClassNameForMethodName ? new TestMethod(UseClassNameForMethodName, testMethod) : testMethod;
            return base.Execute(arg);
        }

        private class TestMethod : ITestMethod
        {
            private readonly ITestMethod _testMethod;
            private readonly bool _useClassNameForMethodName;

            public string TestMethodName => _useClassNameForMethodName ? $"{TestClassName}.{_testMethod.TestMethodName}" : _testMethod.TestMethodName;

            public string TestClassName => _testMethod.TestClassName;

            public Type ReturnType => _testMethod.ReturnType;

            public object[] Arguments => _testMethod.Arguments;

            public ParameterInfo[] ParameterTypes => _testMethod.ParameterTypes;

            public MethodInfo MethodInfo => _testMethod.MethodInfo;

            public TestMethod(bool useClassNameForMethodName, ITestMethod testMethod)
            {
                _useClassNameForMethodName = useClassNameForMethodName;
                _testMethod = testMethod;
            }

            public Attribute[] GetAllAttributes(bool inherit) => _testMethod.GetAllAttributes(inherit);

            public AttributeType[] GetAttributes<AttributeType>(bool inherit) where AttributeType : Attribute
                => _testMethod.GetAttributes<AttributeType>(inherit);

            public TestResult Invoke(object[] arguments) => _testMethod.Invoke(arguments);
        }
    }
}
