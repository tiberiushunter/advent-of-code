using AdventOfCode.Domain.Interfaces;
using AdventOfCode.Solutions.Helpers;
using AdventOfCode.Solutions.Models;

namespace AdventOfCode.Solutions._2023;

public class Day7 : IDay
{
	public string Title => "Camel Cards";

	public string PartA(string input)
	{
		var sets = InputHelper.ToStringArray(input);

		List<Hand> hands = sets
			.Select(set => set.Split(' '))
			.Select(hand => new Hand(
				int.Parse(hand[1]),
				hand[0].Select(card => CharCardToPlayingCard(card)).ToList())).ToList();

		List<Hand>[] handTypes = [[], [], [], [], [], [], []];

		foreach (var hand in hands)
		{
			if (FiveOfAKind(hand.Cards)) { handTypes.ElementAt(0).Add(hand); continue; }
			if (FourOfAKind(hand.Cards)) { handTypes.ElementAt(1).Add(hand); continue; }
			if (FullHouse(hand.Cards)) { handTypes.ElementAt(2).Add(hand); continue; }
			if (ThreeOfAKind(hand.Cards)) { handTypes.ElementAt(3).Add(hand); continue; }
			if (TwoPair(hand.Cards)) { handTypes.ElementAt(4).Add(hand); continue; }
			if (OnePair(hand.Cards)) { handTypes.ElementAt(5).Add(hand); continue; }
			if (HighCard(hand.Cards)) { handTypes.ElementAt(6).Add(hand); continue; }
		}

		var rankedHands = RankHandsByTypes(handTypes);

		long totalWinnings = CalculateWinnings(rankedHands);

		return totalWinnings.ToString();
	}

	public string PartB(string input)
	{
		var sets = InputHelper.ToStringArray(input);

		List<Hand> hands = sets
			.Select(set => set.Split(' '))
			.Select(hand => new Hand(
				int.Parse(hand[1]),
				hand[0].Select(card => CharCardToPlayingCardJokerWildCards(card)).ToList())).ToList();

		List<Hand>[] handTypes = [[], [], [], [], [], [], []];

		foreach (var hand in hands)
		{
			if (FiveOfAKindWithWildcards(hand.Cards)) { handTypes.ElementAt(0).Add(hand); continue; }
			if (FourOfAKindWithWildcards(hand.Cards)) { handTypes.ElementAt(1).Add(hand); continue; }
			if (FullHouseWithWildcards(hand.Cards)) { handTypes.ElementAt(2).Add(hand); continue; }
			if (ThreeOfAKindWithWildcards(hand.Cards)) { handTypes.ElementAt(3).Add(hand); continue; }
			if (TwoPairWithWildcards(hand.Cards)) { handTypes.ElementAt(4).Add(hand); continue; }
			if (OnePairWithWildcards(hand.Cards)) { handTypes.ElementAt(5).Add(hand); continue; }
			if (HighCardWithWildcards(hand.Cards)) { handTypes.ElementAt(6).Add(hand); continue; }
		}

		var rankedHands = RankHandsByTypes(handTypes);

		long totalWinnings = CalculateWinnings(rankedHands);

		return totalWinnings.ToString();
	}

	private static PlayingCard CharCardToPlayingCard(char card)
	{
		return card switch
		{
			'A' => PlayingCard.AceHigh,
			'2' => PlayingCard.Two,
			'3' => PlayingCard.Three,
			'4' => PlayingCard.Four,
			'5' => PlayingCard.Five,
			'6' => PlayingCard.Six,
			'7' => PlayingCard.Seven,
			'8' => PlayingCard.Eight,
			'9' => PlayingCard.Nine,
			'T' => PlayingCard.Ten,
			'J' => PlayingCard.Jack,
			'Q' => PlayingCard.Queen,
			'K' => PlayingCard.King,
			_ => PlayingCard.AceLow,
		};
	}

	private static PlayingCard CharCardToPlayingCardJokerWildCards(char card)
	{
		return card switch
		{
			'J' => PlayingCard.Joker,
			'A' => PlayingCard.AceHigh,
			'2' => PlayingCard.Two,
			'3' => PlayingCard.Three,
			'4' => PlayingCard.Four,
			'5' => PlayingCard.Five,
			'6' => PlayingCard.Six,
			'7' => PlayingCard.Seven,
			'8' => PlayingCard.Eight,
			'9' => PlayingCard.Nine,
			'T' => PlayingCard.Ten,
			'Q' => PlayingCard.Queen,
			'K' => PlayingCard.King,
			_ => PlayingCard.AceLow,
		};
	}

