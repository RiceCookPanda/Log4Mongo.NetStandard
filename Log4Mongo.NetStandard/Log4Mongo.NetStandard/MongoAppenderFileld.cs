using log4net.Layout;

namespace Log4Mongo.NetStandard
{
	public class MongoAppenderFileld
	{
		public string Name { get; set; }
		public IRawLayout Layout { get; set; }
	}
}