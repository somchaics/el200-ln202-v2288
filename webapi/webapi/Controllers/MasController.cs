using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using webapi.Models;
using Newtonsoft.Json.Serialization;

namespace webapi.Controllers
{
    public class MasController : ApiController
    {
        public string getDivision()
        {
            MASDataContext dc = new MASDataContext(configs.connectString);
            var q = (from p in dc.Divisions
                     select p).ToList();

            return JsonConvert.SerializeObject(q);
        }
        
        [Route("find/{id}/{id2}")] //no action
        [HttpGet]
        public string get(string id, string id2)
        {
            MASDataContext dc = new MASDataContext(configs.connectString);
            var q = (from p in dc.Divisions
                     where p.Division_code == id ||
                     p.Division_name.Contains(id2)
                     select p).ToList();

            return JsonConvert.SerializeObject(q);
        }

        //get id //action
        public string getDivisionName(string id)
        {
            MASDataContext dc = new MASDataContext(configs.connectString);
            var q = (from p in dc.Divisions
                     where p.Division_name.Contains(id)
                     select p).ToList();

            return JsonConvert.SerializeObject(q);
        }

        //get id //action
        public string InsertDivision(cDivision d)
        {
            MASDataContext dc = new MASDataContext(configs.connectString);
            var rec = new Division() // Division คือ table
            {
                Division_code = d.code,
                Division_name = d.name,
                Division_status = d.status
            };
            dc.Divisions.InsertOnSubmit(rec);
            dc.SubmitChanges();
            return "Success";
        }

        public string UpdateDivision(cDivision d)
        {
            MASDataContext dc = new MASDataContext(configs.connectString);
            var oldrec = from p in dc.Divisions
                       where p.Division_code == d.code
                       select p;
            if (oldrec.Count() == 0)
            {
                return "record not found.";
            }

            var rec = oldrec.First();
            rec.Division_name = d.name;
            rec.Division_status = d.status;
         
            dc.SubmitChanges();
            return "Success";
        }


        public string DeleteDivision(string id)
        {
            MASDataContext dc = new MASDataContext(configs.connectString);
            var oldrec = from p in dc.Divisions
                         where p.Division_code == id
                         select p;
            if (oldrec.Count() == 0)
            {
                return "record not found.";
            }

            var rec = oldrec.First();
            dc.Divisions.DeleteOnSubmit(rec);
            dc.SubmitChanges();
            return "Success";
        }

        //
        public string  get_0()
        {
            MASDataContext dc = new MASDataContext(configs.connectString);
           
            return JsonConvert.SerializeObject("ok");
        }
        public string get_1()
        {
            MASDataContext dc = new MASDataContext(configs.connectString);
            var q = from p in dc.Divisions
                     select p;
          
            return JsonConvert.SerializeObject(q);
        }
        public string get_2()
        {
            MASDataContext dc = new MASDataContext(configs.connectString);
            List<Division> data = new List<Division>();
            var q = from p in dc.Divisions
                    select p;
            foreach (var p in q) data.Add(p);
        
            return JsonConvert.SerializeObject(data);
        }
      
    }
}
