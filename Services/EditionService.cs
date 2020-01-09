using DataMapper;
using DomainModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Services
{
    public class EditionService
    {
        private EditionRepository editionRepository;

        public EditionService()
        {
            editionRepository = new EditionRepository();
        }

        private bool IsValidEdition(Edition edition)
        {
            ValidationContext context = new ValidationContext(edition);
            IList<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(edition, context, validationResults, true);
        }

        public void AddNewEdition(Edition edition)
        {
            editionRepository.Insert(edition);
        }

        public IEnumerable<Edition> GetAllEditions()
        {
            return editionRepository.Get(
                orderBy: q => q.OrderBy(c => c.Publisher),
                includeProperties: "Address");
        }

        public Edition getEdition(int id)
        {
            return editionRepository.GetByID(id);
        }
    }
}
