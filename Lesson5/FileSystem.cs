using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lesson5
{
    public class FileSystemSearch
    {
        private const char indent = ' ';
        private const string root = ">";

        public static string GetFS(string path,int indentSize)
        {
            var pathName = path.Split('\\');
            var original = pathName.Length + indentSize;
            var sb = new StringBuilder();
            sb.AppendLine($"{new string(indent,indentSize)}{root}{pathName[pathName.Length - 1]}");
            string[] files = Directory.GetFiles(path);
            if (files != null)
            {
                foreach (var file in files)
                {
                    var fileName = file.Split('\\');
                    sb.AppendLine($"{new string(indent, indentSize)}{fileName[fileName.Length - 1]}");
                }
            }
            var subdirs = Directory.GetDirectories(path);
            foreach(var subdir in subdirs)
            {
                var next = subdir.Split('\\');
                sb.AppendLine(GetFS(subdir, (next.Length - pathName.Length)+indentSize));
            }
            return sb.ToString().TrimEnd();
        }
        public static void Save(string fileName,string path)
        {
            var dir = @"C:\TestDir";
            var fileDir = Path.Combine(dir, fileName);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            File.WriteAllText(fileDir, GetFS(path, 1));
        }
    }
}
