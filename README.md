# SharpEqualsTester

[![Build Status](https://travis-ci.org/Choc13/SharpEqualsTester.svg?branch=master)](https://travis-ci.org/Choc13/SharpEqualsTester)

## What Does It Do?
Helps you quickly test the `Equals` and `GetHashCode` implementations of your classes.

It checks your class meets the following conditions:

1. Comparing against itself returns `true`.
2. Comparing against `null` returns `false`.
3. Comparing to an instance of an incompatible class returns `false`.
4. Comparing two instances with the same data returns `true`.
5. Comparing two instances with different data returns `false`.
6. Comparing the hashcode of two instances with the same data return `true`.
7. Comparing the hashcode of two instances with different data returns `false`.

If any one of the above is not met when `Test()` is called it will throw an appropriate exception indicating which condition was not met and by which object(s).

## How Do I Use It?
1. Install via [NuGet](https://www.nuget.org/packages/SharpEqualsTester/)
2. Write a test like so:

```csharp
    // This example using XUnit, so it will fail if the tester throws
    // In other testing frameworks you may need do something like Assert.DoesNotThrow(() => tester.Test());
    [Fact]
    public void ShouldPassIfEqualsAndHashcodePerfectlyImplemented()
    {
        // Create groups of objects by varying all constructor parameters
        // Create a couple of instances in each group with the same data
        var object1A = new MyClass("one", 1);
        var object1B = new MyClass("one", 1);
        var object2A = new MyClass("two", 1);
        var object2B = new MyClass("two", 1);
        var object3A = new MyClass("one", 2);
        var object3B = new MyClass("one", 2);
        
        // Build and run the EqualsTester
        new EqualsTester<MyClass>()
            .AddEqualityGroup(object1A, object1B)
            .AddEqualityGroup(object2A, object2B)
            .AddEqualityGroup(object3A, object3B)
            .Test();
    }
```

## Some Tips
1. `public EqualsTester<T> AddEqualityGroup(params T[] items)` implements the builder pattern so calls can be chained. It also accepts any number of `T` so the entire group, no matter how large, can be passed in a single call.
2. It's generally not a useful test to add the same instance multiple times to a single equality group as the tester tests each object against itself anyway. Every object added to a group should be a new instance with the same data as other instances in the group.
