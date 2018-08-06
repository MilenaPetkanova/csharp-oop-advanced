namespace SimpleFinanceManager
{
    public class ErrorMessages
    {
        public const string LimitCannotBeLessThanOrEqualToZero = "Cannot change Limit to be 0 or less.";

        public const string ItemPriceCannotExceedLimit =
            "Item Price cannot exceed Limit. Your current balance is {0} €.";

        public const string DesiredCategoryDoesNotExist = "Desired Category does not exist.";

        public const string DesiredItemDoesNotExist = "Desired Item does not exist.";
        
        public const string CategoryAlreadyAdded = "Category {0} already exists.";
        
        public const string CannotSetLimitToNonExistantCategory = "Cannot set limit to a category that doesn't exist.";

        public const string CannotAddItemToNonExistantCategory = "Cannot add an item to a category that doesn't exist.";
        
        public const string CategoryDoesNotExist =
            "Category {0} does not exist and therefor you cannot remove this item.";
    }
}