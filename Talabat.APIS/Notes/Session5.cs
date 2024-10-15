namespace Talabat.APIS.Notes
{
    public class Session5
    {
        //6                  49   28   50     40      14 
        #region IEnumerableVsIReadOnly
        //I didn't want to iterate in data that come from database 
        //because i send it directly to front as JSON file 
        //so we will use IReadOnly instead of IEnumerable 
        //IReadOnly better in Cashing and Performance than IEnumerable
        //note in MVC we iterate in data in view to display it so we use IEnumerable
        #endregion

        #region Sorting
        //We want to sort Product that come from end Point by any thing (ex:Name-Price => Ascending or Descending )
        //Data is Sorted in Database by PK and data return in this Sorting
        //so we want to have ability to sort by any thing 
        //We Make Sort Based on What Business need (In Our Business => Name - Price - Default)
        //We want to Send To GetProduct Parameter(Query String) to detect What we will sort by (Name - Price - Default)
        //We have 4 Operator for Sorting In LINQ (OrderBy-OrderByDesc-ThenBy-ThenByDesc)
        //I Want to added to Query That I built OrderBy So I must add it in Specification That i use it to Built Query
        //Make Method To Initialize OrderBy Expression and OrderByDesc Expression  
        //Not We can Make Sort By using this method or didn't use Sort by ignore this Method
        #endregion
    }

}
 