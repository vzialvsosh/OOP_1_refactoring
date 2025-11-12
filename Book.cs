public class Book
{
  private double _price;
  private int _stock;

  public string Isbn { get; }
  public string Title { get; private set; }
  public string Author { get; private set; }
  public double Price
  {
    get => _price;
    private set
    {
      if (value < 0) throw new ArgumentOutOfRangeException();
      _price = value;
    }
  }
  public int Stock {
    get => _stock;
    private set
    {
      if (value < 0) throw new ArgumentOutOfRangeException();
      _stock = value;
    }
  }
  public bool IsAvailable { get => Stock > 0; }

  public Book(string isbn, string title, string author, double price, int stock)
  {
    Isbn = isbn;
    Title = title;
    Author = author;
    Price = price;
    Stock = stock;
  }

  public void Rent()
  {
    if (Stock == 0) throw new InvalidOperationException();
    Stock--;
  }

  public void Return()
  {
    Stock++;
  }

  public void Reprice(double newPrice)
  {
    Price = newPrice;
  }

  public void Rename(string newTitle)
  {
    Title = newTitle;
  }

  public override string ToString()
  {
    return $"{Isbn} | {Title} | {Author} | {Price} | stock={Stock}";
  }
}
