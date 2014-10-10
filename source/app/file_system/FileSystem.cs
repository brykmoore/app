using System.Collections.Generic;
using System.IO;

namespace app.file_system
{
  public class FileSystem
  {
    public static readonly IReadTheLinesInAFile read_lines_in_file = File.ReadAllLines;
  }

  public delegate IEnumerable<string> IReadTheLinesInAFile(string file_name);

}