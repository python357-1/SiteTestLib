using SiteTestLib.Types;

namespace SiteTestLibTests;

public class HtmlIdTests {
	[Fact]
	public void AnIdCannotStartWithANumber() {
		var id = "#1invalidid";
		Assert.Throws<ArgumentException>(() => HtmlId.New(id));
	}

	[Fact]
	public void AnIdCannotContainSpecialCharacters() {
		var id = "#invalid&id";
		Assert.Throws<ArgumentException>(() => HtmlId.New(id));
	}

	[Fact]
	public void AnIdDoesNotNeedAHashtag() {
		var id = "validid";
		var htmlid = HtmlId.New(id);
		Assert.True(htmlid.Id == string.Format($"#{id}"));
	}

	[Fact]
	public void AnIdCanStartWithAHashtag() {
		var id = "#validid";
		var htmlid = HtmlId.New(id);
		Assert.True(htmlid.Id == id);
	}
}