using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DemoRecorder
{
    class Program
    {
        static void Main(string[] args)
        {
            string EngineName = "Quake3-UrT.exe";

            string currentFolder = Directory.GetCurrentDirectory();
            string enginePath = currentFolder + Path.DirectorySeparatorChar + EngineName;
            string demoDirPath = currentFolder + Path.DirectorySeparatorChar + "q3ut4" + Path.DirectorySeparatorChar + "demos";

            string[] demos = Directory.GetFiles(demoDirPath, "*.urtdemo").Select(x => Path.GetFileNameWithoutExtension(x)).ToArray();

            string scriptPath = demoDirPath + Path.DirectorySeparatorChar + "demoListScript.cfg";
            List<string> scriptLines = new List<string>();

            for (int i = 0; i < demos.Count() - 1; i++)
                scriptLines.Add(String.Format("seta demo{0} \"set nextdemo vstr demo{1}; demo {2}; vstr videogui; video\"", i, i + 1, demos[i]));

            scriptLines.Add(String.Format("seta demo{0} \"demo {1}; video\"", demos.Count() - 1, demos[demos.Count() - 1]));
            //scriptLines.Add("seta videogui \"cg_draw2d 0; cg_msgtime 0; cg_chattime 0; cg_gunx 10; cg_guny -20; cg_gunz 5; cg_gunx 0; cg_guny 10; cg_gunz 5\"");
            scriptLines.Add("vstr demo0");

            File.WriteAllLines(scriptPath, scriptLines);
            Process.Start(enginePath, "exec \"demos/demoListScript\"");
        }
    }
}
