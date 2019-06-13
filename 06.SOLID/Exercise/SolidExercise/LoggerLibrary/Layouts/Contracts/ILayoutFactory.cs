namespace LoggerLibrary.Layouts.Contracts
{
    public interface ILayoutFactory
    {
        ILayout CraeteLayout(string layoutType);
    }
}
