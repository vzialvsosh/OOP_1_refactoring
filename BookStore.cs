public class BookStore
{
  private Catalog _catalog;

  public Catalog Catalog { get => _catalog; }

  public BookStore(Catalog catalog)
  {
    _catalog = catalog;
  }

  public void Rent(string isbn)
  {
    _catalog[isbn].Rent();
  }

  public void Return(string isbn)
  {
    _catalog[isbn].Return();
  }

  public void SetPrice(string isbn, double price)
  {
    _catalog[isbn].Reprice(price);
  }

  public void PrintCatalog()
  {
    foreach (Book book in _catalog.All())
    {
      Console.WriteLine(book.ToString());
    }
  }
}
