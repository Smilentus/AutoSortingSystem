using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Json.Serialization;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace FileSortingSystemV2._0
{
    [Serializable]
    public class Saver
    {
        public string sortPath { get; set; }
        public List<customPath> createdPaths { get; set; }
    }

    public static class DataBase
    {
        public static List<customPath> createdPaths = new List<customPath>();

        public static int openedIndex = -1;
        public static bool isEditing = false;
        private static string savePath = @"data.json";
        public static string sortPath = "";
        public static List<string> logList = new List<string>();

        public static JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            IgnoreReadOnlyProperties = true,
            WriteIndented = true
        };

        public static void SaveData()
        {
            Saver saver = new Saver();

            saver.sortPath = sortPath;
            saver.createdPaths = createdPaths;

            string json = JsonSerializer.Serialize<Saver>(saver, options);
            File.WriteAllText(savePath, json, Encoding.UTF8);
        }

        public static void LoadData()
        {
            if (File.Exists(savePath))
            {
                string json = File.ReadAllText(savePath, Encoding.UTF8);
                Saver saver = JsonSerializer.Deserialize<Saver>(json, options);

                sortPath = saver.sortPath;
                createdPaths = saver.createdPaths;
            }
        }
    }
}
