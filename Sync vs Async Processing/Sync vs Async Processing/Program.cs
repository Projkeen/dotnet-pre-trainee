using System.Diagnostics;

Console.WriteLine("=== Synchronous Processing ===");

var syncWatch = Stopwatch.StartNew();

Console.WriteLine(ProcessData("File 1"));
Console.WriteLine(ProcessData("File 2"));
Console.WriteLine(ProcessData("File 3"));

syncWatch.Stop();

Console.WriteLine($"Synchronous time: {syncWatch.Elapsed.TotalSeconds:F2} seconds");

Console.WriteLine();

Console.WriteLine("=== Asynchronous Processing ===");

var asyncWatch = Stopwatch.StartNew();

var tasks = new List<Task<string>>
{
    ProcessDataAsync("File 1", 3000),
    ProcessDataAsync("File 2", 3000),
    ProcessDataAsync("File 3", 3000)
};

// Your code for waiting and printing results goes here.
List<string> results = (await Task.WhenAll(tasks)).ToList();
foreach (var result in results)
{
    Console.WriteLine(result);
}

asyncWatch.Stop();

Console.WriteLine($"Asynchronous time: {asyncWatch.Elapsed.TotalSeconds:F2} seconds");

asyncWatch = Stopwatch.StartNew();

var tasksWhenAny = new List<Task<string>>
{
    ProcessDataAsync("File 1", 3000),
    ProcessDataAsync("File 2", 1000),
    ProcessDataAsync("File 3", 2000)
};

int totalTasks = tasksWhenAny.Count;
for (int i = 0; i < totalTasks; i++)
{
    Task<string> resultWhenAny = await Task.WhenAny(tasksWhenAny);
    tasksWhenAny.Remove(resultWhenAny);
    string result = await resultWhenAny;
    Console.WriteLine($"Asynchronous time: {asyncWatch.Elapsed.TotalSeconds:F2} seconds for {result}");
}

asyncWatch.Stop();
Console.WriteLine($"Total Asynchronous time: {asyncWatch.Elapsed.TotalSeconds:F2} seconds");

Console.WriteLine();

Console.WriteLine("=== Task with Exception ===");

asyncWatch = Stopwatch.StartNew();
var tasksWithException = new List<Task<string>>
{
    ProcessDataWithExceptionAsync("File 1", 3000),
    ProcessDataWithExceptionAsync("File 2", 1000),
    ProcessDataWithExceptionAsync("File 3", 2000)
};

foreach (Task<string> result in tasksWithException)
{
    try
    {
        List<string> catchTaskWithException = (await Task.WhenAll(result)).ToList();
        foreach (string task in catchTaskWithException)
        {
            Console.WriteLine(task);
        }          
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exception: {ex.Message}");
    }
}

asyncWatch.Stop();
Console.WriteLine($"Total Asynchronous time: {asyncWatch.Elapsed.TotalSeconds:F2} seconds");


static string ProcessData(string dataName)
{
    // Implement synchronous processing.
    Console.WriteLine($"Process started for {dataName}");
    Thread.Sleep(3000);
    return $"Processing has completed in 3 seconds for {dataName}";
}

static async Task<string> ProcessDataAsync(string dataName, int delayMilliseconds)
{
    // Implement asynchronous processing.
    Console.WriteLine($"Process starting for {dataName}");
    await Task.Delay(delayMilliseconds);
    return $"Processing has completed in {delayMilliseconds} milliseconds for {dataName}";
}

static async Task<string> ProcessDataWithExceptionAsync(string dataName, int delayMilliseconds)
{
    Console.WriteLine($"Process with exception starting for {dataName}");
    await Task.Delay(delayMilliseconds);
    if (dataName == "File 2")
    {
        throw new InvalidOperationException($"Processing File 2 failed: Unable to process data: {dataName}");
    }
    return $"Processing with exception has completed in {delayMilliseconds} milliseconds for {dataName}";
}