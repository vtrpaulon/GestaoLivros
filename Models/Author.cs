namespace GestaoLivros.Models;

public class Author
{
    private string _name;

    public Author(string name)
    {
        this._name = name;
    }

    public string Name { get => _name; set => _name = value; }
}