namespace SiteTestLib.Types;

public class Request {
	public Uri RequestUrl { get; set; }
	public HtmlId TargetElement { get; set; } //TODO: make a HtmlSelector class for this
	public string ExpectedValue { get; set; }
	public RequestMethod RequestMethod { get; set; }

	public Request(Uri url, HtmlId targetElement, string expectedValue, RequestMethod method) {
		RequestUrl = url;
		TargetElement = targetElement;
		ExpectedValue = expectedValue;
		RequestMethod = method;
	}
}