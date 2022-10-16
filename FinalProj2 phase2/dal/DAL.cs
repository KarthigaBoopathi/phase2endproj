using bal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace dal
{
    public class MyContext : DbContext
    {
        public MyContext() : base("Database")
        {


            Database.SetInitializer<MyContext>(new CreateDatabaseIfNotExists<MyContext>());
        }

        public virtual DbSet<EmpProfiles> emptable { get; set; }


    }

    public class DAL
    {
        public List<EmpProfiles> GetCustomers()
        {
            MyContext context = new MyContext();

            List<EmpProfiles> clist = context.emptable.ToList();
            List<EmpProfiles> cblists = new List<EmpProfiles>();
            foreach (var item in clist)
            {
                cblists.Add(new EmpProfiles
                {
                    EmpCode = item.EmpCode,
                    EmpName = item.EmpName,
                    Email = item.Email,
                    DeptCode = item.EmpCode
                });
            }
            return cblists;
        }
        public void Insertcustomer(EmpProfiles bal)
        {
            MyContext context = new MyContext();
            EmpProfiles c = new EmpProfiles();
            c.EmpCode = bal.EmpCode;
            c.EmpName = bal.EmpName;
            c.Email = bal.Email;
            c.DeptCode = bal.DeptCode;
            context.emptable.Add(c);
            context.SaveChanges();
        }
        public void UpdateCustomer(EmpProfiles bal)
        {
            MyContext context = new MyContext();
            List<EmpProfiles> customers = context.emptable.ToList();
            EmpProfiles obj
                = customers.Find(cust => cust.EmpCode == bal.EmpCode);
            obj.EmpCode = bal.EmpCode;
            obj.EmpName = bal.EmpName;
            obj.Email = bal.Email;
            obj.DeptCode = bal.DeptCode;
            context.SaveChanges();
        }
        public void Remove(int id)
        {
            MyContext context = new MyContext();
            var ans = context.emptable.ToList().Find(temp => temp.EmpCode == id);
            context.emptable.Remove(ans);
            context.SaveChanges();
        }
    }
}
