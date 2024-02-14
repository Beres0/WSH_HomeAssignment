using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WSH_HomeAssignment.Tests
{
    static class TestFile
    {
        public static string ReadAllText(string file)
        {
            return File.ReadAllText
                (Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,"Files", file));
        }
    }
}
