using aula8.Models.Context;
using aula8.Models;
using aula8.Repositorys;
using aula8.Data.Converter.Implementatations;
using aula8.Data.VO;
using aula8.Hypermedia.Utils;

namespace aula8.Services.Implementations
{
    public class PersonServiceImplementation:IPersonServices
    {
        private readonly IPersonRepository _repository;
        private readonly PersonConverter _converter;

        public PersonServiceImplementation(IPersonRepository repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
           var personEntity = _converter.Parse(person) ;
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public PersonVO Disable(long id)
        {
           var personEntity=_repository.Disable(id);
            return _converter.Parse(personEntity);
        }

        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public PersonVO FindByID(long id)
        {
            return _converter.Parse( _repository.FindByID(id));
        }

        public List<PersonVO> FindByName(string firstName, string secondName)
        {
            return _converter.Parse(_repository.FindByName(firstName, secondName));
        }

        public PagedSearchVO<PersonVO> FindWithPagedSearch(
            string name, string sortDirection, int pageSize, int page)
        {
            var offset =page>0?(pageSize-1) * pageSize: 0;
            var sort=(!string.IsNullOrWhiteSpace(sortDirection))&& !sortDirection.Equals("desc")?"asc":"desc";
            var size = (pageSize < 1) ? 1 : pageSize;
            string query = @"";
            
            return new PagedSearchVO<PersonVO> { };
        }

        public PersonVO Update(PersonVO person)
        {

            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }
    }
}
