namespace Talabat.APIS.Notes
{
    public class Session2
    {
        #region ProductModule
        //we will not connect our Layers now until we need it 
        //First thing we need to determine is architecture pattern : Union Architecture 
        //Union Architecture : Have Four Layers 
        //1.Domain Layer [Core Layer] : Models [Class Represent Table In Database ] + Core Of Project Not Implemented[Interface]
        //2.Repository Layer (M) :DbContext + Repository[Part Of Business]
        //3.Services Layer
        //4.Presentation Layer
        //Second we need to determine the Modules in out project 
        //First Module is Product Module have three entities
        //Product        :  Int Id  string Name string Description string PictureUrl decimal Price
        //Product Brand  :  Int Id  string Name
        //Product Category   :  Int Id  string Name
        //Third We see Layers in our project and which one will work in First is Core Layer
        //there is property(ID) common between this three entities and all other entities
        //all class model that represent in data base have id
        //so we will add this property in BaseModel and all model inherit form that
        //we will not added Name in Model base because not necessary to all model have this property
        //Fourth Determine Relation Between model we will do it using navigation property
        //Note in our Businesses we Don't need to reach to products of our brand and products of our Category so we don't need navigation property many
        //But we have problem EFC will understand our relation in one to one 
        //so i will represent navigation property many using fluent API 
        //I do navigation property not only for relation but also for access data like all product of brand
        //we always need to represent foreign key of brand and Category we need it because when add or update product we need to determine which brand or Category belong to
        #endregion

        #region DbContext-Configurations-Migration
        //Do DbContext Class that responsible for connect with DB in Repository Layer (M)
        //DbContect have OnModelCreating (Fluent API) and OnConfiguring (Connection String)
        //DbContext need package EFC SQL Server
        //Depend on DB you Use install appropriate Package 
        //To open connection with database you need object form AppDbContext

        //To Create Object have to way using Parameter Less Constructor That Chain in Parameter Less Constructor of DbContext
        //Parameter Less Constructor Of DbContext Chain on Parameterized constructor of DbContextOption
        //DbContextOption Execute our override OnConfguring(Last One) and send on it our connection string
        //Or Use Dependency Injection We will Chain in Parameterized constructor of DbContextOption
        //so we need From CLR to Create object of DbContextOption Don't Forget Register Service of DbContextOption in Configure Service
        ////We Can Register Service of DbContextOption Using AddDbContext or AddScoped 
        //AddDbContext is better because it is register service of DbContext and DbContextOption
        //Note AddDbContext is in package EFC SQL Server That in Repository Project so we need reference from this project
        //AddDbContext Have to overload First without any parameter Second with parameter option 
        //we didn't need to override onConfiguring and send our connection string  
        //but we need to send our connection string with option and DbContextOptions will execute it with our connection string
        //We need to read connection string from app settings (Dynamic not Static)
        //because it is change from environment to other
        //In AppSetting Each Region is key : value 
        //We will Reach to Connection String using Configuration : contain every thing in app settings
        //but we don't have Configuration in our program but it in builder then Send Name of Connection String

        //Then we Need to Determine DbSet To Represent Model as Table In Database
        //Then Implement Fluent API So We Need OnModelCreating
        //DbConext don't have fluent api(Table) so we don't need to run base.OnModelCreating
        //I must add this base because the table i inherited from identityDbContext that have table that has fluent api
        //This fluent api write in onModelCreating of base so we must run it to run this fluent api

        //we will write our fluent Api in Configuration File for each model
        //Configuration Class must inherit form IEntityTypeConfigration
        //Make Name Required to ignore in what version we deploy use fluent API or Data Annotation to determine in Required or not 
        //Determine Type of Decimal to don't Display Warning
        //Define Relation Between Table 
        //If BrandID is not NullAble will be by Default Cascade 
        //If BrandID is not Represented will be by Default No Action
        //We need to Apply this Configuration onModelCreating
        //I Can Use ApplyConfigurationFromAssemply to add all configuration
        //GetExcutingAssemply : Find All Classes that implement IEntityTypeConfiguration and Use it

        //Make Migration And install his package Tools we install this package in project that have connection String
        //Make PL is the start up project we add migration folder on Repository 
        //Add-Migration "initialCreate" -context AppDbContext          -output Data/Migrations 
        //               name of mig    -DbContext that will connect  - folder that will add mig
        //Then we will Update Database
        #endregion

        #region UpdateDataBase
        //We need when Run our Application he update Database with his self
        //See what Migration Not updated in Database and apply it 
        //When we run update database he execute this code in main 
        //create object form DbContext(StoreContext) then take this object and execute DbContext.Database.migrate
        //We have Problem StoreContext don't have Parameter Less Constructor and we can't create Parameter Less Constructor 
        //because he chain in DbContext Parameter Less Constructor That need to override onConfiguring
        //so we need to use Parameterized Constructor To Work With Dependency Injection
        //we can create object from DbContext(StoreContext) in the constructor of class program and use this object to execute DbContext.Database.migrate
        //but the main is static method and class program is static that have static constructor which the first thing run 
        //so when we create object from DbContext(StoreContext) CLR will check if you register service of StoreContext
        //and he will not found this service in main because static constructor will be the first thing run 
        //so we can't use this way 

