using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Xunit.Sdk;

namespace Business.Services.Tests.Helpers.Database
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class AutoRollbackAttribute : BeforeAfterTestAttribute
    {
        TransactionScope scope;

        const TransactionScopeAsyncFlowOption AsyncFlowOption = TransactionScopeAsyncFlowOption.Enabled;
        const IsolationLevel DataIsolationLevel = IsolationLevel.Unspecified;
        const TransactionScopeOption ScopeOption = TransactionScopeOption.Required;
        public long TimeoutInMS = -1;

        public override void After(MethodInfo methodUnderTest)
        {
            scope.Dispose();
        }

        public override void Before(MethodInfo methodUnderTest)
        {
            var options = new TransactionOptions { IsolationLevel = DataIsolationLevel };
            if (TimeoutInMS > 0)
                options.Timeout = TimeSpan.FromMilliseconds(TimeoutInMS);

            scope = new TransactionScope(ScopeOption, options, AsyncFlowOption);
        }
    }
}
