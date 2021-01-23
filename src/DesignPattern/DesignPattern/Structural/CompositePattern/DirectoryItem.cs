using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Structural.CompositePattern
{
    // Composite Class
    public class DirectoryItem : FileSystemItem
    {
        public List<FileSystemItem> Items { get; } = new List<FileSystemItem>();

        public DirectoryItem(string name) : base(name)
        {
        }

        public void Add(FileSystemItem component)
        {
            this.Items.Add(component);
        }

        public void Remove(FileSystemItem component)
        {
            this.Items.Remove(component);
        }

        public override decimal GetSizeInKB()
        {
            // get the size of all it's children
            return this.Items.Sum(x => x.GetSizeInKB());
        }
    }
}
