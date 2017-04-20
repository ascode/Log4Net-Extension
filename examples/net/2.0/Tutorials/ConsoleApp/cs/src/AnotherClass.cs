using System;
using System.Collections.Generic;
using System.Text;

using ConsoleApp.LogEx;


namespace ConsoleApp
{
    public class AnotherClass
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public AnotherClass() {
            log.Info("这是另外一个Class");
            log.Info(new ComplexFanLogMessage("aaa","bbb","ccc","","","","","",""));
            GetAJoke();
        }

        public void GetAJoke() {
            log.Info(new ComplexFanLogMessage("this is a joke", "this is second joke", "", "","","","","",""));
        }
    }
}
