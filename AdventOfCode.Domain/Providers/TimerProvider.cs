using AdventOfCode.Domain.Interfaces;
using System.Diagnostics;

namespace AdventOfCode.Domain.Providers;

public class TimerProvider : ITimerProvider
{
	private Stopwatch _timer;

	public TimerProvider()
	{
		_timer = new Stopwatch();
	}

	public void Start()
	{
		_timer.Restart();
	}

	public void Stop()
	{
		_timer.Stop();
	}

	public double ElapsedTime()
	{
		return _timer.Elapsed.TotalMilliseconds;
	}
}
