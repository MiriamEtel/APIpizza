using System.IO;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace fileService{
    public interface IfileService<T>
    {
        string FileName {get;set;}
        void WriteMessage(string message);
        void Write<T>(T data);
        void WriteLog(string m);
        List<T> Read<T>();
        void DeleteAll<T>();
        void Update<T>(List<T> list);

    }
}