using System;

namespace WebApi.Models
{
  public class Fighter
  {
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Fighter(string firstName, string lastName)
    {
      this.FirstName = firstName;
      this.LastName = lastName;
    }
  }
}