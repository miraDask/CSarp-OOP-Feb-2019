namespace StorageMaster.Core.IO
{
    using Contracts;
    using System;

    public class ConsoleWriter : IWriter
	{
		public void WriteLine(string message)
		{
			Console.WriteLine(message);
		}
	}
}