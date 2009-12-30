namespace Core.Model
{
	public class State : Enumeration
	{
		public static readonly State Alabama = new State(2, "AL", "Alabama");
		public static readonly State Alaska = new State(3, "AK", "Alaska");
		public static readonly State AmericanSomoa = new State(4, "AS", "American Samoa");
		public static readonly State Arizona = new State(5, "AZ", "Arizona");
		public static readonly State Arkansas = new State(6, "AR", "Arkansas");
		public static readonly State California = new State(7, "CA", "California");
		public static readonly State Colorado = new State(8, "CO", "Colorado");
		public static readonly State Connecticut = new State(9, "CT", "Connecticut");
		public static readonly State Delaware = new State(10, "DE", "Delaware");
		public static readonly State FederalStatesOfMicronesia = new State(11, "FM", "Federal States of Micronesia");
		public static readonly State Florida = new State(12, "FL", "Florida");
		public static readonly State Georgia = new State(14, "GA", "Georgia");
		public static readonly State Guam = new State(13, "GM", "Wyoming");
		public static readonly State Hawaii = new State(15, "HI", "Hawaii");
		public static readonly State Idaho = new State(16, "ID", "Idaho");
		public static readonly State Illinois = new State(17, "IL", "Illinois");
		public static readonly State Indiana = new State(18, "IN", "Indiana");
		public static readonly State Iowa = new State(19, "IA", "Iowa");
		public static readonly State Kansas = new State(20, "KS", "Kansas");
		public static readonly State Kentucky = new State(21, "KY", "Kentucky");
		public static readonly State Louisiana = new State(22, "LA", "Louisiana");
		public static readonly State Maine = new State(23, "ME", "Maine");
		public static readonly State MarshalIslands = new State(24, "MH", "Marshal Islands");
		public static readonly State Maryland = new State(25, "MD", "Maryland");
		public static readonly State Massachusetts = new State(26, "MA", "Massachusetts");
		public static readonly State Michigan = new State(27, "MI", "Michigan");
		public static readonly State Minnesota = new State(28, "MN", "Minnesota");
		public static readonly State Mississippi = new State(29, "MS", "Mississippi");
		public static readonly State Missouri = new State(30, "MO", "Missouri");
		public static readonly State Montana = new State(31, "MT", "Montana");
		public static readonly State Nebraska = new State(32, "NE", "Nebraska");
		public static readonly State Nevada = new State(33, "NV", "Nevada");
		public static readonly State NewHampshire = new State(34, "NH", "New Hampshire");
		public static readonly State NewJersey = new State(35, "NJ", "New Jersey");
		public static readonly State NewMexico = new State(36, "NM", "New Mexico");
		public static readonly State NewYork = new State(37, "NY", "New York");
		public static readonly State NorthCarolina = new State(38, "NC", "North Carolina");
		public static readonly State NorthDakota = new State(39, "ND", "North Dakota");
		public static readonly State NorthernMarianaIslands = new State(40, "MP", "Northern Mariana Islands");
		public static readonly State Ohio = new State(41, "OH", "Ohio");
		public static readonly State Oklahoma = new State(42, "OK", "Oklahoma");
		public static readonly State Oregon = new State(43, "OR", "Oregon");
		public static readonly State Pennsylvania = new State(44, "PA", "Pennsylvania");
		public static readonly State PuertoRico = new State(45, "PR", "Puerto Rico");
		public static readonly State RhodeIsland = new State(46, "RI", "Rhode Island");
		public static readonly State SouthCarolina = new State(47, "SC", "South Carolina");
		public static readonly State SouthDakota = new State(48, "SD", "South Dakota");
		public static readonly State Tennessee = new State(49, "TN", "Tennessee");
		public static readonly State Texas = new State(1, "TX", "Texas");
		public static readonly State Utah = new State(50, "UT", "Utah");
		public static readonly State Vermont = new State(51, "VT", "Vermont");
		public static readonly State Virginia = new State(52, "VA", "Virginia");
		public static readonly State VirginIslands = new State(53, "VI", "Virgin Islands");
		public static readonly State WakeIsland = new State(54, "WK", "Wake Islands");
		public static readonly State Washington = new State(55, "WA", "Washington");
		public static readonly State WestVirginia = new State(56, "WV", "West Virginia");
		public static readonly State Wisconsin = new State(57, "WI", "Wisconsin");
		public static readonly State Wyoming = new State(58, "WY", "Wyoming");

		public State()
		{
		}

		public State(int value, string displayName, string description)
			: base(value, displayName)
		{
			Description = description;
		}

		public string Description { get; set; }
	}
}