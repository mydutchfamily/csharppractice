using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDelegatesLambdas
{
    public class Worker
    {
        public event WorkPerformedHandler WorkPerformed;
        public event WorkPerformedHandler2 WorkPerformed2;
        public event WorkCompletedHandler WorkCompleted;

        public event EventHandler<WorkPerformedEventArgs> WorkPerformed3;
        public event EventHandler WorkCompleted2;
        
        public void DoWork(int hours, WorkType workType) {
            for (int i = 0; i<hours; i++) {
                System.Threading.Thread.Sleep(1000);
                OnWorkPerformed(i+1,workType);
            }
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType) {
            if (WorkPerformed != null)
            {
                WorkPerformed(hours, workType);
            }

            var del2 = WorkPerformed2 as WorkPerformedHandler2;// can cast to delegate
            if (del2 != null)
            {// listeners are attached
                del2(this, new WorkPerformedEventArgs(hours, workType));
            }

            var del3 = WorkPerformed3 as EventHandler<WorkPerformedEventArgs>;
            if (del3 != null) {// listeners are attached
                del3(this, new WorkPerformedEventArgs(hours, workType));
            }
        }

        protected virtual void OnWorkCompleted()
        {
            if (WorkCompleted != null)
            {
                WorkCompleted(this, EventArgs.Empty);
            }

            EventHandler del = WorkCompleted2 as EventHandler;
            if (del != null)
            {// listeners are attached
                del(this, EventArgs.Empty);
            }
        }
    }
}
