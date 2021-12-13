using framework_core.Logging;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace framework_core
{
 /// <summary>
 /// Base class provided by Core framework.
 /// Provides access to an un-instantialed ConfigurationService.
 /// </summary>
    public class BaseTestClass
    {
        /// <summary>
        /// 
        /// </summary>
        public ConfigurationService Config;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.Config = new ConfigurationService();
        }

    }
}
