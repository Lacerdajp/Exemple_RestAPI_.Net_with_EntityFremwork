

using aula8.Data.VO;

namespace aula8.Services
{
    public interface IPersonServices
    {
        PersonVO Create(PersonVO person);
        PersonVO FindByID(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);
    }
}
