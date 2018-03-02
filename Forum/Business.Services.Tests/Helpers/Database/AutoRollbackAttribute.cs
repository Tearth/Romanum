using System;
using System.Reflection;
using System.Transactions;
using Xunit.Sdk;

namespace Business.Services.Tests.Helpers.Database
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AutoRollbackAttribute : BeforeAfterTestAttribute
    {
        private TransactionScope scope;

        private const TransactionScopeAsyncFlowOption AsyncFlowOption = TransactionScopeAsyncFlowOption.Enabled;
        private const IsolationLevel DataIsolationLevel = IsolationLevel.Unspecified;
        private const TransactionScopeOption ScopeOption = TransactionScopeOption.Required;
        public long TimeoutInMS = -1;

        public override void After(MethodInfo methodUnderTest)
        {
            scope.Dispose();
        }

        public override void Before(MethodInfo methodUnderTest)
        {
            var options = new TransactionOptions { IsolationLevel = DataIsolationLevel };
            if (TimeoutInMS > 0)
            {
                options.Timeout = TimeSpan.FromMilliseconds(TimeoutInMS);
            }

            scope = new TransactionScope(ScopeOption, options, AsyncFlowOption);
        }
    }
}
