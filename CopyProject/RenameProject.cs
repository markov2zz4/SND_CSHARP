using System;
using System.Diagnostics;
using System.IO;


namespace CopyProject
{
    internal class RenameProject
    {
        static void Main(string[] args)
        {

            
            Console.WriteLine("Enter a source path: ");
            string sourceDir = Console.ReadLine();
            
            Console.WriteLine("Enter name of new project: ");
            string newProjectName = Console.ReadLine();

            string newProjectDir = Path.GetDirectoryName(sourceDir) + "\\" + newProjectName;

            MoveFiles(sourceDir, newProjectDir);
            RenameAllFiles(newProjectDir, newProjectName);
            RenameAllDirs(newProjectDir, newProjectName);
            
            

        }

        public static void MoveFiles(string sourceDir, string newProjectDir)
        {
            if (Directory.Exists(sourceDir))
            {
                try
                {
                    Process xcopy = new Process();
                    xcopy.StartInfo.FileName = "cmd.exe";
                    xcopy.StartInfo.Arguments = $"/C xcopy {sourceDir} {newProjectDir} /E /I /Y"; // /E - копировать папки и подпапки, /I - создавать папки при необходимости, /Y - подавлять запрос на подтверждение перезаписи
                    xcopy.Start();
                    xcopy.WaitForExit();
                    
                }

                catch (Exception e)
                {
                    Console.WriteLine("Error copy project: " + e.Message);
                }
                Console.WriteLine($"Проект перемещен в директорию: {newProjectDir}");
            }
        }

        public static void RenameAllFiles(string newProjectDir, string newProjectName)
        {
            try
            {
                string[] files = Directory.GetFiles(newProjectDir, "*", SearchOption.AllDirectories);
                foreach (string file in files)
                {

                    string newFilePath;
                    if (Path.GetFileName(file).Contains("DemoLightWin"))
                    {

                        newFilePath = Path.Combine(Path.GetDirectoryName(file), Path.GetFileName(file).Replace("DemoLightWin", newProjectName));
                        File.Move(file, newFilePath);


                    }
                    else if (Path.GetFileName(file).Contains("DemoLight"))
                    {
                        newFilePath = Path.Combine(Path.GetDirectoryName(file), Path.GetFileName(file).Replace("DemoLight.WpfView", newProjectName + ".WpfView"));
                        File.Move(file, newFilePath);
                        
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error renaming files " + ex.Message);
            }
            
        }

        public static void RenameAllDirs(string newProjectDir, string newProjectName)
        {
            string[] dirs = Directory.GetDirectories(newProjectDir, "*", SearchOption.AllDirectories);
            string newDirName;

            foreach(string dir in dirs)
            {
                if(Path.GetFileName(dir).Contains("DemoWin"))
                {
                    newDirName = Path.Combine(dir.Replace(Path.GetFileName(dir), Path.GetFileName(newProjectDir) + ".WpfView"));
                    Directory.Move(dir, newDirName);
                }
            }
            
            
        }
    }
}