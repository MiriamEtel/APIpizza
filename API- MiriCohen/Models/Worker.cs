using System;
using System.Collections.Generic;

namespace Models
{
    public class Worker
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Password {get;set;}
        public string Role {get;set;}

        public Worker(){
            this.Id=0;
            this.Name="";
            this.Password="";
            this.Role="";
        }

        public Worker(int id,string name,string password,string role){
            this.Id=id;
            this.Name=name;
            this.Password=password;
            this.Role=role;
        }

    }
}