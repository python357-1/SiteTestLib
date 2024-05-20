namespace SiteTestLib.Types;

public class HtmlId {
	private string _id;

	public string Id {
		get => string.Format($"#{_id}");
		set => _id = value.StartsWith('#') ? value[1..] : value;
	}

	public static HtmlId New(string id) {
		if (id[0] == '#') id = id[1..];

		if (!char.IsLetter(id[0])) throw new ArgumentException("An HTML Id may not begin with a number.");
		
		if (!id.All(char.IsLetterOrDigit))
			throw new ArgumentException("An HTML Id may only be made of letters and numbers.");

		return new HtmlId(id);
	}

	private HtmlId(string id) {
		Id = id;
	}

	public override string ToString() {
		return Id;
	}
}