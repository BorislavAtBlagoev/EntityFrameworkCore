using CodeFirst.Data;
using CodeFirst.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CodeFirst.ConsoleApp
{
    public class StartUp
    {
        public static void Main()
        {
            using (var db = new HospitalContext())
            {
                var medicament = new Medicament
                {
                    Name = "Gosho"
                };


                db.Medicaments.Add(medicament);
                db.SaveChanges();
            }
        }
    }
}
