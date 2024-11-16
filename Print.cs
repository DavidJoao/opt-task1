using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        string csCode = @"
using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        string csCode = @""""using System;
        using System.Diagnostics;

        class Program
        {
            static void Main()
            {
                string jsCode = $@""const originalCSharpCode = \`{csCode}\`; console.log(originalCSharpCode);"";

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = ""node"",
                    Arguments = $@""-e \""{jsCode.Replace(""\"""", ""\\\"""")}\"""",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(startInfo))
                {
                    using (System.IO.StreamReader reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();
                        Console.WriteLine(result);
                }
            }""
            }
        }
    }
}";

        string jsCode = $@"
            const originalCSharpCode = `{csCode}`;
            console.log(originalCSharpCode);
        ";

        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "node",
            Arguments = $"-e \"{jsCode.Replace("\"", "\\\"")}\"",
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using (Process process = Process.Start(startInfo))
        {
            using (System.IO.StreamReader reader = process.StandardOutput)
            {
                string result = reader.ReadToEnd();
                Console.WriteLine(result);
            }
        }
    }
}
