using ApiService.Context;
using ApiService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneradorController : Controller
    {
        private readonly AppDbContext context;
        public GeneradorController(AppDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Empleo.ToList());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{idempleo}", Name  = "GetEmpleo")]
        public ActionResult Get(int idempleo)
        {
            try
            {
                var gestor = context.Empleo.FirstOrDefault(g => g.idempleo == idempleo);
                return Ok(gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody]GestoresBD gestor)
        {
            try
            {
                context.Empleo.Add(gestor);
                context.SaveChanges();
                return CreatedAtRoute("GetEmpleo", new {idempleo = gestor.idempleo }, gestor);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{idempleo}")]
        public ActionResult Put(int idempleo, [FromBody] GestoresBD gestor)
        {
            try
            {
                if (gestor.idempleo == idempleo)
                {
                    context.Entry(gestor).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetEmpleo", new { idempleo = gestor.idempleo }, gestor);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{idempleo}")]
        public ActionResult Delete (int idempleo)
        {
            try
            {
                var gestor = context.Empleo.FirstOrDefault(g => g.idempleo == idempleo);
                if(gestor != null)
                {
                    context.Empleo.Remove(gestor);
                    context.SaveChanges();
                    return Ok(idempleo);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
