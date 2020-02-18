using System.Collections;
using System.IO;
using System.Text;
using System.Collections.Generic;
using UnityEngine;

namespace SnowdramaUtils
{
    public class JsonFileUtility
    {

        /*
        ██╗      ██████╗  █████╗ ██████╗      █████╗ ███████╗    ██████╗ ███████╗███████╗ ██████╗ ██╗   ██╗██████╗  ██████╗███████╗
        ██║     ██╔═══██╗██╔══██╗██╔══██╗    ██╔══██╗██╔════╝    ██╔══██╗██╔════╝██╔════╝██╔═══██╗██║   ██║██╔══██╗██╔════╝██╔════╝
        ██║     ██║   ██║███████║██║  ██║    ███████║███████╗    ██████╔╝█████╗  ███████╗██║   ██║██║   ██║██████╔╝██║     █████╗
        ██║     ██║   ██║██╔══██║██║  ██║    ██╔══██║╚════██║    ██╔══██╗██╔══╝  ╚════██║██║   ██║██║   ██║██╔══██╗██║     ██╔══╝
        ███████╗╚██████╔╝██║  ██║██████╔╝    ██║  ██║███████║    ██║  ██║███████╗███████║╚██████╔╝╚██████╔╝██║  ██║╚██████╗███████╗
        ╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═════╝     ╚═╝  ╚═╝╚══════╝    ╚═╝  ╚═╝╚══════╝╚══════╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═╝ ╚═════╝╚══════╝

        */

        public static bool LoadJsonAsResource(string path, string filename, ref string res)
        {
            string jsonFilePath = path + "/" + filename.Replace(".json", "");
            TextAsset loadedJsonfile = Resources.Load<TextAsset>(jsonFilePath);
            if (loadedJsonfile == null)
            {
                return false;
            }
            res = loadedJsonfile.text;
            return true;
        }

        public static string LoadJsonAsResource(string path, string filename)
        {
            string jsonFilePath = path + "/" + filename.Replace(".json", "");
            TextAsset loadedJsonfile = Resources.Load<TextAsset>(jsonFilePath);
            return loadedJsonfile.text;
        }

        /*
        ██╗      ██████╗  █████╗ ██████╗      █████╗ ███████╗    ███████╗██╗  ██╗████████╗███████╗██████╗ ███╗   ██╗ █████╗ ██╗
        ██║     ██╔═══██╗██╔══██╗██╔══██╗    ██╔══██╗██╔════╝    ██╔════╝╚██╗██╔╝╚══██╔══╝██╔════╝██╔══██╗████╗  ██║██╔══██╗██║
        ██║     ██║   ██║███████║██║  ██║    ███████║███████╗    █████╗   ╚███╔╝    ██║   █████╗  ██████╔╝██╔██╗ ██║███████║██║
        ██║     ██║   ██║██╔══██║██║  ██║    ██╔══██║╚════██║    ██╔══╝   ██╔██╗    ██║   ██╔══╝  ██╔══██╗██║╚██╗██║██╔══██║██║
        ███████╗╚██████╔╝██║  ██║██████╔╝    ██║  ██║███████║    ███████╗██╔╝ ██╗   ██║   ███████╗██║  ██║██║ ╚████║██║  ██║███████╗
        ╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═════╝     ╚═╝  ╚═╝╚══════╝    ╚══════╝╚═╝  ╚═╝   ╚═╝   ╚══════╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝╚══════╝

        */

        public static bool LoadJsonAsExternalResource(string path, string filename, ref string response)
        {
            string filePath = Application.persistentDataPath + "/" + path + "/" + filename;
            if (!File.Exists(filePath))
            {
                return false;
            }
            StreamReader reader = new StreamReader(filePath);
            string rez = "";
            while (!reader.EndOfStream)
            {
                rez += reader.ReadLine();
            }
            response = rez;
            reader.Close();
            return true;
        }

        /*
        ██╗    ██╗██████╗ ██╗████████╗███████╗     █████╗ ███████╗    ███████╗██╗  ██╗████████╗███████╗██████╗ ███╗   ██╗ █████╗ ██╗
        ██║    ██║██╔══██╗██║╚══██╔══╝██╔════╝    ██╔══██╗██╔════╝    ██╔════╝╚██╗██╔╝╚══██╔══╝██╔════╝██╔══██╗████╗  ██║██╔══██╗██║
        ██║ █╗ ██║██████╔╝██║   ██║   █████╗      ███████║███████╗    █████╗   ╚███╔╝    ██║   █████╗  ██████╔╝██╔██╗ ██║███████║██║
        ██║███╗██║██╔══██╗██║   ██║   ██╔══╝      ██╔══██║╚════██║    ██╔══╝   ██╔██╗    ██║   ██╔══╝  ██╔══██╗██║╚██╗██║██╔══██║██║
        ╚███╔███╔╝██║  ██║██║   ██║   ███████╗    ██║  ██║███████║    ███████╗██╔╝ ██╗   ██║   ███████╗██║  ██║██║ ╚████║██║  ██║███████╗
        ╚══╝╚══╝ ╚═╝  ╚═╝╚═╝   ╚═╝   ╚══════╝    ╚═╝  ╚═╝╚══════╝    ╚══════╝╚═╝  ╚═╝   ╚═╝   ╚══════╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝╚══════╝

        */
        public static void WriteJsonToExternalResource(string path, string filename, string content)
        {
            string directoryPath = Application.persistentDataPath + "/" + path;
            string filePath = directoryPath + "/" + filename;
            Debug.Log("Writing file to:" + directoryPath);
            if (!System.IO.Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            FileStream stream = File.Create(filePath);
            byte[] contentBytes = new UTF8Encoding(true).GetBytes(content);
            stream.Write(contentBytes, 0, contentBytes.Length);
            stream.Dispose();
        }
    }
}