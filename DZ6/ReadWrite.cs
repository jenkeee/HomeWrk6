using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ6
{
    internal static class ReadWrite
    {
        public static byte[] ReadFileStream(string fileName)
        {
            
            byte[] arr;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            arr = new byte[fs.Length];
            for (int i = 0; i < fs.Length; i++)
            {
                arr[i] = (byte)fs.ReadByte();
            }
            return arr;
        }
        public static void WriteFileStream(string fileName, long size)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            for (int i = 0; i < size; i++)
            {
                fs.WriteByte(0);
            }
            ///////////////////////// очень важно закончить FS 
            fs.Close();
        }
        public static int[] ReadBinary(string fileName)
        {
            int[] arr;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(fs);
            arr = new int[fs.Length];
            for (int i = 0; i < fs.Length; i++)
            {
                arr[i] = reader.Read();
            }reader.Close();
            return arr;
        }
        public static void WriteBinary(string fileName, long size)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter writer = new BinaryWriter(fs);
            for (int i = 0; i < size; i++)
            {
                writer.Write((byte)0);
            }writer.Close();
        }
        public static string ReadStreamReader(string fileName)
        {
            StringBuilder sb;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs);
            sb = new StringBuilder();
            for (int i = 0; i < fs.Length; i++)
            {
                sb.Append($"{(char)reader.Read()} ");
            }
            reader.Close();
            return sb.ToString();
        }
        public static void WriteStreamWriter(string fileName, long size)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs);
            for (int i = 0; i < size; i++)
            {
                writer.Write(0);
            }writer.Close();
        }
        public static byte[] ReadBufferedSteam(string fileName)
        {
            byte[] arr;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            int countPart = 4;
            int bufSize = (int)fs.Length / countPart;
            arr = new byte[fs.Length];
            BufferedStream reader = new BufferedStream(fs);
            for (int i = 0; i < countPart; i++)
            {
                reader.Read(arr, i * bufSize, bufSize);
            }reader.Close();
            return arr;
        }
        public static void WriteBufferedStream(string fileName, long size)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            int countPart = 4;
            int bufSize = (int)(size / countPart);
            byte[] buffer = new byte[size];
            using (BufferedStream bs = new BufferedStream(fs, bufSize))
            {
                
                for (int i = 0; i < countPart; i++)
                {
                    bs.Write(buffer, 0, bufSize);
                }
                
            }
            fs.Close();           
        }
    }
}