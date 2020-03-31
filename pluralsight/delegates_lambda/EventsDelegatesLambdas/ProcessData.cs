using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDelegatesLambdas
{
    class ProcessData
    {
        public void Process(int x, int y, BizRuleDelegate del) {
            var result = del(x, y);
            Console.WriteLine(nameof(Process) + ": " + result);
        }

        public void ProcessAction(int x, int y, Action<int, int> action)
        {
            action(x, y);
            Console.WriteLine(nameof(ProcessAction) + " done");
        }

        public void ProcessFunc(int x, int y, Func<int, int, int> func)
        {
            var result = func(x, y);
            Console.WriteLine(nameof(ProcessFunc) + ": " + result);
        }
    }
}
