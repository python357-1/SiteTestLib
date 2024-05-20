using SiteTestLib.Types;
namespace SiteTestLibTests;


//This is not a great test and I am fully aware of that.
public class RequestExecutorTests {
	[Fact]
	public void GetRequestShouldReturnTrueIfValueExistsOnPage() {
		IEnumerable<Request> requests = [
			new Request(new Uri("http://jordanbc.xyz"), HtmlId.New("#some_id"), "a div with an id", RequestMethod.GET)
		];
	}
}