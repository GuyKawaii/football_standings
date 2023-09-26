namespace Football_Standings;

public class League
{
    public string LeagueName { get; set; }

    public List<Position> UpperPromotions { get; set; }
    public List<Position> LowerPromotions { get; set; }
    public int LowerRelegations { get; set; }


    public League(string leagueName, int positionChampions, int positionsForConference, int positionsForEurope,
         int positionsForRelegation)
    {
        List<Position> promotionsCategories = new List<Position>();
        if (positionChampions > 0)
        {
            promotionsCategories.Add(new Position("Champions League", positionChampions));
        }
        if (positionChampions > 0)
        {
            promotionsCategories.Add(new Position("Conference League", positionsForConference));
        }
        if (positionChampions > 0)
        {
            promotionsCategories.Add(new Position("Europa League", positionsForEurope));
        }

        UpperPromotions = promotionsCategories.GetRange(0, promotionsCategories.Count - 1);

        LowerPromotions = new List<Position>
        {
            promotionsCategories[promotionsCategories.Count - 1]
        };
        LowerRelegations = positionsForRelegation;


        // Upper[[champ, 2], [conf, 3]]

        // lower[]
    }
}