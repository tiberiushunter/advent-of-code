namespace AdventOfCode.Domain.Interfaces;
public interface ITimerProvider
{
	public void Start();
	public void Stop();
	public double ElapsedTime();
}
