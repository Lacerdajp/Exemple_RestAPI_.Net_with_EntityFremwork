using Microsoft.AspNetCore.Mvc.Filters;

namespace aula8.Hypermedia.Abstract
{
    public interface IResposnseEnricher
    {
        bool CanEnrich(ResultExecutingContext context);
        Task Enrich(ResultExecutingContext context);
    }
}
