using System;
using System.Collections.Generic;
using System.Linq;
using SimpleFinanceManager;

public class CommandManager : IManager
{
    private readonly ICategoryRepo CategoryRepo = new CategoryRepo();
    private IItem item;

    public string AddCategory(IList<string> arguments)
    {
        var result = string.Empty;

        var categoryName = arguments[0];
        var categoryType = categoryName + "Category";

        try
        {
            var classType = Type.GetType(categoryType);
            var constructors = classType.GetConstructors();
            var category = (ICategory) constructors[0].Invoke(new object[] {categoryName});

            var added = this.CategoryRepo.FillRepoWithCategories(category);

            result = added
                ? $"Category {categoryType} with the name {category.Name} added."
                : string.Format(ErrorMessages.CategoryAlreadyAdded, category.Name);
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
    }

    public string AddLimit(IList<string> arguments)
    {
        var limit = double.Parse(arguments[0]);
        var categoryName = arguments[1];

        var wantedCategory = CategoryRepo.Categories.FirstOrDefault(c => c.Name.Equals(categoryName));
        var initialLimit = 0.0;

        if (wantedCategory == null)
        {
            return ErrorMessages.CannotSetLimitToNonExistantCategory;
        }

        try
        {
            initialLimit = wantedCategory.Limit;
            wantedCategory.ChangeLimit(limit);
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return string.Format(Messages.SuccessfullyChangedInitialLimit, wantedCategory.Name, initialLimit,
            wantedCategory.Limit);
    }

    public string AddItemToCategory(IList<string> arguments)
    {
        var categoryName = arguments[0];
        var wantedCategory = CategoryRepo.Categories.FirstOrDefault(c => c.Name.Equals(categoryName));

        if (wantedCategory == null)
        {
            return ErrorMessages.CannotAddItemToNonExistantCategory;
        }

        try
        {
            var itemName = arguments[1];
            var itemPrice = double.Parse(arguments[2]);

            item = new Item(itemName, itemPrice);

            wantedCategory.AddItems(item);
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return string.Format(Messages.SuccessfullyAddedItemToCategory, item.Name, wantedCategory.Name, item.Price);
    }

    public string ShowCurrentBalance(IList<string> arguments)
    {
        var categoryName = arguments[0];
        var wantedCategory = CategoryRepo.Categories.FirstOrDefault(c => c.Name.Equals(categoryName));
        var currentBalance = 0.0;

        try
        {
            currentBalance = CategoryRepo.ShowCurrentBalance(wantedCategory);
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return string.Format(Messages.CurrentBalance, wantedCategory.Name, currentBalance);
    }

    public string ShowTotalItemsSum(IList<string> arguments)
    {
        var categoryName = arguments[0];
        var wantedCategory = CategoryRepo.Categories.FirstOrDefault(c => c.Name.Equals(categoryName));
        var itemsSum = 0.0;

        try
        {
            itemsSum = CategoryRepo.ShowTotalItemsSum(wantedCategory);
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return string.Format(Messages.DesiredItemsSum, wantedCategory.Name, itemsSum);
    }

    public string RemoveCategory(IList<string> arguments)
    {
        var categoryName = arguments[0];
        var wantedCategory = CategoryRepo.Categories.FirstOrDefault(c => c.Name.Equals(categoryName));

        try
        {
            CategoryRepo.RemoveCategory(wantedCategory);
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return string.Format(Messages.SuccessfullyRemovedCategory, wantedCategory.Name);
    }

    public string RemoveItem(IList<string> arguments)
    {
        var categoryName = arguments[0];
        var itemName = arguments[1];


        if (!CategoryRepo.Categories.Any(c => c.Name.Equals(categoryName)))
        {
            return string.Format(ErrorMessages.CategoryDoesNotExist, categoryName);
        }

        var wantedCategory = CategoryRepo.Categories.FirstOrDefault(c => c.Name.Equals(categoryName));
        var wantedItem = wantedCategory.Items.FirstOrDefault(i => i.Name.Equals(itemName));

        try
        {
            CategoryRepo.RemoveItem(wantedCategory, wantedItem);
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return string.Format(Messages.SuccessfullyRemovedItem, wantedItem.Name);
    }
}