using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Solutions.Helpers;

namespace AdventOfCode.Solutions._2020;

public class Day17 : IDay
{
	public string Title => "Conway Cubes";

	public string PartA(string input)
	{
		var simulation = Initialise3D(InputHelper.ToStringArray(input));

		int i = 1;
		while (i <= 6)
		{
			Simulate3D(simulation);
			i++;
		}

		int count = 0;
		for (int z = 0; z < simulation.Count; z++)
		{
			for (int y = 0; y < simulation[z].Count; y++)
			{
				for (int x = 0; x < simulation[z][y].Count; x++)
				{
					count += simulation[z][y][x];
				}
			}
		}

		return count.ToString();
	}

	public string PartB(string input)
	{
		var simulation = Initialise4D(InputHelper.ToStringArray(input));

		int i = 1;
		while (i <= 6)
		{
			Simulate4D(simulation);
			i++;
		}

		int count = 0;
		for (int w = 0; w < simulation.Count; w++)
		{
			for (int z = 0; z < simulation[w].Count; z++)
			{
				for (int y = 0; y < simulation[w][z].Count; y++)
				{
					for (int x = 0; x < simulation[w][z][y].Count; x++)
					{
						count += simulation[w][z][y][x];
					}
				}
			}
		}

		return count.ToString();
	}

	private static List<List<List<int>>> Initialise3D(string[] input)
	{
		var simulation3D = new List<List<List<int>>>();
		var currentZ = new List<List<int>>();

		for (int i = 0; i < input.Length; i++)
		{
			List<int> currentY = new List<int>();
			for (int j = 0; j < input[i].Length; j++)
			{
				switch (input[i][j])
				{
					case '.':
						currentY.Add(Cube.Inactive);
						break;
					case '#':
						currentY.Add(Cube.Active);
						break;
				}
			}
			currentZ.Add(currentY);
		}

		simulation3D.Add(currentZ);

		return simulation3D;
	}

	private static List<List<List<List<int>>>> Initialise4D(string[] input)
	{
		var simulation4D = new List<List<List<List<int>>>>();
		var currentState = new List<List<List<int>>>();

		var currentZ = new List<List<int>>();
		for (int i = 0; i < input.Length; i++)
		{
			var currentY = new List<int>();
			for (int j = 0; j < input[i].Length; j++)
			{
				switch (input[i][j])
				{
					case '.':
						currentY.Add(Cube.Inactive);
						break;
					case '#':
						currentY.Add(Cube.Active);
						break;
				}
			}
			currentZ.Add(currentY);
		}
		currentState.Add(currentZ);
		simulation4D.Add(currentState);

		return simulation4D;
	}

	private void Simulate3D(List<List<List<int>>> simulation)
	{
		for (int z = 0; z < simulation.Count; z++)
		{
			for (int y = 0; y < simulation[z].Count; y++)
			{
				simulation[z][y].Insert(0, Cube.Inactive);
				simulation[z][y].Add(Cube.Inactive);
			}
			simulation[z].Insert(0, simulation[z].First().Select(x => { x = Cube.Inactive; return x; }).ToList());
			simulation[z].Add(simulation[z].First().Select(x => { x = Cube.Inactive; return x; }).ToList());
		}

		var newFirstZ = new List<List<int>>();
		var newLastZ = new List<List<int>>();

		foreach (var y in simulation.First())
		{
			newFirstZ.Add(y.Select(x => { x = Cube.Inactive; return x; }).ToList());
			newLastZ.Add(y.Select(x => { x = Cube.Inactive; return x; }).ToList());
		}

		simulation.Insert(0, newFirstZ);
		simulation.Add(newLastZ);

		for (int z = 0; z < simulation.Count; z++)
		{
			for (int y = 0; y < simulation[z].Count; y++)
			{
				for (int x = 0; x < simulation[z][y].Count; x++)
				{
					int count = 0;

					for (int i = -1; i <= 1; i++)
					{
						for (int j = -1; j <= 1; j++)
						{
							for (int k = -1; k <= 1; k++)
							{
								int dz = z + i;
								int dy = y + j;
								int dx = x + k;

								if (!CoordsInBounds3D(dx, dy, dz, simulation) || (dx == x && dy == y && dz == z))
								{
									continue;
								}

								if (simulation[z][y][x] == Cube.Inactive)
								{
									count += simulation[dz][dy][dx] == Cube.Active || simulation[dz][dy][dx] == Cube.NextInactive ? 1 : 0;
								}
								else if (simulation[z][y][x] == Cube.Active)
								{
									count += simulation[dz][dy][dx] == Cube.Active || simulation[dz][dy][dx] == Cube.NextInactive ? 1 : 0;
								}
							}
						}
					}
					if (simulation[z][y][x] == Cube.Inactive && (count == 3))
					{
						simulation[z][y][x] = Cube.NextActive;
					}
					else if (simulation[z][y][x] == Cube.Active && ((count != 2) && (count != 3)))
					{
						simulation[z][y][x] = Cube.NextInactive;
					}
				}
			}
		}

		for (int z = 0; z < simulation.Count; z++)
		{
			for (int y = 0; y < simulation[z].Count; y++)
			{
				for (int x = 0; x < simulation[z][y].Count; x++)
				{
					switch (simulation[z][y][x])
					{
						case Cube.NextInactive:
							simulation[z][y][x] = Cube.Inactive;
							break;
						case Cube.NextActive:
							simulation[z][y][x] = Cube.Active;
							break;
						default:
							break;
					}
				}
			}
		}
	}

