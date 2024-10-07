using Microsoft.VisualBasic;

namespace Talabat.APIS.Notes
{
    public class Session2
    {
        //70+10  17      6        24     24   19      6
        #region SpecificationDesignPattern
        //SepecificationDesignPattern Help me to build Query Dynamic  (Less Code)
        //When i Know that i must use Design Pattern 
        //if i have a problem in my implementation Code So i use Design Pattern (specific) to solve it
        //Architecture Pattern to detect Structure of my project 
        //Specification Design Pattern help me to send to method GetAll the Query(Dynamic) that i will build
        //Query Contest of Sequence (Table)(Set) + Where(If I Have) Include(If I Have)=>LINQ Operator=>Specification 
        //So To Build Query We Need Sequence and Specification 
        //I determine shape of specification using interface 

        //Not All T Have Property Brand and Category So I can't include this Property with all T
        //With Each Model(More Code) i will Do If Condition to detect what i want to include 
        //If I Added New Model i will make new Condition in GetAll so i will Brake solid Principle Open For Extension Closed For Modification(OpenClosed Principle)
        //If You Modify Method you must ensure that all thing use this method are work correct 

        //we need to make function to build query - return of this function is query depend on your properties 
        //this function will take two parameter Sequence and Specification
        //we will send to this Function object of type specification this object contain  ex: two property one for include and one for where (Criteria(Expression) logic i will send to where)
        //if Criteria didn't use in Function i will send it by null
        //So First i want to create InterFace then class called specification 
        //In this Class Type of Criteria is Lambda Expression and you must determine type of expression(Delegate) (Func-Action-Predicate)
        // Action No return any thing  - Predicate take one input and return boolean -Func take from zero to 16 parameter and return 
        //I didn't know number of include so this property will be List of Lambda Expression that i want to include 
        //Include may be return object or list of object 

        //I Tell him to use this Specification class you must implement this interface 
        //Base Specification called this because contain all common Specification on Model
        //I will make for each Model his specific Specification

        //When use new it create object and all property is null
        //include can't be null so we must initialize it 
        //criteria may can't be null if i use it so we must initialize it in parameterized ctor
        //First thing happen when create object of class is initialization of property

        //Specification Class and Interface represent in core layer because this class implementation will not differ from repository to another so we will add it in core
        //This Interface will accept only BaseModel class because Set(Sequence)  will send to Function is model

        //We will build Function that will return query in Repository layer because it will return query that will run in db so it differ from db to another
        //return of this Function will be IQuarable to do filter in db and return it 
        //type of sequence will be IQuarable

        //I will Know if i Have Where or not by value in criteria 
        //may i have one include or more so i must iterate on it using aggregate operator 
        //aggregate operator take sequence that i will work on it then seed data initial data then func input store current and output 
        //string[] names = { "Abdo", "Gaber", "Saied" };
        //string msg = "Hello";
        //msg = names.Aggregate(msg , (str01,str02)=> $"{str01} {str02}");

        #endregion

    }
}
