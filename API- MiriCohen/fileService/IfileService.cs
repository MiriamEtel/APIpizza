using System.IO;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace fileService{
    public interface IfileService<T>
    {
        void Write(T data,string path);
        List <T> Read(string path);
        void DeleteAll(string path);

    }
}