using DataMapper;
using DomainModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Services
{
    public class EditionService : IEditionService
    {
        private EditionRepository editionRepository;

        public EditionService()
        {
            editionRepository = new EditionRepository();
        }

        public bool IsValidEdition(Edition edition)
        {
            ValidationContext context = new ValidationContext(edition);
            IList<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(edition, context, validationResults, true);
        }

        public bool AddNewEdition(Edition edition)
        {
            if(IsValidEdition(edition))
            {
                editionRepository.Insert(edition);
                return true;
            }
            return false;
        }

        public IEnumerable<Edition> GetAllEditions()
        {
            return editionRepository.Get(
                orderBy: q => q.OrderBy(c => c.Publisher),
                includeProperties: "Address");
        }

        public Edition GetEditionById(int idEdition)
        {
            return editionRepository.GetByID(idEdition);
        }
    }
}
