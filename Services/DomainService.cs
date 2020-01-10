using DataMapper;
using DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Services
{
    public class DomainService
    {
        private DomainRepository domainRepository;

        public DomainService()
        {
            domainRepository = new DomainRepository();
        }

        private bool IsValidDomain(Domain domain)
        {
            ValidationContext context = new ValidationContext(domain);
            IList<ValidationResult> validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(domain, context, validationResults, true);
        }

        public void AddNewDomain()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Domain> GetAllDomains()
        {
            return domainRepository.Get(
                orderBy: q => q.OrderBy(c => c.Id));
        }

        public IEnumerable<Domain> GetById(int idDomain)
        {
            return domainRepository.Get(
                filter: exp => exp.Id == 1,
                orderBy: q => q.OrderBy(c => c.DomainName),
                includeProperties: "Subdomains, ParentDomain");
        }

        public Domain GetDomain(int idDomain)
        {
            return domainRepository.GetByID(idDomain);
        }

        //public IEnumerable<Domain> GetAllSubdomains(int idDomain)
        //{
        //    return domainRepository.GetSubdomains(idDomain);
        //}
    }
}
