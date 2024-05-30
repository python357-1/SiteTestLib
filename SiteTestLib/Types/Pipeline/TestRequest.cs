namespace SiteTestLib.Types.Pipeline;

public record TestRequest(
	string Selector,
	SelectorType SelectorType,
	string ExpectedValue) {
	
}