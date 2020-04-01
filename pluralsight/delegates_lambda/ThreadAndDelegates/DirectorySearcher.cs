using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadAndDelegates
{
    public class DirectorySearcher: Control
    {
        public event EventHandler SearchComplete;

        private delegate void FileListDelegate(string[] files, int startIndex, int count);

        private ListBox _ListBox;
        private string _SearchCriteria;
        private bool _Searching;
        private bool _DeferSearch;
        private Thread _SearchThread;
        private FileListDelegate _FileListDelegate;
        private EventHandler _OnSearchComplete;

        public DirectorySearcher() {
            _ListBox = new ListBox();
            _ListBox.Dock = DockStyle.Fill;

            Controls.Add(_ListBox);

            _FileListDelegate = new FileListDelegate(AddFiles);
            _OnSearchComplete = new EventHandler(OnSearchComplete);
        }

        private void OnSearchComplete(object sender, EventArgs e)
        {
            if (SearchComplete != null)
            {
                SearchComplete(sender, e);
            }

        }
        public string SearchCriteria { get { return _SearchCriteria; }
            set
            {
                bool wasSearching = Searching;

                if (wasSearching)
                {
                    StopSearch();
                }

                _ListBox.Items.Clear();
                _SearchCriteria = value;

                if (wasSearching)
                {
                    BeginSearch();
                }
            }
        }

        public bool Searching
        {
            get {
                return _Searching;
            }
        }

        internal void BeginSearch()
        {
            if (Searching) return;

            if (IsHandleCreated)
            {
                _SearchThread = new Thread(new ThreadStart(ThreadProcedure));
                _Searching = true;
                _SearchThread.Start();
            }
            else {
                _DeferSearch = true;
            }

        }

        private void ThreadProcedure()
        {
            try
            {
                string localSearch = SearchCriteria;

                RecurseDirectory(localSearch);
            }
            finally {
                _Searching = false;

                BeginInvoke(_OnSearchComplete, new object[] { this, EventArgs.Empty });
            }

        }

        //should be called on gui thread
        private void AddFiles(string[] files, int startIndex, int count)
        {
            while(count-- > 0)
            {
                _ListBox.Items.Add(files[startIndex+count]);
            }
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (!RecreatingHandle)
            {
                StopSearch();
            }
            base.OnHandleDestroyed(e);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (_DeferSearch)
            {
                _DeferSearch = false;
                BeginSearch();
            }
        }

        public void StopSearch() {
            if (!_Searching)
            {
                return;
            }

            if (_SearchThread.IsAlive)
            {
                _SearchThread.Abort();
                _SearchThread.Join();
            }

            _SearchThread = null;
            _Searching = false;
        }

        private void RecurseDirectory(string searchPath)
        {
            string directory = Path.GetDirectoryName(searchPath);
            string search = Path.GetFileName(searchPath);

            if (directory == null || search == null)
            {
                return;
            }

            string[] files;

            try
            {
                files = Directory.GetFiles(directory, search);
            }
            catch (UnauthorizedAccessException) {
                return;
            }
            catch (DirectoryNotFoundException)
            {
                return;
            }

            int startingIndex = 0;

            while (startingIndex < files.Length)
            {
                int count = 20;
                if (count + startingIndex >= files.Length)
                {
                    count = files.Length - startingIndex;
                }

                IAsyncResult r = BeginInvoke(_FileListDelegate, new object[] {files, startingIndex, count });
                startingIndex += count;
            }

            string[] directories = Directory.GetDirectories(directory);
            foreach (string d in directories)
            {
                RecurseDirectory(Path.Combine(d,search));
            }

        }
    }
}
