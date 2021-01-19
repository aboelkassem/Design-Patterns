using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Creational.Singleton
{
    class AppSettings
    {
        // the class variable is null if no instance is instantiated
        private static AppSettings Instance = null;
        private AppSettings() {}

        public static AppSettings GetInstance()
        {
            if (Instance == null)
            {
                Instance = new AppSettings();
            }
            return Instance;
        }
    }
}
