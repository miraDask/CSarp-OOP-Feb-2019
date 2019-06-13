namespace P07.InfernoInfinity.Core.Contracts
{
    public interface ICommandInterpreter
    {
        IExecutable GetCommand(string[] data);
    }
}
