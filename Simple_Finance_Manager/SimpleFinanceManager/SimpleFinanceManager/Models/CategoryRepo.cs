using System;
using System.Collections.Generic;
using System.Linq;
using SimpleFinanceManager;

public class CategoryRepo : ICategoryRepo
{
    private HashSet<ICategory> categories;

    public CategoryRepo()
    {
        this.categories = new HashSet<ICategory>();
    }

    public ICollection<ICategory> Categories => this.categories;

    public bool FillRepoWithCategories(ICategory category)
    {
        var categoryExists = categories.Any(c => c.Name.Equals(category.Name));

        if (categoryExists)
        {
            return false;
        }

        this.Categories.Add(category);

        return true;
    }

    public double ShowCurrentBalance(ICategory category)
    {
        if (category == null)
        {
            throw new ArgumentException(ErrorMessages.DesiredCategoryDoesNotExist);
        }

        return category.Limit;
    }

    public double ShowTotalItemsSum(ICategory category)
    {
        if (category == null)
        {
            throw new ArgumentException(ErrorMessages.DesiredCategoryDoesNotExist);
        }

        return category.Items.Sum(p => p.Price);
    }

    public void RemoveCategory(ICategory category)
    {
        if (category == null)
        {
            throw new ArgumentException(ErrorMessages.DesiredCategoryDoesNotExist);
        }

        this.Categories.Remove(category);
    }

    public void RemoveItem(ICategory category, IItem item)
    {
        if (item == null)
        {
            throw new ArgumentException(ErrorMessages.DesiredItemDoesNotExist);
        }

        this.Categories.FirstOrDefault(c => c.Name.Equals(category.Name)).Items.Remove(item);
    }
}