        //Ask CLR Explicitly for Creating object from DbContext(StoreContext)
        //we need to create object from DbContext(StoreContext) using CLR Explicitly(Not in Constructor) in other way after build project 
        //first create variable scope (Period of time that object will remain life) and create Scope (That what is CLR Do when you need object with Scoped life time)
        //second create variable Service and assign to him ServiceProvider to add service you want to work with Dependency Injection
        //third Create object from DbContext(StoreContext) will create using CLR with Dependency Injection
        //but we have a problem because you open connection with data base and didn't close it you must close it
        //So we want to dispose this scope after finish this scope so we will use try finally
        //after finish code(Scope) in try will execute code in finally(Dispose)
        //Try Finally has syntax sugar is using That convert to Try Finally in compilation

        //Note when you update Database may be happen exception so he will not run application(Stop Execution)
        //so if we went to run application any way we use try(Code that may happen exception) catch

        //ILogger : Contain properties that control shape of error(for example create message error -Change color of message error)
        //To use it you need object form ILogger (LoggerFactory) then create logger form it
        //create logger : use it to log error of any class then determine shape of this error like determine message
        //Note we can track SQL query on console 

        //we use this way of update Database to when deploy it in server he don't have vsCode to update Database
        //so when use this way he will update Database when you run application
        #endregion

        #region DataSeeding
        //DataSeeding : Database seeding is the initial seeding of a database with data.
        //              This is often an automated process that is executed upon the initial setup of an application per server.
        //              The data can be dummy data or necessary data
        //              Dummy Data to work on it while development (front-end and back-end and testier)
        //              Transfer Data form old project to new one because i need this data
        //we need dummy data for product module to display it when use end point of this module
        //we have file Json and we need to seed it in data base

        //How to Seed(Add in Database) Json File ? 
        //We need to Create Method to Seed Data 
        //To store this data we need dbConnection
        //Read Json File Then convert it to List Of object(List Of Brand) Then add Each brand in Database 
        //Path must be Dynamic => You don't need path because ReadAllText See our Project 
        //To convert from Json to any thing use DeSerialize
        //To convert from any thing To Json use serialize
        //We need to call this method to execute this operation we will do it in main after Migrate
        //Note Exception Appear In Console not in project API
        //Note When Seeding Data if Id is Identity and your Json file have value of it will appear exception
        //To solve this problem Delete id from your Json file or Make brands object only name 
        //We have Issue each time we will run program he will seed this data so
        //We Want to tell him didn't seed data unless we didn't Seed it (Seed only One)
        //We want to check if our table contain Data or not 
        #endregion

        #region GenericRepository
        //Repository Layer : Repository [Part Of Implementation of Business]
        //Domain Layer     : Core Of Project Not Implemented [Interface]
        //We will work with GenericRepository To prevent code redundancy
        //We have interface belong to Repository and other belong to Service => All interface in Core
        //In IGenericRepository we will not implement (Add-Update-Delete) Because Admin only he will do (Add-Update-Delete) we will do it using Dashboard
        //Note we didn't need productRepository or brandRepository because no new logic will contain
        #endregion

        #region ProductController
        //We need to create End point for Get All (Product - Brand - Category)
        //Presentation Layer :  End Point Controller Api Empty
        //To reach to this Controller you must Write api/NameOfController
        // This route will repeat with all Controller i will do so we can create base Controller
        //and added in it route then each Controller i will create will inherit form base Controller
        //route is static so we can do it if route is deferent from base Controller write it
        //we need to create two end point one for get all product and other for get product by id
        #endregion

        #region GetProductEndPoint
        //First Determine type of method(EndPoint)  
        //To Reach to this method you must write BaseUrl/api/products
        //I return IActionResult because i have special type of this end point 
        //There is helper method called ok to return statues code 200 
        //EndPoint return Json File
        //We Reach to EndPoint Using Method and Take parameter or Not 
        //We have Problem there is no example of data send by endpoint
        //We need to Determine type of data we return but in this case we can't use helper method like ok
        //If There is exception we can't return BadRequest because we return IEnumerable only
        //so WE will Return ActionResult of What I Want to return like IEnumerable
        //Action Result to Get Shape of response in the Docomintaion
        //so I can return json file and statue code 
        //Note this end point will return brand and category with null
        //because relative data(relation) we must use egger loading(include this data) 
        //Note I didn't Know type of T so i can't include brand and category 
        //Make Representation for Each EndPoint in postman
        //make collection and folder for each Module Determine Method and URL
        //To prevent add base url in each request make local variable(Collection)
        #endregion

        #region GetProductById
        //You must make method take parameter to differ between this EndPoint and GetProduct 
        //To Reach to this method you must write BaseUrl/api/products/1 
        //We Went to make response of all error have same shape  
        //so we will make class to represent shape of error (only massage and status code)
        #endregion



        //......................................................
    }
}
