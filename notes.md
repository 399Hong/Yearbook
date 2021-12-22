## dotnet ef command
**mac**

```shell
// add migration
dotnet ef migrations add {name}
// update database according to the migrations
dotnet ef database update

```

TODO : add mutation, oauth
TODO : fix inconsistent names

## mutation.

need to return the original object, and other relevant info is added by the database.


### valueTask

A Task represents the state of some operation, i.e., whether the operation is completed, cancelled, and so on. An asynchronous method can return either a Task or a ValueTask.

Now, since Task is a reference type, returning a Task object from an asynchronous method implies allocating the object on the managed heap each time the method is called. Thus, one caveat in using Task is that you need to allocate memory in the managed heap every time you return a Task object from your method. If the result of the operation being performed by your method is available immediately or completes synchronously, this allocation is not needed and therefore becomes costly.

Here is exactly where ValueTask comes to the rescue. ValueTask<T> provides two major benefits. First, ValueTask<T> improves performance because it doesn’t need heap allocation, and second, it is both easy and flexible to implement. By returning ValueTask<T> instead of Task<T> from an asynchronous method when the result is immediately available, you can avoid the unnecessary overhead of allocation since “T” here represents a structure and a struct in C# is a value type (in contrast to the “T” in Task<T>, which represents a class).

Task and ValueTask represent two primary “awaitable” types in C#. Note that you cannot block on a ValueTask. If you need to block you should convert the ValueTask to a Task using the AsTask method and then block on that reference Task object.

Also note that each ValueTask can be consumed only once. Here the word “consume” implies that a ValueTask can asynchronously wait for (await) the operation to complete or take advantage of AsTask to convert a ValueTask to a Task. However, a ValueTask should be consumed only once, after which the ValueTask<T> should be ignored.
https://www.infoworld.com/article/3565433/how-to-use-valuetask-in-csharp.html
