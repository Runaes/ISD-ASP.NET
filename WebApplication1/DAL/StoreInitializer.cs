using System.Data.Entity;

namespace OMS.DAL
{
	public class StoreInitializer : DropCreateDatabaseIfModelChanges<StoreContext>
	{
	}
}
