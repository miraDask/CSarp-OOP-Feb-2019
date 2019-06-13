namespace P07.InfernoInfinity.Models.Contracts
{
    public interface IGemFactory
    {
        IGem CreateGem(string gemType, Clarity clarity);
    }
}
