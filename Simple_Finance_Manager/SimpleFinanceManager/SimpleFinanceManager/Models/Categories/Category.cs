using System;
using System.Collections.Generic;
using SimpleFinanceManager;

public abstract class Category : ICategory
{
    private const double InitialLimit = 100;

    protected Category(string name)
    {
        this.Name = name;
        this.Limit = InitialLimit;
        this.Items = new List<IItem>();
    }

    public string Name { get; set; }

    public double Limit { get; set; }

    public void ChangeLimit(double limit)
    {
        if (limit <= 0)
        {
            throw new ArgumentException(ErrorMessages.LimitCannotBeLessThanOrEqualToZero);
        }

        this.Limit = limit;
    }

    public IList<IItem> Items { get; set; }

    public void AddItems(IItem item)
    {
        if (item.Price > Limit)
        {
            throw new ArgumentException(string.Format(ErrorMessages.ItemPriceCannotExceedLimit, this.Limit));
        }

        this.Items.Add(item);
        ReduceLimitAfterAddingItem(item);
    }

    private void ReduceLimitAfterAddingItem(IItem item)
    {
        this.Limit -= item.Price;
    }
}