using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.Odbc;
using System.Drawing;
using System.Drawing.Imaging;

class DBLog : ILogInterface
{
  const string HDR_SUCCESS = "SUCCESS";
  const string HDR_FAIL = "FAIL";
  const string HDR_WARNING = "WARNING";
  const string HDR_MANUAL = "MANUAL";
  const string HDR_DEBUG = "DEBUG";
  const string HDR_EVENT = "EVENT";
  const string HDR_TESTSTEP = "TEST STEP";

  private string m_current_ITD_ITR;
  private string m_current_Version = "";
  private string m_current_GUID;
  private string m_misc = "";

  private int m_ErrorCount = 0;
  private int m_WarningCount = 0;
  private int m_SuccessCount = 0;
  private int m_ManualCount = 0;

  private OdbcConnection m_DBConnection = null;
 
  private bool m_bVerbose = false;
  private bool m_eVerbose = false;
  private bool m_tVerbose = false;

  public DBLog(string where, string what, bool bVerbose, bool eVerbose, bool tVerbose, string ITD_ITR, string version, string misc)
  {
    m_current_ITD_ITR = ITD_ITR;
    m_current_Version = version;
    m_misc = misc;
    
    Start(where, what, bVerbose, eVerbose, tVerbose);
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
    string image = ScreenShot(wndClass, wndName, null, null, null, null);
    Insert_LogItem_With_Image(msg, HDR_MANUAL, sss, image);
    ++m_ManualCount;
  }

  public void File(string msg, int? sss, string file)
  {
      FileInfo orgFile = new FileInfo(file);
      string filename = Path.Combine(m_imagePath, orgFile.Name);

      orgFile.CopyTo(filename);

      Insert_LogItem_With_Image(msg, HDR_MANUAL, sss, filename);
      ++m_ManualCount;
  }

  public void ManualRegion(string msg, int? sss, string wndClass, string wndName, int x, int y, int w, int h)
  {
    string image = ScreenShot(wndClass, wndName, x, y, w, h);
    Insert_LogItem_With_Image(msg, HDR_MANUAL, sss, image);
    ++m_ManualCount;
  }

  public void Warning(string msg, int? sss)
  {
    Insert_LogItem(msg, HDR_WARNING, sss);
    ++m_WarningCount;
  }

  public void Debug(string msg, int? sss)
  {
    if (m_bVerbose)
      Insert_LogItem(msg, HDR_DEBUG, sss);
  }

  public void Fail(string msg, int? sss)
  {
    Insert_LogItem(msg, HDR_FAIL, sss);
    ++m_ErrorCount;
  }

  public void Success(string msg, int? sss)
  {
    Insert_LogItem(msg, HDR_SUCCESS, sss);
    ++m_SuccessCount;
  }

  public void Event(string msg, int? sss)
  {
      if (m_eVerbose)
          Insert_LogItem(msg, HDR_EVENT, sss);
  }

  public void TestStep(string msg, int? sss)
  {
      if (m_tVerbose)
          Insert_LogItem(msg, HDR_TESTSTEP, sss);
  }

  private void Insert_ITD_ITR(string ITD_ITR, string Version, string Misc)
  {
    if (OpenConnection() == true)
    {
      string query = "INSERT INTO itd_itr (ID, ITD_ITR1, Started, Version, Misc) VALUES(";
      query += "'" + m_current_GUID + "',";
      query += "'" + m_current_ITD_ITR + "',";
      query += "'" + DateTime.Now + "',";
      query += "'" + Version + "',";
      query += "'" + Misc + "')";

      OdbcCommand cmd = new OdbcCommand(query, m_DBConnection);
      var numrows = cmd.ExecuteNonQuery();

      CloseConnection();
    }
  }

  private void Update_ITD_ITR()
  {
    if (OpenConnection() == true)
    {
      string query = "UPDATE itd_itr "; 
      query += "SET Successful='" + m_SuccessCount + "', ";
      query += "Failed='" + m_ErrorCount + "', ";
      query += "Warnings='" + m_WarningCount + "', ";
      query += "Successful='" + m_SuccessCount + "', ";
      query += "ManualChecks='" + m_ManualCount + "', ";
      query += "Stopped='" + DateTime.Now + "' ";
      query += "WHERE ID = '" + m_current_GUID + "'";

      OdbcCommand cmd = new OdbcCommand(query, m_DBConnection);
      var numrows = cmd.ExecuteNonQuery();

      CloseConnection();
    }
  }

  private void Insert_LogItem(string msg, string status, int? sss)
  {
    if (OpenConnection() == true)
    {
      msg = msg.Replace("'", "''");
      string query = "INSERT INTO log_item (DateTime, Status, Message, SSS, ITD_ITR_ID) VALUES(";
      query += "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', ";
      query += "'" + status + "', ";
      query += "'" + msg + "', ";
      query += (sss.HasValue ? "'" + sss.Value.ToString() + "'" : "''") + ", ";
      query += "'" + m_current_GUID + "')";

      OdbcCommand cmd = new OdbcCommand(query, m_DBConnection);
      var numrows = cmd.ExecuteNonQuery();

      CloseConnection();
    }
  }

  private void Insert_LogItem_With_Image(string msg, string status, int? sss, string image)
  {
    if (OpenConnection() == true)
    {
      msg = msg.Replace("'", "''");
      image = image.Replace("\\", "/");


      string query = "INSERT INTO log_item (DateTime, Status, Message, SSS, ITD_ITR_ID, Screenshot) VALUES(";
      query += "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', ";
      query += "'" + status + "', ";
      query += "'" + msg + "', ";
      query += (sss.HasValue ? "'" + sss.Value.ToString() + "'" : "''") + ", ";
      query += "'" + m_current_GUID + "',";
      query += "'" + image + "')";

      OdbcCommand cmd = new OdbcCommand(query, m_DBConnection);
    
      var numrows = cmd.ExecuteNonQuery();
      CloseConnection();
    }
  }

  private bool OpenConnection()
  {
    try
    {
      m_DBConnection.Open();
      return true;
    }
    catch (OdbcException e)
    {
      return false;
    }
  }

  private bool CloseConnection()
  {
    try
    {
      m_DBConnection.Close();
      return true;
    }
    catch (OdbcException)
    {
      return false;
    }
  }

  private string m_imagePath;

  private void StartNewTestcase(string imagePath)
  {
    Insert_ITD_ITR(m_current_ITD_ITR, m_current_Version, m_misc);
    m_imagePath = Path.Combine(imagePath, m_current_GUID);
    Directory.CreateDirectory(m_imagePath);
    Screen.Init(m_imagePath);
  }

  private void Start(string where, string what, bool bVerbose, bool eVerbose, bool tVerbose)
  {
    m_bVerbose = bVerbose;
    m_eVerbose = eVerbose;
    m_tVerbose = tVerbose;
    m_current_GUID = System.Guid.NewGuid().ToString();
    
    m_ErrorCount = 0;
    m_WarningCount = 0;
    m_SuccessCount = 0;
    m_ManualCount = 0;

    string connString = where; 
    m_DBConnection = new OdbcConnection(connString);

    StartNewTestcase(what);
    
  }

  public void Close()
  {
    Update_ITD_ITR();
  }
}
