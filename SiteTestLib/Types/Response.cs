using System.Net;
using AngleSharp.Dom;

namespace SiteTestLib.Types;

public class Response {
	public ContentRequest ContentRequest { get; set; }
	public IElement? Content { get; set; } = null;
	public bool ElementFound { get; set; } = false;
	public HttpResponseMessage HttpResponse { get; set; }
	public Response(ContentRequest req, HttpResponseMessage hrm) {
		ContentRequest = req;
		HttpResponse = hrm;
	}
	public Response(ContentRequest req, HttpResponseMessage httpResponse, IElement? elem) {
		ContentRequest = req;
		Content = elem;
		HttpResponse = httpResponse;
		ElementFound = elem is null;
	}
}