using System.Net;

namespace SiteTestLib.Types.Pipeline;

public class ContentFetcher(NetworkCredential creds) {
	// TODO: PipelineBuilder will have username and password
	private HttpClient _httpClient { get; set; } =
		new HttpClient(new HttpClientHandler{Credentials = creds});

	public async Task<PipelineData> Call(PipelineData data) {
		if (!data.Success ||
		    data.Data is not ContentRequest request) return data;

		switch (request.RequestMethod) {
			case RequestMethod.GET:
				await _httpClient.GetAsync(request.RequestUrl);
				break;
			case RequestMethod.POST:
				
				break;
			case RequestMethod.PUT:
				
				break;
			case RequestMethod.PATCH:
				
				break;
			case RequestMethod.DELETE:
				
				break;
		}
	}
}