using System.Reflection;

namespace WSH_HomeAssignment.Tests
{
    internal static class TestFile
    {
        public static string ReadAllText(string file)
        {
            return File.ReadAllText
                (Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "Files", file));
        }
    }
}