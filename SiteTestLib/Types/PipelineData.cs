namespace SiteTestLib.Types;

public record PipelineData(object Data, bool Success, FailureType? FailureReason) {
	//TODO: Make interface instead of object
}