using System.Collections.Generic;

public interface ICategory
{
    string Name { get; set; }

    double Limit { get; set; }

    IList<IItem> Items { get; set; }

    void AddItems(IItem item);

    void ChangeLimit(double limit);
}