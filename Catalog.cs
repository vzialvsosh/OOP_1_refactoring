public class Catalog
{
  private Dictionary<string, Book> _items = new();
  private List<string> _order = new();

  public int Count { get => _order.Count; }

  public void Add(Book book)
  {
    if (_order.Contains(book.Isbn)) throw new InvalidOperationException("Cannot add existing isbn to catalog\n");
    _order.Add(book.Isbn);
    _items[book.Isbn] = book;
  }

  public bool Remove(string isbn)
  {
    _order.Remove(isbn);
    return _items.Remove(isbn);
  }

  public bool Contains(string isbn)
  {
    return _items.ContainsKey(isbn);
  }

  public IReadOnlyCollection<Book> All()
  {
    List<Book> list = new();
    foreach (string isbn in _order)
    {
      list.Add(_items[isbn]);
    }
    return list.AsReadOnly();
  }

  public Book this[string isbn]
  {
    get => _items[isbn];
    set => _items[isbn] = value;
  }

  public Book this[int index]
  {
    get => _items[_order[index]];
    set => _items[_order[index]] = value;
  }

  public Book this[(string author, int index) key]
  {
    get
    {
      int i = 0;
      foreach (string isbn in _order)
      {
        if (_items[isbn].Author == key.author)
        {
          if (i == key.index) return _items[isbn];
          i++;
        }
      }
      throw new KeyNotFoundException($"No book in catalog: ({key.author}, {key.index})\n");
    }
    set
    {
      int i = 0;
      foreach (string isbn in _order)
      {
        if (_items[isbn].Author == key.author)
        {
          if (i == key.index)
          {
            _items[isbn] = value;
            return;
          }
          i++;
        }
      }
      throw new KeyNotFoundException($"No book in catalog: ({key.author}, {key.index})\n");
    }
  }
}