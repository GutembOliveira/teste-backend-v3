namespace TheatricalPlayersRefactoringKata;
using System;
public class Play
{
    private string _name;
    private int _lines;
    private string _type;

    public string Name { get => _name; set => _name = value; }
    public int Lines { get => _lines; set => _lines = value; }
    public string Type { get => _type; set => _type = value; }

    public Play(string name, int lines, string type) {
        this._name = name;
        if (lines < 1000) lines = 1000;
        if (lines > 4000) lines = 4000;
        this._lines = lines;
        this._type = type;
    }

  

}
