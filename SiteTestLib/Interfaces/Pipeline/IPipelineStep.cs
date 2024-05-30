using SiteTestLib.Types;

namespace SiteTestLib.Interfaces.Pipeline;

public interface IPipelineStep {
	public IEnumerable<ContentRequest> Call(IEnumerable<ContentRequest> data);
	public void Call(ContentRequest data);
}