using AngleSharp;
using SiteTestLib.Types;

namespace SiteTestLib;

public class RequestExecutor {
	public HttpClient _httpClient { get; set; }
	public async Task<Response> ExecuteRequest(Request req) {
		if (req.RequestMethod == RequestMethod.GET) {
			var htmlContent = await _httpClient.GetAsync(req.RequestUrl);
			var context = BrowsingContext.New(Configuration.Default);
			var document = await context.OpenAsync(req => req.Content(htmlContent.ToString()));

			var element = document.QuerySelector(req.TargetElement.ToString());
			
			// if element is null return response
		}
		if (req.RequestMethod == RequestMethod.POST) {
			return new Response(await _httpClient.PostAsync(req.RequestUrl, new StringContent("")), req);
		}
		if (req.RequestMethod == RequestMethod.PUT) {
			return new Response(await _httpClient.PutAsync(req.RequestUrl, new StringContent("")), req);
		}
		if (req.RequestMethod == RequestMethod.PATCH) {
			return new Response(await _httpClient.PatchAsync(req.RequestUrl, new StringContent("")), req);
		}
		if (req.RequestMethod == RequestMethod.DELETE) {
			return new Response(await _httpClient.DeleteAsync(req.RequestUrl), req);
		}
		
		throw new ArgumentOutOfRangeException(nameof(req.RequestMethod));
	}

	public async Task<IEnumerable<Response>> ExecuteRequests(IAsyncEnumerable<Request> requests) {
		var responses = Enumerable.Empty<Response>();
		await foreach (var request in requests) {
			var res = await ExecuteRequest(request);
			responses = responses.Append(res);
		}

		return responses;
	}
}