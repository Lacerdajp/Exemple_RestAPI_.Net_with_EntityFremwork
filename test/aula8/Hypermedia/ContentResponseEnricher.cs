using aula8.Hypermedia.Abstract;
using aula8.Hypermedia.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Collections.Concurrent;

namespace aula8.Hypermedia
{
    public abstract class ContentResponseEnricher<T> : IResposnseEnricher where T : ISupportHyperMedia
    {
        public ContentResponseEnricher()
        {

        }
        public virtual  bool CanEnrich(Type ContentType)
        {
            return ContentType == typeof(T) || ContentType == typeof(List<T>) || ContentType == typeof(PagedSearchVO<T>);
        }
        protected abstract Task EnrichModel(T content, IUrlHelper urlHelper);
        

        bool IResposnseEnricher.CanEnrich(ResultExecutingContext context)
        {
            if (context.Result is OkObjectResult okObjectResult)
            {
                return CanEnrich(okObjectResult.Value.GetType());
            }
            return false;
        }
        public async Task Enrich(ResultExecutingContext context)
        {
            var urlHelper = new UrlHelperFactory().GetUrlHelper(context);
            if (context.Result is OkObjectResult okObjectResult)
            {
                if (okObjectResult.Value is T model)
                {
                    await EnrichModel(model, urlHelper);
                }

                else if (okObjectResult.Value is List<T> collection)
                {
                    ConcurrentBag<T> bag = new ConcurrentBag<T>(collection);
                    Parallel.ForEach(bag, (element) =>
                    {
                        EnrichModel(element, urlHelper);
                    });
                }
                //else if (okObjectResult.Value is PagedSearchVO<T> pagedSearch)
                //{
                //    Parallel.ForEach(pagedSearch.List.ToList(), (element) =>
                //    {
                //        EnrichModel(element, urlHelper);
                //    });
                //}
                await Task.FromResult<object>(null);
            }
        }

      
    }
}
