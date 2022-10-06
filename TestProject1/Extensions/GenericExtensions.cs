using FluentAssertions.Primitives;

namespace apiProjectTest.Extensions;

public static class GenericExtensions
{
    public static T BeOfTypeAndReturn<T>(this ObjectAssertions should)
    {
        should.BeOfType<T>();
        return (T)should.Subject;
    }
}