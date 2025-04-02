using System;


public class Item : BaseClass
{
    public string name { get; set; };

    public string? description { get; set; };

    private float? _price { get; set; };
    public float? price
    {
        get => _price;
        set => _price = (float)Math.Round(value, 2);
    }

    public List<string>? tags { get; set; };

    public Item(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.", nameof(name));

        this.name = name;
        this.tags = new List<string>();
    }
}

