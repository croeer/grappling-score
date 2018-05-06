using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FightersController :ControllerBase
  {
    private readonly FighterContext fighterContext;

    public FightersController(FighterContext fighterContext)
    {
      this.fighterContext = fighterContext;

      if (this.fighterContext.Fighters.Count() == 0)
      {
        this.fighterContext.Fighters.AddRange(
          new Fighter("Marcelo", "Garcia"),
          new Fighter("Roger", "Gracie"),
          new Fighter("Oli", "Geddes")
        );
        this.fighterContext.SaveChanges();
      }
    }

    [HttpGet]
    public ActionResult<IEnumerable<Fighter>> GetAll()
    {
      return this.fighterContext.Fighters;
    }

    [HttpGet("{id}")]
    public ActionResult<Fighter> GetById(long id)
    {
      var fighter = this.fighterContext.Fighters.Find(id);

      if (fighter == null) return NotFound();
      return fighter;
    }
  }
}