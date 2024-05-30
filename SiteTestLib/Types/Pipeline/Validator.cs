namespace SiteTestLib.Types.Pipeline;

public class Validator {
	private static bool IsValidCharacter(char ch) {
		return char.IsNumber(ch) ||
		       char.IsLetter(ch) ||
		       ch == '_' ||
		       ch == '-';
	}

	public static IEnumerable<PipelineData> Validate(IEnumerable<ContentRequest> data) =>
		data.Select(Validate);
	public static PipelineData Validate(ContentRequest data) {
		switch (data.SelectorType) {
			case SelectorType.Id:
				// a null or empty string is not a valid id
				if (string.IsNullOrEmpty(data.Selector))
					return new PipelineData(data, false, FailureType.SelectorValidation);
				
				// an id may or may not start with a '#'
				// strip '#' for validation
				var selector = data.Selector[0] == '#' ? data.Selector[1..] : data.Selector;
				
				// an id must have at least one character
				if (selector.Length < 1)
					return new PipelineData(data, false, FailureType.SelectorValidation);
				
				/* an id may only start with a letter
				   browsers may support it but it is against the CSS Specification
				   and actually working with them is very odd
				   https://developer.mozilla.org/en-US/docs/Web/HTML/Global_attributes/id
				*/
				if (!char.IsLetter(selector[0]))
					return new PipelineData(data, false, FailureType.SelectorValidation);

				/* an id may only contain letters, numbers, underscores, and dashes.
				   browsers may support non-conforming ids but it is against the CSS Specification
				   and actually working with them is very odd
				   https://developer.mozilla.org/en-US/docs/Web/HTML/Global_attributes/id
				*/
				if (selector.Any(x => !IsValidCharacter(x)))
					return new PipelineData(data, false, FailureType.SelectorValidation);
				break;
			
			case SelectorType.Class:
				throw new NotImplementedException("Not implemented");
				break;
			
			default:
				throw new Exception("Unknown type: data.GetType() == " + data.GetType());
		}

		return new PipelineData(data, true, null);
	}
	
	public PipelineData Call(ContentRequest data) {
		return Validator.Validate(data);
	}
	public IEnumerable<PipelineData> Call(IEnumerable<ContentRequest> input) => input.Select(Call);

}