namespace Riok.Mapperly.Tests.Mapping;

[UsesVerify]
public class MethodArgumentTest
{

    [Fact]
    public void WithOneExtraArgument()
    {
        var source = TestSourceBuilder.MapperWithBodyAndTypes(
            "partial B Map(A source, string extraPropertyB)",
            "class A { public string StringValue { get; set; }  }",
            "class B { public string StringValue { get; set; } public string ExtraPropertyB { get; set; } }");

        TestHelper.GenerateMapper(source)
            .Should()
            .HaveSingleMethodBody(@"var target = new B();
    target.StringValue = source.StringValue;
    target.ExtraPropertyB = extraPropertyB;
    return target;");
    }

    [Fact]
    public void VoidWithOneExtraArgument()
    {
        var source = TestSourceBuilder.MapperWithBodyAndTypes(
            "partial void Map(A source, B target, string extraPropertyB)",
            "class A { public string StringValue { get; set; }  }",
            "class B { public string StringValue { get; set; } public string ExtraPropertyB { get; set; } }");

        TestHelper.GenerateMapper(source)
            .Should()
            .HaveSingleMethodBody(@"var target = new B();
    target.StringValue = source.StringValue;
    target.ExtraPropertyB = extraPropertyB;");
    }
}
