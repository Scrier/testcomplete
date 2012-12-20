using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.IO;
using System.Data.Common;
using System.Drawing.Imaging;


namespace TestApp
{
    class Program
    {
      static void Main(string[] args)
      {
        //  Custom.Log.Init("DB", "DRIVER={MySQL ODBC 3.51 Driver};Server=10.180.248.20;Database=testcompletelog;uid=root;pwd=root", "C:/LogImages", true, true, true, "ITD_ITR_12345", "3.10.6.7", "");
          Custom.Log.Init("TEXT", "C:/test", "MyTest", true, true, true, "ITD_ITR_12345", "3.10.6.7", "");


          Custom.Log.File("En fil", null, "Z:/tb/app/VMFSimulator/ITD_ITR_XXXaaaaaa/log/2012-06-15T13-07-30_E32_ack.xml");

          Custom.Log.Fail("This failed miserably!", -1);
        
          Custom.Log.Success("This was a grand success!", -1);
          Custom.Log.Fail("This failed miserably too!", 6578);
          Custom.Log.Success("This was a grand success!", 2345);
          Custom.Log.Manual("Check the picture!", -1, "QWidget", "");
          Custom.Log.Success("This was a grand success!", 654);  
          Custom.Log.Debug("This DEBUGGED!", 1234);
          Custom.Log.Success("Before snapshot", 345);
          Custom.Log.Fail("This failed miserably too!", -1);
          Custom.Log.Fail("This failed miserably also!", -1);
          Custom.Log.Success("Before snapshot", 345);
          Custom.Log.Manual("Check the picture again!", -1, "QWidget", "");
          Custom.Log.ManualRegion("Check the region!", -1, "QWidget", "", 20, 20, 200, 200);
          Custom.Log.Success("After snapshot", -1);
          Custom.Log.Debug("This DEBUGGED itself!", 2345);
      
          Custom.Log.Close();
        }
    }
}
