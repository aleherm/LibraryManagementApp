using DataMapper;
using DomainModel;
using System;
using System.Data.Entity.Validation;

namespace LibraryManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Edition edition = new Edition
            {
                PageNumber = 150,
                Year = 2016,
                BookType = EBookType.EPaperBack,
                Publisher = "Humanitas",
                NoTotal = 2,
                NoForLibrary = 1,
                NoForLoan = 1
            };

            try
            {
                IEditionRepository editionRepo = new EditionRepository();
                editionRepo.Insert(edition);
                
                var items = editionRepo.Get();

                foreach (var item in items)
                {
                    Console.WriteLine(item.Publisher);
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
