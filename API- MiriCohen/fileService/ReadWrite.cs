using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace fileService{
    public class ReadWrite<T> : IfileService<T>
    {
        public string filePath {get;set;}
        public ReadWrite()
        {
        this.filePath = Path.Combine(Environment.CurrentDirectory, "File", "readwrite.txt");
        }
        public void Write(T data,string path)
        {
            string str_data=JsonSerializer.Serialize(data);
            if(File.Exists(path))
            {
                File.AppendAllText(path,$"{str_data}\n");
            }
        }
        public List<T> Read(string path)
        {
            string[] str_data;
            List<T> pi=new List<T>();
            if(File.Exists(path))
            {
                str_data=File.ReadAllLines(path);
                for(int i=1;i<str_data.Length;i++)
                {
                    T data=JsonSerializer.Deserialize<T>(str_data[i]);
                    pi.Add(data);
                }
            }
            return pi;
        }
        public void DeleteAll(string path){
            if(File.Exists(path)){
                File.Delete(path);
                File.AppendAllText(path,"\n");
            }
        }
    }
}