	private static bool FiveOfAKind(List<PlayingCard> hand)
	{
		return hand.Distinct().Count() == 1;
	}

	private static bool FourOfAKind(List<PlayingCard> hand)
	{
		return hand.GroupBy(card => card).Any(a => a.Count() == 4);
	}

	private static bool FullHouse(List<PlayingCard> hand)
	{
		return hand.GroupBy(card => card).Where(a => a.Count() >= 2).Count() == 2
			&& hand.Distinct().Count() == 2;
	}

	private static bool ThreeOfAKind(List<PlayingCard> hand)
	{
		return hand.GroupBy(card => card).Any(a => a.Count() == 3);
	}

	private static bool TwoPair(List<PlayingCard> hand)
	{
		return hand.GroupBy(card => card).Where(a => a.Count() == 2).Count() == 2;
	}

	private static bool OnePair(List<PlayingCard> hand)
	{
		return hand.GroupBy(card => card).Any(a => a.Count() == 2);
	}

	private static bool HighCard(List<PlayingCard> hand)
	{
		return hand.Distinct().Count() == 5;
	}

	private static bool FiveOfAKindWithWildcards(List<PlayingCard> hand)
	{
		var handWithoutWildcards = hand.Where(card => card != PlayingCard.Joker).ToList();

		return handWithoutWildcards.Distinct().Count() <= 1;
	}

	private static bool FourOfAKindWithWildcards(List<PlayingCard> hand)
	{
		var numberOfWildCards = hand.Where(card => card == PlayingCard.Joker).Count();
		var handWithoutWildcards = hand.Where(card => card != PlayingCard.Joker).ToList();

		return handWithoutWildcards.GroupBy(card => card).Any(a => a.Count() == 4 - numberOfWildCards);
	}

	private static bool FullHouseWithWildcards(List<PlayingCard> hand)
	{
		var handWithoutWildcards = hand.Where(card => card != PlayingCard.Joker).ToList();

		return hand.GroupBy(card => card).Where(a => a.Count() >= 2).Count() == 2
			&& handWithoutWildcards.Distinct().Count() == 2;
	}

	private static bool ThreeOfAKindWithWildcards(List<PlayingCard> hand)
	{
		var numberOfWildCards = hand.Where(card => card == PlayingCard.Joker).Count();
		var handWithoutWildcards = hand.Where(card => card != PlayingCard.Joker).ToList();

		return handWithoutWildcards.GroupBy(card => card).Any(a => a.Count() == 3 - numberOfWildCards);
	}

	private static bool TwoPairWithWildcards(List<PlayingCard> hand)
	{
		var numberOfWildCards = hand.Where(card => card == PlayingCard.Joker).Count();

		return hand.GroupBy(card => card).Where(a => a.Count() == 2 - numberOfWildCards).Count() == 2 - numberOfWildCards;
	}

	private static bool OnePairWithWildcards(List<PlayingCard> hand)
	{
		var numberOfWildCards = hand.Where(card => card == PlayingCard.Joker).Count();

		return hand.GroupBy(card => card).Any(a => a.Count() == 2 - numberOfWildCards);
	}

	private static bool HighCardWithWildcards(List<PlayingCard> hand)
	{
		var handWithoutWildcards = hand.Where(card => card != PlayingCard.Joker).ToList();

		return handWithoutWildcards.Distinct().Count() == handWithoutWildcards.Count;
	}

	private List<Hand> RankHandsByTypes(List<Hand>[] hands)
	{
		List<Hand> rankedTypeByHands = [];

		for (int i = 0; i < hands.Length; i++)
		{
			hands[i] =
			[
				.. hands[i]
					.OrderByDescending(x => x.Cards[4])
					.OrderByDescending(x => x.Cards[3])
					.OrderByDescending(x => x.Cards[2])
					.OrderByDescending(x => x.Cards[1])
					.OrderByDescending(x => x.Cards[0])
			];
		}

		foreach (var rank in hands)
		{
			rankedTypeByHands.AddRange(rank);
		}

		return rankedTypeByHands;
	}

	private long CalculateWinnings(List<Hand> hands)
	{
		long total = 0;

		hands.Reverse();

		for (int i = 1; i <= hands.Count; i++)
		{
			total += hands[i - 1].Bid * i;
		}

		return total;
	}

	internal class Hand
	{
		public List<PlayingCard> Cards { get; }
		public int Bid { get; }

		public Hand(int bid, List<PlayingCard> cards)
		{
			Bid = bid;
			Cards = cards;
		}
	}
}
