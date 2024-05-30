using SiteTestLib.Types;
using SiteTestLib.Types.Pipeline;

namespace SiteTestLibTests;

public class ValidatorTests {
	[Fact]
	public void AnIdCanBeginWithAHashtagOrNot() {
		var templ = new ContentRequest(
			new Uri("https://www.google.com"),
			"someid",
			SelectorType.Id,
			"",
			RequestMethod.GET);
		IEnumerable<ContentRequest> TestData = [
			templ with { Selector = "#WithHashtag"},
			templ with { Selector = "WithoutHashtag"}
		];
		var testResults = Validator.Validate(TestData);
		Assert.All(testResults, x => Assert.True(x.Success));
	}

	[Fact]
	public void AnIdHasToStartWithALetter() {
		var templ = new ContentRequest(
			new Uri("https://www.google.com"),
			"someid",
			SelectorType.Id,
			"",
			RequestMethod.GET);
		
		IEnumerable<ContentRequest> TestData = [
			templ with {Selector = "1stElement", SelectorType = SelectorType.Id},
			templ with {Selector = "_ThisIsABadId", SelectorType = SelectorType.Id},
			templ with {Selector = "-ThisIsAlsoABadId", SelectorType = SelectorType.Id},
		];
		
		Assert.All(Validator.Validate(TestData), x => Assert.False(x.Success));
	}

	[Fact]
	public void AnIdMustBeAtLeastOneCharacter() {
		var templ = new ContentRequest(
			new Uri("https://www.google.com"),
			"",
			SelectorType.Id,
			"",
			RequestMethod.GET);

		Assert.False(Validator.Validate(templ).Success);
	}
}