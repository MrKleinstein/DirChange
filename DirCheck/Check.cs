using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirCheck
{
    class Check
    {
        private FileSystemWatcher watcher;
        private string path = @"C:\Users\tklei\OneDrive\Desktop";

        public Check()
        {
            watcher = new FileSystemWatcher(path);
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName;

        }

        public void Start()
        {
            watcher.Created+=new FileSystemEventHandler(OnCreated);
            watcher.EnableRaisingEvents = true;
            watcher.IncludeSubdirectories = true;
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            string cha = "Es wurde die Datei "+e.Name+" hinzugefuegt!";
            File.WriteAllText(@"C:\Users\tklei\OneDrive\Desktop\changed.txt",cha );
        }


        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
        }
    }
}
