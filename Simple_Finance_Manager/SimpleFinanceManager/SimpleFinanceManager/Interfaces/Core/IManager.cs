using System.Collections.Generic;

public interface IManager
{
    string AddLimit(IList<string> arguments);

    string AddCategory(IList<string> arguments);

    string AddItemToCategory(IList<string> arguments);

    string ShowCurrentBalance(IList<string> arguments);

    string ShowTotalItemsSum(IList<string> arguments);

    string RemoveCategory(IList<string> arguments);

    string RemoveItem(IList<string> arguments);
}