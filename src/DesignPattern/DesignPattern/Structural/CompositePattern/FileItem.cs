using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Structural.CompositePattern
{
    // Leaf class
    public class FileItem : FileSystemItem
    {
        public long FileBytes { get; }

        public FileItem(string name, long fileBytes) : base(name)
        {
            this.FileBytes = fileBytes;
        }

        public override decimal GetSizeInKB()
        {
            return decimal.Divide(this.FileBytes, 1000);
        }
    }
}
