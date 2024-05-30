using SiteTestLib.Interfaces;

namespace SiteTestLib.Types;

public record ContentRequest {
	public Uri RequestUrl { get; init; }

	public string Selector { get; init; }
	public SelectorType SelectorType { get; init; }
	public string ExpectedValue { get; init; }
	public RequestMethod RequestMethod { get; init; }

	public ContentRequest(
		Uri url,
		string selector,
		SelectorType selectorType,
		string expectedValue,
		RequestMethod method)
	{
		RequestUrl = url;
		Selector = selector;
		SelectorType = selectorType;
		ExpectedValue = expectedValue;
		RequestMethod = method;
	}
}