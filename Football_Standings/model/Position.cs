namespace Football_Standings;

public class Position
{
    public string Name { get; set; }
    public int Number { get; set; }

    public Position(string name, int number) {
        Name = name;
        Number = number;
    }
}