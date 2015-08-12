using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Searcher.Models
{
   public class Person
   {
      public int ID { get; set; }
      [Required]
      [Display(Name = "Last Name")]
      public string lastName { get; set; }
      [Required]
      [Display(Name = "First Name")]
      public string firstName { get; set; }
      [Display(Name = "Street Address")]
      public string address { get; set; }
      [Display(Name = "City")]
      public string city { get; set; }
      [Display(Name = "State")]
      public string state {  get; set; }
      [Required]
      [Display(Name = "Country")]
      public string country { get; set; }
      [Display(Name = "Age")]
      public int age { get; set; }
      [Display(Name = "Interests")]
      public string interests { get; set; }
      [Display(Name = "Photo")]
      public byte[] Image { get; set; }
   }
   public class PersonDBContext : DbContext
   {
      public DbSet<Person> People { get; set; }
   }
}