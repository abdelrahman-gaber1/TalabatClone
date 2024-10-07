namespace Talabat.APIS.Notes
{
    public class Session2
    {
        #region SepecificationDesignPattern
        //SepecificationDesignPattern Help me to build Query Dynamic  (Less Code)
        //When i Know that i must use Design Pattern 
        //if i have a problem in my implementation Code So i use Design Pattern (sepicific) to solve it
        //Archtecture Pattern to detect Structure of my project 
        //Sepecification Design Pattern help me to send to method GetAll the Query(Dynamic) that i will build
        //Query Contist of Sequence (Table)(Set) + Where(If I Have) Include(If I Have)=>Linq Operator=>Sepecification 
        //So To Build Query We Need Sequence and Sepecification 

        //Not All T Have Property Brand and Category So I can't include this Property with all T
        //With Each Model(More Code) i will Do If Condition to detect what i want to include 
        //If I Added New Model i will make new Condtion in GetAll so i will Brake solid Princible Open For Extention Closed For Modification(OpenClosed Princible)
        //If You Madefiy Method you must ensure that all thing use this method are work correct 

        //we need to make function to build query - return of this fuction is query depend on your properities 
        //this fuction will take two paramater Sequence and Sepecification
        //we will send to this Fuction object of type sepecification this object contain  ex: two property one for include and one for where (Cretirya(exeprtion) logic i will send to where)
        //if critrya didn't use in Function i will send it by null
        //So First i want to create InterFace then class caled sepeicifectation 
        //In this Class Type of Cretria is Lamda Exepretion and you must determine type of expression(Delegete) (Func-Action-Predecet)
        //Action No return any thing  - Predecet take one input and return boolean -Func take from zero to 16 pramater and return 
        //I didn't know number of include so this property will be List of Lamda Exepretion that i want to include 

        //Sepecification Class and Interface represent in core layer because this class implementation will not differ from repository to antoher so we will add it in core
        //This Interface will accept only BaseModel class because Set(Sequence)  will send to Function is model
        //
        #endregion
    }
}
