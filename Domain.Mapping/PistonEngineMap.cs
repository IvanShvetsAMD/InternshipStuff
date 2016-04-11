namespace Domain.Mapping
{
    public class PistonEngineMap : EntityMap<PistonEngine>
    {
        public PistonEngineMap()
        {
            Map(x => x.Mixture).Not.Nullable();
            Map(x => x.NumberOfPistons).Not.Nullable();
            Map(x => x.Volume).Not.Nullable();
        }
    }
}