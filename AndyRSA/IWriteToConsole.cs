using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndyRSA
{
  public interface IConsole
  {
    void Write(string s);
    void WriteLine(string s);
    char ReadKeyChar();
    string ReadLine();
  }

  public class SystemConsole : IConsole
  {
    public void Write(string s)
    {
      Console.Write(s);
    }

    public void WriteLine(string s)
    {
      Console.WriteLine(s);
    }

    public char ReadKeyChar()
    {
      return Console.ReadKey().KeyChar;
    }

    public string ReadLine()
    {
      return Console.ReadLine();
    }
  }
}
