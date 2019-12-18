using DataMapper;
using DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;

namespace LibraryManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Edition edition = new Edition
            {
                Id = 1,
                PageNumber = 10,
                Year = 2019,
                BookType = EBookType.EHardCover,
                Publisher = "Al",
                NoTotal = 10,
                NoForLibrary = 2,
                NoForLoan = 8
            };
            
            try
            {
                using (var ctx = new LibraryDBContext())
                {
                    ctx.Editions.Add(edition);
                    ctx.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
            }
        }
    }
}
