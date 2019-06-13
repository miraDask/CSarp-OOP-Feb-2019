namespace LoggerLibrary.Layouts
{
    using LoggerLibrary.Layouts.Contracts;
    using System.Text;

    public class XmlLayout : ILayout
    {
        public string Format => GetFormat();

        private string GetFormat()
        {
            StringBuilder resutl = new StringBuilder();
            resutl.AppendLine("<log>");
            resutl.AppendLine("   <date>{0}</date>");
            resutl.AppendLine("   <level>{1}</level>");
            resutl.AppendLine("   <message>{2}</message>");
            resutl.Append("</log>");

            return resutl.ToString();
        }
    }
}