	private void Simulate4D(List<List<List<List<int>>>> simulation)
	{
		for (int w = 0; w < simulation.Count; w++)
		{
			for (int z = 0; z < simulation[w].Count; z++)
			{
				for (int y = 0; y < simulation[w][z].Count; y++)
				{
					simulation[w][z][y].Insert(0, Cube.Inactive);
					simulation[w][z][y].Add(Cube.Inactive);
				}
				simulation[w][z].Insert(0, simulation[w][z].First().Select(x => { x = Cube.Inactive; return x; }).ToList());
				simulation[w][z].Add(simulation[w][z].First().Select(x => { x = Cube.Inactive; return x; }).ToList());
			}

			var newFirstZ = new List<List<int>>();
			var newLastZ = new List<List<int>>();

			foreach (var slice in simulation[w].First())
			{
				newFirstZ.Add(slice.Select(x => { x = Cube.Inactive; return x; }).ToList());
				newLastZ.Add(slice.Select(x => { x = Cube.Inactive; return x; }).ToList());
			}

			simulation[w].Insert(0, newFirstZ);
			simulation[w].Add(newLastZ);
		}

		var newFirstW = new List<List<List<int>>>();
		var newLastW = new List<List<List<int>>>();

		foreach (var w in simulation.First())
		{
			var newFirstZ = new List<List<int>>();
			var newLastZ = new List<List<int>>();

			foreach (var z in w)
			{
				newFirstZ.Add(z.Select(x => { x = Cube.Inactive; return x; }).ToList());
				newLastZ.Add(z.Select(x => { x = Cube.Inactive; return x; }).ToList());
			}
			newFirstW.Add(newFirstZ);
			newLastW.Add(newLastZ);
		}

		simulation.Insert(0, newFirstW);
		simulation.Add(newLastW);

		for (int w = 0; w < simulation.Count; w++)
		{
			for (int z = 0; z < simulation[w].Count; z++)
			{
				for (int y = 0; y < simulation[w][z].Count; y++)
				{
					for (int x = 0; x < simulation[w][z][y].Count; x++)
					{
						int count = 0;

						for (int i = -1; i <= 1; i++)
						{
							for (int j = -1; j <= 1; j++)
							{
								for (int k = -1; k <= 1; k++)
								{
									for (int l = -1; l <= 1; l++)
									{
										int dw = w + i;
										int dz = z + j;
										int dy = y + k;
										int dx = x + l;

										if (!CoordsInBounds4D(dx, dy, dz, dw, simulation) || (dx == x && dy == y && dz == z && dw == w))
										{
											continue;
										}

										if (simulation[w][z][y][x] == Cube.Inactive)
										{
											count += simulation[dw][dz][dy][dx] == Cube.Active || simulation[dw][dz][dy][dx] == Cube.NextInactive ? 1 : 0;
										}
										else if (simulation[w][z][y][x] == Cube.Active)
										{
											count += simulation[dw][dz][dy][dx] == Cube.Active || simulation[dw][dz][dy][dx] == Cube.NextInactive ? 1 : 0;
										}
									}
								}
							}
						}
						if (simulation[w][z][y][x] == Cube.Inactive && (count == 3))
						{
							simulation[w][z][y][x] = Cube.NextActive;
						}
						else if (simulation[w][z][y][x] == Cube.Active && ((count != 2) && (count != 3)))
						{
							simulation[w][z][y][x] = Cube.NextInactive;
						}
					}
				}
			}
		}

		for (int w = 0; w < simulation.Count; w++)
		{
			for (int z = 0; z < simulation[w].Count; z++)
			{
				for (int y = 0; y < simulation[w][z].Count; y++)
				{
					for (int x = 0; x < simulation[w][z][y].Count; x++)
					{
						switch (simulation[w][z][y][x])
						{
							case Cube.NextInactive:
								simulation[w][z][y][x] = Cube.Inactive;
								break;
							case Cube.NextActive:
								simulation[w][z][y][x] = Cube.Active;
								break;
							default:
								break;
						}
					}
				}
			}
		}
	}

	private static bool CoordsInBounds3D(int x, int y, int z, List<List<List<int>>> grid)
	{
		if (x >= 0 && y >= 0 && z >= 0 && z < grid.Count && y < grid[z].Count && x < grid[z][y].Count)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	private static bool CoordsInBounds4D(int x, int y, int z, int w, List<List<List<List<int>>>> grid)
	{
		if (x >= 0 && y >= 0 && z >= 0 && w >= 0 && w < grid.Count && z < grid[w].Count && y < grid[w][z].Count && x < grid[w][z][y].Count)
		{
			return true;
		}
		else
		{
			return false;
		}
	}

	internal sealed class Cube
	{
		public const int Inactive = 0;
		public const int Active = 1;
		public const int NextInactive = 2;
		public const int NextActive = 3;
	}
}
