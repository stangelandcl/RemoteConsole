using System;
using System.ServiceModel;

namespace RemoteConsole
{
	public interface IConsole
	{
		void Write(object o);
		void WriteLine();	
		void WriteLine(string format, params object[] args);
		void WriteLine(object o);	
		void SetCursorPosition(int x, int y);
		int CursorTop {  get;}
		int BufferHeight {  get;}
		ConsoleKeyInfo ReadKey(bool intercept);		
		int WindowWidth {  get;}
		void Clear();
		string ReadLine();
	}

	public class ConsoleServiceClient : IConsole{
		public ConsoleServiceClient(IConsoleService service){
			this.c = service;
		}
		IConsoleService c;

		public void Write (object o)
		{
			c.Write(o.ToString());
		}

		public void WriteLine ()
		{
			c.WriteLine("");
		}

		public void WriteLine (string format, params object[] args)
		{
			c.WriteLine(string.Format(format, args));
		}

		public void WriteLine (object o)
		{
			c.WriteLine(o.ToString());
		}

		public void SetCursorPosition (int x, int y)
		{
			c.SetCursorPosition(x, y);
		}

		public ConsoleKeyInfo ReadKey (bool intercept)
		{
			return c.ReadKey(intercept);
		}

		public void Clear ()
		{
			c.Clear();
		}

		public string ReadLine ()
		{
			return c.ReadLine();
		}

		public int CursorTop {
			get {
				return c.CursorTop;
			}
		}

		public int BufferHeight {
			get {
				return c.BufferHeight;
			}
		}

		public int WindowWidth {
			get {
				return c.WindowWidth;
			}
		}


	}

	
	[ServiceContract]
	public interface IConsoleService
	{
		[OperationContract]
		void Write(string s);
		[OperationContract]
		void WriteLine(string format);
		[OperationContract]
		void SetCursorPosition(int x, int y);
		int CursorTop { [OperationContract] get;}
		int BufferHeight { [OperationContract] get;}
		[OperationContract]
		ConsoleKeyInfo ReadKey(bool intercept);		
		int WindowWidth { [OperationContract] get;}
		[OperationContract(IsOneWay=true)]
		void Clear();
		[OperationContract]
		string ReadLine();
	}

	[ServiceContract]
	public interface IConsoleCallback{
		[OperationContract]
		void CancelKeyPress();
	}
}

