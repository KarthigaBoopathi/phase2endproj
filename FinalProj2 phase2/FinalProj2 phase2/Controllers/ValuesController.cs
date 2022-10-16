using bal;
using dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinalProj2_phase2.Models;

namespace FinalProj2_phase2.Controllers
{
    public class ValuesController : ApiController
    {
       

        // GET api/<controller>
        DAL obj = null;
        public ValuesController()
        {
            obj = new DAL();
        }

        //[Route("GetAllEmps")]
        [HttpGet]
        public List<EmpModels> Get()
        {
            //return new string[] { "value1", "value2" };

            List<EmpProfiles> empbal = new List<EmpProfiles>(); empbal = obj.GetCustomers();
            List<EmpModels> emps = new List<EmpModels>();
            foreach (var item in empbal)
            {
                //Employees emp = new Employees();
                emps.Add(new EmpModels
                {
                    EmpCode = item.EmpCode,
                    Email = item.Email,
                    EmpName = item.EmpName,
                    DeptCode = item.DeptCode
                });
            }
            return emps;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] EmpModels empdata)
        {
            EmpProfiles empbal = new EmpProfiles();
            empbal.EmpCode = empdata.EmpCode;
            empbal.Email = empdata.Email;
            empbal.EmpName = empdata.EmpName;
            empbal.DeptCode = empdata.DeptCode;
            obj.Insertcustomer(empbal);
        }
        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody] EmpModels empdata)
        {
            EmpProfiles empbal = new EmpProfiles();
            empbal.EmpCode = empdata.EmpCode;
            empbal.Email = empdata.Email;
            empbal.EmpName = empdata.EmpName;
            empbal.DeptCode = empdata.DeptCode;
            obj.UpdateCustomer(empbal);

        }
        // DELETE api/values/5
        public void Delete(int id)
        {
            obj.Remove(id);
        }
    }
}