using aula8.Hypermedia.Abstract;

namespace aula8.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResposnseEnricher> ContentResponseEnricherList { get; set; }=
            new List<IResposnseEnricher>();
    }
}
