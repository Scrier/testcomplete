using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

interface ILogInterface
{
  void Manual(string msg, int? sss, string wndClass, string wndName);
  void ManualRegion(string msg, int? sss, string wndClass, string wndName, int x, int y, int w, int h);
  void Warning(string msg, int? sss);
  void Debug(string msg, int? sss);
  void Fail(string msg, int? sss);
  void Success(string msg, int? sss);
  void Event(string msg, int? sss);
  void TestStep(string msg, int? sss);
  void File(string msg, int? sss, string file);
  string GetPicturePath();

  void Close();
}
