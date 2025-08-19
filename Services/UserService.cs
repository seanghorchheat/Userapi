using Microsoft.Extensions.Options;
using MongoDB.Driver;
using UserApi.Models;

public class UserService
{
    private readonly IMongoCollection<User> _users;

    public UserService(IOptions<UserDatabaseSettings> settings)
    {
        var s = settings.Value;
        var client = new MongoClient(s.ConnectionString);
        var database = client.GetDatabase(s.DatabaseName);
        _users = database.GetCollection<User>(s.UsersCollectionName);
    }

    public List<User> Get() => _users.Find(u => true).ToList();
    public User Create(User user)
    {
        _users.InsertOne(user);
        return user;
    }
}
