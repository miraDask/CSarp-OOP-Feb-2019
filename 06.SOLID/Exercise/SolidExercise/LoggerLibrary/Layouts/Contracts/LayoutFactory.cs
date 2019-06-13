namespace LoggerLibrary.Layouts.Contracts
{
    using System;

    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CraeteLayout(string layoutType)
        {
            string layoutTypeToLowerCase = layoutType.ToLower();

            switch (layoutTypeToLowerCase)
            {
                case "simplelayout":
                    return new SimpleLayout();

                case "xmllayout":
                    return new XmlLayout();

                default:
                    throw new ArgumentException("Invalid layout tipe");
            }
        }
    }
}
