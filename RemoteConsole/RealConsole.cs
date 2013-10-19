using System;
using System.IO;
using System.ServiceModel;

namespace RemoteConsole
{	
	//[CallbackBehavior(UseSynchronizationContext=false)]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, 
	                 ConcurrencyMode = ConcurrencyMode.Reentrant)]
	public class RealConsole : IConsole, IConsoleService{
		public void Write(object o){ Console.Write(o);}
		public void WriteLine(object ob) {Console.WriteLine(ob);}
		public void WriteLine(){Console.WriteLine();}
		public void WriteLine(string format, params object[] args){
			Console.WriteLine(format, args);
		}
		public void SetCursorPosition(int x, int y){
			Console.SetCursorPosition(x, y);
		}
		public int CursorTop{get{return Console.CursorTop;}}
		public int BufferHeight {get {return Console.BufferHeight;}}
		public ConsoleKeyInfo ReadKey(bool intercept){
			return Console.ReadKey(intercept);
		}
		public int WindowWidth{get{
				return Console.WindowWidth;}}
		public void Clear(){Console.Clear();}
	
		public string ReadLine(){
			return Console.ReadLine();
		}			

		#region IConsoleService implementation

		public void Write (string s)
		{
			this.Write((object)s);
		}

		public void WriteLine (string format)
		{
			this.WriteLine(format, new object[0]);
		}

		#endregion
	}
	[CallbackBehavior(UseSynchronizationContext=false)]
	[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple,
	                 InstanceContextMode = InstanceContextMode.PerSession)]
	 public class RealConsoleCallback : IConsoleCallback{
		public void CancelKeyPress(){
			if(CancelKeyPressEvent != null)
				CancelKeyPressEvent(this,null);
		}

		public event ConsoleCancelEventHandler CancelKeyPressEvent;
	}
}

