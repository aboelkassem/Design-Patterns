using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Creational.Singleton
{
    public class Counter
    {
        // The sole instance of the class
        private static Counter instance = null;

        public int count = 0;
        // just for locking this object to solve multi-threading problem
        private static object lockObj = new object();

        // Make the constructor private so its only accessible to members of the class.
        private Counter(){}

        // Create a static method for object creation
        public static Counter GetInstance()
        {
            // Only instantiate the object when needed, to save memory recourses
            // Lazy Initialization
            // Double-checked locking
            if (instance == null)
            {
                lock(lockObj)
                {
                    if (instance == null)
                    {
                        instance = new Counter();
                    }
                }
            }

            return instance;
        }

        public void AddOne(){count++;}
    }
}
