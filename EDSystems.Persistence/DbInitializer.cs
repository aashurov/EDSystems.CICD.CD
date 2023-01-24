namespace EDSystems.Persistence;

public class DbInitializer
{
    public static void Initialize(EDSystemsDbContext dbcontext)
    {
        dbcontext.Database.EnsureDeleted();
        dbcontext.Database.EnsureCreated();
    }
}