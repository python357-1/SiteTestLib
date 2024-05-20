using System.Net;

namespace SiteTestLib.Types;

public class Response {
	public Request Request { get; set; }
	public HttpStatusCode StatusCode { get; set; }
	public string Content { get; set; }

	public Response(HttpResponseMessage res, Request req) {
		Request = req;
		StatusCode = res.StatusCode;
		Content = res.Content.ToString() ?? "";
	}
}