namespace Football_Standings;

public class League
{
    public string LeagueName { get; set; }
    public int ChampionsLeaguePositions { get; set; }
    public int EuropeLeaguePositions { get; set;}
    public int ConferenceLeaguePositions { get; set;}
    public int PositionsForPromotion { get; set;}
    public int PositionsForRelegation { get; set;}
      
    public League(string leagueName, int positionsForChampions, int positionsForEurope, int positionsForConference, int positionsForPromotion, int positionsForRelegation)
    {
        LeagueName = leagueName;
        ChampionsLeaguePositions = positionsForChampions;
        EuropeLeaguePositions = positionsForEurope;
        ConferenceLeaguePositions = positionsForConference;
        PositionsForPromotion = positionsForPromotion;
        PositionsForRelegation = positionsForRelegation;
    }
  
}