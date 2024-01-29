using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
   public class Pizza
  {
    [StringLength(13)]
    public string? Name { get; set; }
    [Required]
    public bool Gluten { get; set; }
    public int Id { get; set; }
    [Range(0,400)]
    public int Price {get;set;}

    public Pizza(){
      this.Id=0;
      this.Name="";
      this.Gluten=true;
      this.Price=40;
      
    }
    
    public Pizza(int id,string name,bool gluten, int price){
      this.Id=id;
      this.Name=name;
      this.Gluten=gluten;
      this.Price=price;
      
    }

  }
}