using DataMapper;
using DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Services
{
    public class DomainService : IDomainService
    {
        private DomainRepository domainRepository;

        public DomainService()
        {
            domainRepository = new DomainRepository();
        }

        public bool IsValidDomain(Domain domain)
        {
            ValidationContext context = new ValidationContext(domain);
            IList<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(domain, context, validationResults, true);
        }

        public bool AddNewDomain(Domain domain)
        {
            if(IsValidDomain(domain))
            {
                domainRepository.Insert(domain);
                return true;
            }
            return false;
        }

        public IEnumerable<Domain> GetAllDomains()
        {
            return domainRepository.Get(
                orderBy: q => q.OrderBy(c => c.Id));
        }

        public Domain GetDomainById(int idDomain)
        {
            return domainRepository.GetByID(idDomain);
        }

        //public IEnumerable<Domain> GetAllSubdomains(int idDomain)
        //{
        //    return domainRepository.GetSubdomains(idDomain);
        //}
    }
}
