# \# Synchronous vs Asynchronous Processing





## \## About



Console application that demonstrates the difference between synchronous blocking code and asynchronous non-blocking code, using:

* Thread.Sleep();
* Task, Task.Delay();
* async, await;
* Task.WhenAll(), Task.WhenAny();
* measuring execution time;
* handling asynchronous errors.





## \## Features



* Synchronous Execution Result

Three methods are started one by one. Each method uses Thread.Sleep(3000). It means that next method can not started until the previous one doesn't finished. Thread is stopping until the time in method is over (3000 ms) (Blocking waiting). 3 methods \* 3 seconds = 9 seconds.



* Asynchronous Execution Result

Method ProcessDataAsync() returns a Task. All three delays (await Task.Delay()) in methods are running at the same time, because three tasks are created before any of them is awaited. So the total execution time is about the longest one (3000 ms) (Non-blocking waiting) Method stopped on 3 seconds but thread is free and do another tasks. Keywords "async" and "await" do not create threads. Async method runs synchronously until it find "await" keyword, which allows to pause the execution of method while waiting (for example, for a response from the network, database or file) and thread can execute another queries.



* Explanation of blocking vs non-blocking waiting:

Blocking waiting (Thread.Sleep()) it is means that current thread is stopped and wait until the time is over. Thread can not be used for another work.

Non-blocking waiting (await Task.Delay()) it is means that method stopped but thread is free and can do another work. When delay is over then method execution is continue.

Web server handles many requests such as query to database. If the thread is blocked while waiting for the database (synchronous I/O), that thread cannot efficiently process another request. With asynchronous database access (async I/O such as database or HTTP calls), the thread can be returned to the system while the database operation is in progress. This allows the application to handle resources more efficiently.



* Explanation of Task.WhenAll and Task.WhenAny:

Task.WhenAll() can takes several tasks and returns a completed task when all provided tasks have completed. Total execution time equals the longest (slowest) task in List.

Task.WhenAny() completes when at least one of the provided tasks completes. This is useful when tasks take different amounts of time and you want to show results using loop as soon as they are ready.

Asynchronous programming doesn't make code faster. The total time becomes shorter because several independent waiting periods overlap. But if methods depends on each other and must run in sequence, async doesn't make them faster.



* Handling error:

Method returns task, if inside the method find errors it's not thrown, but saved inside this task and change status like IsFaulted (true). Exception (if it's founded) thrown at the moment with "await" keyword, so try/catch needs to be placed around "await".





## \## How to Run



1. Clone the repository:



git clone https://github.com/Projkeen/dotnet-pre-trainee.git



2. Go to the project folder, where exist file .csproj:



cd dotnet-pre-trainee/Sync vs Async Processing/Sync vs Async Processing



3. Run the application:



dotnet run











### 

