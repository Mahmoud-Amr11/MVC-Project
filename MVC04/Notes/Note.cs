//ViewBag and ViewData are used to pass data from the Controller to the View - From View To Partial View - From View To Layout
// ViewBag is a dynamic object - ViewData is a dictionary object
//TempData → when passing data across redirects (Controller → Controller).



//Partial View 
//views allowing you to avoid code duplication and keep your views clean and maintainable.

//Service Life Time
//Singleton : Created once and shared throughout the application's lifetime.
//Scoped    : Created once per client request (connection).
//Transient : Created each time they are requested.



//Unite of Work 
//design pattern that ensures multiple operations (like inserts, updates, deletes) are executed in a single transaction


//Using lazy initialization to defer the creation of an object until it is actually needed
//


//Attachment Service

//1.Check Extension
//2. Check Size 
//3. Get Located Folder Path
//4. Make Attachment Name Unique -- GUID
//5. Get File Path
//6. Create File Stream To Copy File [Unmanaged]
//7.Use Stream To Copy File 
//8. Return FileName To Store In Database 


