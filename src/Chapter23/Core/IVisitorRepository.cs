namespace Core
{
	public interface IVisitorRepository
	{
		void Save(Visitor visitor);
		Visitor[] GetRecentVisitors(int numberOfVisitors);
	}
}