using System;

namespace SpaceForce.Desktop {
	public static class Program {
		[STAThread]
		static void Main() {
			using (var game = new SpaceForceGame())
				game.Run();
		}
	}
}
