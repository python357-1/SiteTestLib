namespace SiteTestLib.Types;

public enum FailureType {
	// Validation Failures
	UrlValidation = 1,
	SelectorValidation = 2,
	
	// Content Request Failures
	HttpError = 3, // With this error, another prop/field should store what the error value was
	
	// Content Selection Failures
	ContentNotFound = 4,
	
	// Test Failures
	DidNotMatch = 5,
}