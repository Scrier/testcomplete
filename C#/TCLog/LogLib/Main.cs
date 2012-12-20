using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Custom
{

  public class Log
  {
    private static ILogInterface myLog = null;
      
    static public void Init(string logType, string where, string what, bool bVerbose, bool eVerbose, bool tVerbose, string ITD_ITR, string version, string misc)
    {
      if (myLog != null)
        myLog.Close();

      switch (logType)
      {
        case "DB":
              myLog = new DBLog(where, what, bVerbose, eVerbose, tVerbose, ITD_ITR, version, misc);
          break;
        case "TEXT":
        default:
            myLog = new TextFileLog(where, what, bVerbose, eVerbose, tVerbose);
          break;
      }
    }

    static public void Close()
    {
      myLog.Close();
    }
    static public void ForceScreenshotDirectory(string path)
    {
      Screen.Init(path);
    }
    static public string ScreenshotWindow(string wndClass, string wndCaption)
    {
      return Screen.LogWindow(wndClass, wndCaption);
    }

    static public string ScreenshotWindowRegion(string wndClass, string wndCaption, int x, int y, int w, int h)
    {
      return Screen.LogWindowRegion(wndClass, wndCaption, x, y, w, h);
    }

    static public void Warning(string msg, int sss)
    {
      myLog.Warning(msg, (sss == -1 ? (int?)null : sss));
    }

    static public void Fail(string msg, int sss)
    {
      myLog.Fail(msg, (sss == -1 ? (int?)null : sss));
    }

    static public void Debug(string msg, int sss)
    {
      myLog.Debug(msg, (sss == -1  ? (int?)null : sss));
    }

    static public void Success(string msg, int sss)
    {
      myLog.Success(msg, (sss == -1 ? (int?)null : sss));
    }

    static public void Manual(string msg, int sss, string wndClass, string wndName)
    {
      myLog.Manual(msg, (sss == -1 ? (int?)null : sss), wndClass, wndName);
    }

    static public void File(string msg, int? sss, string file)
    {
        myLog.File(msg, (sss == -1 ? (int?)null : sss), file);
    }

    static public void ManualRegion(string msg, int sss, string wndClass, string wndName, int x, int y, int w, int h)
    {
      myLog.ManualRegion(msg, (sss == -1 ? (int?)null : sss), wndClass, wndName, x, y, w, h);
    }

    static public void Event(string msg, int sss)
    {
        myLog.Event(msg, (sss == -1 ? (int?)null : sss));
    }

    static public void TestStep(string msg, int sss)
    {
        myLog.TestStep(msg, (sss == -1 ? (int?)null : sss));
    }

  }
}
