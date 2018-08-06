using System.Collections.Generic;

public interface ICategoryRepo
{
    ICollection<ICategory> Categories { get; }

    bool FillRepoWithCategories(ICategory category);

    void RemoveCategory(ICategory category);

    void RemoveItem(ICategory category, IItem item);

    double ShowCurrentBalance(ICategory category);

    double ShowTotalItemsSum(ICategory category);
}