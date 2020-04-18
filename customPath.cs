using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace FileSortingSystemV2._0
{
    public class customPath
    {
        public string constructedName { get; set; }
        public string constructedPath { get; set; }
        public string constructedTag { get; set; }
        public List<string> constructedExtensions { get; set; }

        public string getNameTag
        {
            get
            {
                return constructedName + " | Тэг - " + constructedTag;
            }
            private set { }
        }

        [ScriptIgnore]
        public string getPath
        {
            get
            {
                return "Путь: " + constructedPath;
            }
            private set { }
        }

        public customPath()
        { }

        public customPath(string name, string path, string tag)
        {
            constructedName = name;
            constructedPath = path;
            constructedTag = tag;
            constructedExtensions = new List<string>();
        }
    }
}
