namespace Talabat.APIS.Notes
{
    public class Session5
    {
        //6                  49   28   50     40      14 
        #region IEnumerableVsIReadOnly
        //I didn't want to iterate in data that come from database 
        //because i send it dirictly to front as json file 
        //so we will use IReadOnly istead of IEnumerable 
        //IReadOnly better in Cashing and Performance than IEnumerable
        //note in mvc we iterate in data in view to display it so we use IEnumerable
        #endregion

        #region Sorting
        //We want to sort Product that come from end Point by any thing (ex:Name-Price => Asending or Desinding )
        //Data is Sorted in Database by PK and data return in this Sorting
        //so we want to have apility to sort by any thing 
        //We Make Sort Based on What Bussiness need (In Our Bussiness => Name - Price - Default)
        //We want to Send To GetProduct Pramater(Query String) to detect What we will sort by (Name - Price - Default)
        //We have 4 Operator for Sorting In Linq (OrderBy-OrderByDesc-ThenBy-ThenByDesc)
        //I Want to added to Query That I built OrderBy So I must add it in Sepecification That i use it to Built Query
        //Make Method To Initialize OrderBy Expression and OrderByDesc Expression  
        //Not We can Make Sort By using this method or didn't use Sort by ignore this Method
        #endregion
    }

}
 