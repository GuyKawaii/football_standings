namespace Football_Standings;

public class League
{
    public string LeagueName { get; set; }

    public List<Position> UpperPromotions { get; set; }
    public Position LowerPromotions { get; set; }
    public int LowerRelegations { get; set; }


    public League(string leagueName, int positionsForChampions, int positionsForEurope, int positionsForConference,
         int positionsForRelegation)
    {
        List<Position> promotions = new List<Position>();
        if (positionsForChampions > 0)
        {
            promotions.Add(new Position("Champions League", positionsForChampions));
        }
        if (positionsForChampions > 0)
        {
            promotions.Add(new Position("Conference League", positionsForConference));
        }
        if (positionsForChampions > 0)
        {
            promotions.Add(new Position("Europa League", positionsForEurope));
        }

        UpperPromotions = promotions.GetRange(0, promotions.Count - 2);
        LowerPromotions = promotions[promotions.Count - 1];
        LowerRelegations = positionsForRelegation;
    }
}