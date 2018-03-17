﻿using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingDelegates
{
    [TestClass] 
    public class Test_AsyncDelegates
    {
        private void DoWork()
        {
            Debug.WriteLine("Hello World1");
            Debug.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
        }

        delegate void DoWorkDelegate();

        [TestMethod]
        public void Demo01()
        {
           // DoWork();
            Debug.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
            DoWorkDelegate m = new DoWorkDelegate(DoWork);
            m.Invoke();
            AsyncCallback callback = new AsyncCallback(TheCallback);
            IAsyncResult ar = m.BeginInvoke(callback, m);
            //// do more 

            ar.AsyncWaitHandle.WaitOne();
        }

        private static void TheCallback(IAsyncResult ar)
        {
            var m = ar.AsyncState as DoWorkDelegate;
            m.EndInvoke(ar); // this is where you use try/catch
        }
    }
}
