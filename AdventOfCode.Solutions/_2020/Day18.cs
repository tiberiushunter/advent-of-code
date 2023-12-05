using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Solutions.Helpers;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions._2020;

public class Day18 : IDay
{
	public string Title => "Operation Order";

	public string PartA(string input)
	{
		var parsedInput = InputHelper.ToStringArray(input);

		double finalSum = 0d;
		for (int i = 0; i < parsedInput.Length; i++)
		{
			string line = Regex.Replace(parsedInput[i], @"\s+", "");

			var values = new Stack<double>();
			var operands = new Stack<char>();

			operands.Push(Token.LeftBracket);

			for (int j = 0; j < line.Length; j++)
			{
				switch (line[j])
				{
					case Token.Addition:
						(operands, values) = Calculate(operands, values);
						operands.Push(Token.Addition);
						break;
					case Token.Multiply:
						(operands, values) = Calculate(operands, values);
						operands.Push(Token.Multiply);
						break;
					case Token.LeftBracket:
						operands.Push(Token.LeftBracket);
						break;
					case Token.RightBracket:
						(operands, values) = Calculate(operands, values);
						operands.Pop();
						break;
					default:
						values.Push(char.GetNumericValue(line[j]));
						break;
				}
			}
			(_, values) = Calculate(operands, values);
			finalSum += values.Single();
		}

		return finalSum.ToString();
	}

	public string PartB(string input)
	{
		var parsedInput = InputHelper.ToStringArray(input);

		double finalSum = 0d;
		for (int i = 0; i < parsedInput.Length; i++)
		{
			string line = Regex.Replace(parsedInput[i], @"\s+", "");

			var values = new Stack<double>();
			var operands = new Stack<char>();

			operands.Push(Token.LeftBracket);

			for (int j = 0; j < line.Length; j++)
			{
				switch (line[j])
				{
					case Token.Addition:
						(operands, values) = Calculate(operands, values, Token.Addition);
						operands.Push(Token.Addition);
						break;
					case Token.Multiply:
						(operands, values) = Calculate(operands, values);
						operands.Push(Token.Multiply);
						break;
					case Token.LeftBracket:
						operands.Push(Token.LeftBracket);
						break;
					case Token.RightBracket:
						(operands, values) = Calculate(operands, values);
						operands.Pop();
						break;
					default:
						values.Push(char.GetNumericValue(line[j]));
						break;
				}
			}
			(_, values) = Calculate(operands, values);
			finalSum += values.Single();
		}

		return finalSum.ToString();
	}

	private static (Stack<char> operands, Stack<double> values) Calculate(Stack<char> operands, Stack<double> values, char? precedence = Token.Multiply)
	{
		while (operands.Peek() != Token.LeftBracket && (precedence == Token.Multiply || operands.Peek() != Token.Multiply))
		{
			switch (operands.Pop())
			{
				case Token.Addition:
					values.Push(values.Pop() + values.Pop());
					break;
				case Token.Multiply:
					values.Push(values.Pop() * values.Pop());
					break;
			}
		}

		return (operands, values);
	}

	internal sealed class Token
	{
		public const char Addition = '+';
		public const char Multiply = '*';
		public const char LeftBracket = '(';
		public const char RightBracket = ')';
	}
}
