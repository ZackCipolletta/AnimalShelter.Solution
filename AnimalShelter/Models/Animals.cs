using System.Collections.Generic;

namespace AnimalShelter.Models
{
  public class Animal
  { //Type, Name, Date of Admittance, Breed
    public int AnimalId { get; set; }
    public string Type { get; set; }
    public string Breed { get; set; }
    public string Name { get; set; }
    public DateTime DateOfAdmittance { get; set; }

  }
}