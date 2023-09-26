namespace Football_Standings;

public class LeagueOld
{
    public string LeagueName { get; set; }

    public List<Position> upperPromotions { get; set; }
    public List<Position> lowerPromotions { get; set; }
    public List<Position> lowerRelegations { get; set; }


    public int ChampionsLeaguePositions { get; set; }
    public int EuropeLeaguePositions { get; set; }
    public int ConferenceLeaguePositions { get; set; }
    public int PositionsForPromotion { get; set; }
    public int PositionsForRelegation { get; set; }

    public LeagueOld(string leagueName, int positionsForChampions, int positionsForEurope, int positionsForConference,
        int positionsForPromotion, int positionsForRelegation)
    {
        LeagueName = leagueName;
        ChampionsLeaguePositions = positionsForChampions;
        EuropeLeaguePositions = positionsForEurope;
        ConferenceLeaguePositions = positionsForConference;
        PositionsForPromotion = positionsForPromotion;
        PositionsForRelegation = positionsForRelegation;
    }

    public List<Position> GetLeaguePromotions()
    {
        List<Position> positions = new List<Position>();

        if (ChampionsLeaguePositions > 0)
            positions.Add(new Position("Champions League", ChampionsLeaguePositions));
        if (EuropeLeaguePositions > 0)
            positions.Add(new Position("Europe League", EuropeLeaguePositions));
        if (ConferenceLeaguePositions > 0)
            positions.Add(new Position("Conference League", ConferenceLeaguePositions));
        if (PositionsForPromotion > 0)
            positions.Add(new Position("Promotion", PositionsForPromotion));


        return positions;
    }

    public List<Position> GetLeagueRelegations()
    {
        List<Position> positions = new List<Position>();

        if (PositionsForRelegation > 0)
            positions.Add(new Position("Relegation", PositionsForRelegation));

        return positions;
    }
}