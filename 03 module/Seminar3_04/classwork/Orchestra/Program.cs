using System;

namespace Orchestra
{
	class PlayIsStartedEventArgs : EventArgs
	{
		public int Song { get; set; }
	}
	class Bandmaster
	{
		static Random rnd = new Random();
		public event EventHandler<PlayIsStartedEventArgs> PlayIsStartedEvent;
		public void StartPlay(int song)
			=> PlayIsStartedEvent?.Invoke(this, new PlayIsStartedEventArgs { Song = song });
	}
	abstract class OrchestraPlayer
	{
		static Random rnd = new Random();
		public OrchestraPlayer() => Name = rnd.Next(999).ToString();
		public abstract void PlayIsStartedEventHandler(object sender, PlayIsStartedEventArgs args);

		public string Name { get; private set; }
	}
	class Violinist : OrchestraPlayer
	{
		public override void PlayIsStartedEventHandler(object sender, PlayIsStartedEventArgs args)
			=> Console.WriteLine($"Violinist {Name} plays composition #{args.Song}: La-la!");
	}
	class Hornist : OrchestraPlayer
	{
		public override void PlayIsStartedEventHandler(object sender, PlayIsStartedEventArgs args)
			=> Console.WriteLine($"Hornist {Name} starts playing composition #{args.Song}: Du-du-du!");
	}
	class Program
	{
		static void Main()
		{
			Random rnd = new Random();
			Bandmaster master = new Bandmaster();
			OrchestraPlayer[] orc = new OrchestraPlayer[10];
			for (int i = 0; i < orc.Length; i++)
			{
				if (rnd.Next(2) == 0)
					orc[i] = new Violinist();
				else
					orc[i] = new Hornist();
				master.PlayIsStartedEvent += orc[i].PlayIsStartedEventHandler;
			}
			for (int i = 0; i < 3; i++)
			{
				master.StartPlay(rnd.Next(2, 6));
				Console.WriteLine();
			}
		}
	}
}
