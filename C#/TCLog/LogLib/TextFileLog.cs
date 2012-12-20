using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


class TextFileLog : ILogInterface
{
  const string HDR_SUCCESS = "SUCCESS";
  const string HDR_FAIL = "FAIL";
  const string HDR_WARNING = "WARNING";
  const string HDR_MANUAL = "MANUAL";
  const string HDR_DEBUG = "DEBUG";
  const string HDR_EVENT = "EVENT";
  const string HDR_TESTSTEP = "TEST STEP";

  private StreamWriter m_SW = null;
  private string m_fullpath;

  private int m_ErrorCount = 0;
  private int m_WarningCount = 0;
  private int m_SuccessCount = 0;
  private int m_ManualCount = 0;

  private bool m_bVerbose = false;  // Debug verbose
  private bool m_eVerbose = false;  // Event verbose
  private bool m_tVerbose = false;  // TestStep verbose

  public TextFileLog(string where, string what, bool bVerbose, bool eVerbose, bool tVerbose)
  {
    string time = DateTime.Now.ToString();
    time = time.Replace(":", ".");
    m_fullpath = Path.Combine(where, time + " " + what);

    Screen.Init(m_fullpath);
    Start(what, bVerbose, eVerbose, tVerbose);
  }


  public void File(string msg, int? sss, string file)
  {
      FileInfo orgFile = new FileInfo(file);
      string filename = Path.Combine(m_fullpath, orgFile.Name);

      orgFile.CopyTo(filename);

      Write(msg, HDR_MANUAL, sss, filename);
      ++m_ManualCount;
  }

  private string ScreenShot(string wndClass, string wndName, int? x, int? y, int? w, int? h)
  {
    if (x.HasValue && y.HasValue && w.HasValue && h.HasValue)
      return Screen.LogWindowRegion(wndClass, wndName, x.Value, y.Value, w.Value, h.Value);
    else
      return Screen.LogWindow(wndClass, wndName);
  }

  public void Manual(string msg, int? sss, string wndClass, string wndName)
  {
    string filename = ScreenShot(wndClass, wndName, null, null, null, null);
    Write(msg, HDR_MANUAL, sss, filename);
    ++m_ManualCount;
  }

  public void ManualRegion(string msg, int? sss, string wndClass, string wndName, int x, int y, int w, int h)
  {
    string filename = ScreenShot(wndClass, wndName, x, y, w, h);
    Write(msg, HDR_MANUAL, sss, filename);
    ++m_ManualCount;
  }

  public void Warning(string msg, int? sss )
  {
    Write(msg, HDR_WARNING, sss);
    ++m_WarningCount;
  }

  public void Debug(string msg, int? sss)
  {
    if (m_bVerbose)
      Write(msg, HDR_DEBUG, sss);
  }

  public void Fail(string msg, int? sss)
  {
    Write(msg, HDR_FAIL, sss);
    ++m_ErrorCount;
  }

  public void Success(string msg, int? sss)
  {
    Write(msg, HDR_SUCCESS, sss);
    ++m_SuccessCount;
  }

  public void Event(string msg, int? sss)
  {
      if (m_eVerbose)
          Write(msg, HDR_EVENT, sss);
  }

  public void TestStep(string msg, int? sss)
  {
      if (m_tVerbose)
          Write(msg, HDR_TESTSTEP, sss);
  }

  private void Start(string name, bool bVerbose, bool eVerbose, bool tVerbose)
  {
    m_ErrorCount = 0;
    m_WarningCount = 0;
    m_SuccessCount = 0;
    m_ManualCount = 0;

    m_bVerbose = bVerbose;
    m_eVerbose = eVerbose;
    m_tVerbose = tVerbose;

    Directory.CreateDirectory(m_fullpath);
    string mainLogFile = Path.Combine(m_fullpath, name + ".log");

    m_SW = System.IO.File.CreateText(mainLogFile);

    m_SW.WriteLine();
    m_SW.WriteLine("Log started:  " + DateTime.Now.ToString());
    m_SW.WriteLine("-----------------------------------------------------------------------------");
    string header = String.Format("| {0, -25}| {1, -10}| {2, -10}| {3}", "Date / Time", "Status", "SSS", "Message");
    m_SW.WriteLine(header);
    m_SW.WriteLine("-----------------------------------------------------------------------------");
  }

  public void Close()
  {
    if (m_SW != null)
    {
      m_SW.WriteLine("-----------------------------------------------------------------------------");
      m_SW.WriteLine("Log closed:   " + DateTime.Now.ToString());
      m_SW.WriteLine("");
      m_SW.WriteLine("");
      m_SW.WriteLine("Passed:                    " + m_SuccessCount);
      m_SW.WriteLine("Failed:                    " + m_ErrorCount);
      m_SW.WriteLine("Warning(s):                " + m_WarningCount);
      m_SW.WriteLine("Manual checks required:    " + m_ManualCount);
      m_SW.Flush();
      m_SW.Close();
      m_SW.Dispose();
      m_SW = null;
    }
  }

  private string BuildLogLine(string msg, string status, int? sss)
  {
    var time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
    
    string line = String.Format("| {0, -25}| {1, -10}| {2, -10}| {3}", time, status, (sss.HasValue ? sss.Value.ToString() : "N/A"), msg);
    return line;
  }

  private string BuildLogLineNoDate(string screenshot)
  {
    screenshot = screenshot.Replace("/", "\\");
    string line = String.Format("| {0, -25}| {1, -10}| {2, -10}| {3}", "", "", "", screenshot);
    return line;
  }

  private void Write(string msg, string status, int? sss)
  {
    if (m_SW != null)
    {
      var line = BuildLogLine(msg, status, sss);
      m_SW.WriteLine(line);
      m_SW.Flush();
    }
  }

  private void Write(string msg, string status, int? sss, string screenshot)
  {
    if (m_SW != null)
    {
      var line = BuildLogLineNoDate("");
      m_SW.WriteLine(line);
      line = BuildLogLine(msg, status, sss);
      m_SW.WriteLine(line);
      line = BuildLogLineNoDate(screenshot);
      m_SW.WriteLine(line);
      line = BuildLogLineNoDate("");
      m_SW.WriteLine(line);
      m_SW.Flush();
    }
  }
}
